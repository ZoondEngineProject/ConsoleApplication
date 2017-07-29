namespace Console.Vendor.EP.Shifter.Packets
{
    class Searcher : Distributor
    {
        private string Packet;
        private string[] IDPacket;
        private char SplitDelimeter;

        public void Search(string packet, Saver client)
        {
            //Внедрение зависимостей
            IDPacket = new string[10];
            Packet = packet;

            //Инициализация менеджера событий
            this.Action = new Actions();

            this.Sender = new Sender(client);
            this.Client = client;

            //Разделение пакета
            SplitDelimeter = '|';
            IDPacket = Packet.Split(SplitDelimeter);

            //Разбор пакета
            Loop();
        }

        private void Loop()
        {
            switch(IDPacket[1])
            {
                case Library.PACKET_COMMAND_RESTART:
                    {
                        
                        Action.OnPacketReceiveMsgShutdown();
                        break;
                    }

                case Library.PACKET_COMMAND_SHUTDOWN:
                    {
                        this.Sender.Send(Dictionary.RESPONSE_SHUTDOWN);
                        Providers.Eloquent.Inject("this shutdown");

                        break;
                    }

                case Library.PACKET_COMMAND_TIME:
                    {
                        this.Sender.Send("Серверное время: " + Providers.Shelf.time());

                        break;
                    }

                case Library.PACKET_COMMAND_DATE:
                    {
                        this.Sender.Send("Серверная дата: " + Providers.Shelf.date());

                        break;
                    }

                default:
                    {
                        this.Sender.Send(Dictionary.RESPONSE_SECURITY_LINE_ENABLED);
                        Providers.Monolit.Writeable(Dictionary.RESPONSE_SECURITY_LINE_ENABLED).Error();
                        Providers.Network.Disconnect();

                        break;
                    }
            }
        }
    }
}
