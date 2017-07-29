using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Console.Resources.Configuration.Network;

namespace Console.Vendor.EP.Shifter
{
    class Listener : Distributor
    {
        public Listener()
        {
            this.Port = Connection.PORT;
            this.Address = IPAddress.Parse(Connection.IP_ADDRESS);
            this.Point = new IPEndPoint(this.Address, this.Port);

            this.Server = new Socket(this.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            Providers.Monolit.Writeable("Запускаю слушатель сети").Info();

            this.Pool = new Thread(ServerStart);

            Pool.Start();
        }

        private void ServerStart()
        {
            try
            {
                Providers.Monolit.Writeable("Модуль @Network инициализирован").Success();
                Providers.Monolit.Writeable("Ожидаю входящих соединений...").Info();

                if (!this.Server.IsBound)
                {
                    this.Server.Bind(this.Point);
                }

                this.Server.Listen(Connection.QUEUE_COUNT);

                while (true)
                {
                    this.Client = new Saver(Server.Accept());

                    Providers.Monolit.Writeable("Пользователь: " + this.Client.GetID() + " подключен").Success();

                    if (this.Client.Notices().Available < 0)
                    {
                        Providers.Monolit.Writeable("Клиент отключился").Info();
                    }
                    else
                    {
                        try
                        {
                            this.Receiver = new Receiver();
                            this.Receiver.Receive(this.Client.Notices().Receive(this.Receiver.InputBytes));
                            this.Sender = new Sender(this.Client);
                            this.HandlingPacket(this.Receiver.DesinflatedPacket);
                        }
                        catch (Exception)
                        {
                            Providers.Monolit.Writeable("Пользователь: "+ this.Client.GetID() +" отключился").Info();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Providers.Monolit.Writeable(ex.ToString()).Error();
            }
        }

        private void CloseClientListenMessages()
        {
            this.Client.Notices().Close();
        }

        public void Disconnect()
        {
            this.Client.Notices().Shutdown(SocketShutdown.Both);
        }

        public void Stop()
        {
            try
            {
                this.Pool.Interrupt();
            }
            catch(Exception)
            {
                Providers.Monolit.Writeable("Ошибка уничтожения сокета. Запустите сервер заново").Error();
                Providers.Eloquent.Inject("this shutdown");
            }
            finally
            {
                Providers.Monolit.Writeable("Модуль @Network деинизиализирован").Warning();
            }
        }
    }
}
