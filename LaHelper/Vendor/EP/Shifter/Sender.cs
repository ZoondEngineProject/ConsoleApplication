using System.Text;

namespace Console.Vendor.EP.Shifter
{
    class Sender
    {
        private Saver Client;
        private byte[] Buffer = new byte[1024];

        public Sender(Saver client)
        {
            Client = client;
        }

        public void Send(string message)
        {
            Buffer = Encoding.UTF8.GetBytes(message);
            To();
        }

        public void Send(string message, string data)
        {
            message += "|";
            message += data;
            Buffer = Encoding.UTF8.GetBytes(message);
            To();
        }

        private void To()
        {
            if (Buffer != null)
            {
                Client.Notices().Send(Buffer);
            }
            else
            {
                Providers.Monolit.Writeable("Ошибка отправки ответа. Код ошибки: 01").Error();
            }
        }
    }
}
