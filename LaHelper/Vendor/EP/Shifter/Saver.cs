using System;
using System.Net.Sockets;

namespace Console.Vendor.EP.Shifter
{
    class Saver
    {
        private Socket Client;
        private string[] Data;

        public Saver(Socket client)
        {
            Client = client;
            Data = new string[10];
            SaveClientData();
        }

        private void SaveClientData()
        {
            Char delimeter = ':';
            //Количество полученных из сеты данных
            Data[0] = Client.Available.ToString();

            //Конечная точка пользователя
            Data[1] = Client.RemoteEndPoint.ToString();

            //Ип адрес пользователя
            string[] del = Data[1].Split(delimeter);
            Data[2] = del[0];

            //Secure Line
            Data[3] = "0";
        }

        public void SetSecure()
        {
            Data[3] = "1";
        }

        public string GetSecure()
        {
            return Data[3];
        }

        public Socket Notices()
        {
            return Client;
        }

        public string GetID()
        {
            return Data[2];
        }
    }
}
