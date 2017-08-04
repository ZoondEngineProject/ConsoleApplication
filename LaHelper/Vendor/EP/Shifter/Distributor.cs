using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Console.Vendor.EP.Shifter
{
    class Distributor
    {
        protected Socket Server;
        protected int Port;
        protected IPEndPoint Point;
        protected IPAddress Address;
        protected Saver Client;
        protected Receiver Receiver;
        protected Sender Sender;
        protected Thread Pool;
        protected Packets.Actions Action;
        protected bool SecureLine;

        private Packets.Searcher Searcher;

        protected void HandlingPacket(string message)
        {
            try
            {
                Searcher = new Packets.Searcher();
                Searcher.Search(message, Client);
            }
            catch(Exception ex)
            {
                Providers.Archivarius.PrepareMessage(ex).Logging().Error();
            }
        }
    }
}
