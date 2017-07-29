using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите адрес подключения");

            string line = Console.ReadLine();

            try
            {
                Console.WriteLine("Подключение к серверу...");
                SendMessageFromSocket(8709, line);
            }
            catch (Exception)
            {
                //Console.WriteLine(ex.ToString());
                Console.WriteLine("Подключение не удалось. Переподключение...");
                SendMessageFromSocket(8709, line);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        static void SendMessageFromSocket(int port, string address)
        {

            IPAddress ipAddr = IPAddress.Parse(address);
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Соединяем сокет с удаленной точкой
            sender.Connect(ipEndPoint);


            // Буфер для входящих данных
            byte[] bytes = new byte[1024];

            string message = ipAddr.ToString() + "|";

            Console.Write("Введите сообщение: ");
            string input = Console.ReadLine();

            if (input.Equals("close"))
            {
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            else
            {
                message += input;
                Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
                byte[] msg = Encoding.UTF8.GetBytes(message);

                // Отправляем данные через сокет
                int bytesSent = sender.Send(msg);

                Console.WriteLine("Данные отправлены");
                // Получаем ответ от сервера
                int bytesRec = sender.Receive(bytes);

                Console.WriteLine("\nОтвет от сервера: {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));

                // Используем рекурсию для неоднократного вызова SendMessageFromSocket()
                if (message.IndexOf("<TheEnd>") == -1)
                    SendMessageFromSocket(port, address);
            }
        }
    }
}