namespace LaHelper.Vendor.EP.Network
{
    class Stabilisher : Connector
    {
        private string host;

        public Stabilisher()
        {
            host = "127.0.0.1";
            this.SetHost(this.host);
        }

        public void Online()
        {
            Providers.Monolit.Writeable("Проверка доступности сервера: " + host).Warning();

            this.Ping();

            if(this.PingReply.Status.ToString().Equals("TimedOut"))
            {
                Providers.Monolit.Writeable("Сервер не доступен").Error();
            } else
            {
                Providers.Monolit.Writeable("Сервер в работе").Success();
            }
        }

        public void Stable()
        {
            long time = this.PingReply.RoundtripTime;
            time = time / 1000;

            if(time < 1)
            {
                Providers.Monolit.Writeable("Стабильность сервера: 99.87%").Success();
            }
            else if(time < 2)
            {
                Providers.Monolit.Writeable("Стабильность сервера: 48.38%").Warning();
            }
            else
            {
                Providers.Monolit.Writeable("Сервер технически не стабилен").Error();
            }
        }
    }
}
