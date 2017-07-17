namespace LaHelper.Vendor.EP.Network
{
    class Stabilisher : Connector
    {
        private string host;

        public Stabilisher()
        {
            host = "186.2.166.8";
            this.SetHost(this.host);
        }

        public void Seed()
        {
            //
        }

        public void CheckStatus()
        {
            Providers.Monolit.Writeable("Проверка доступности сервера: " + host).Warning();
            this.Ping();
            if(this.PingReply.Status.ToString().Equals("TimedOut"))
            {
                Providers.Monolit.Writeable("Сервер не доступен !").Error();
            } else
            {
                Providers.Monolit.Writeable("Сервер в работе ! Проверка стабильности...").Success();
                this.Stable();
            }
        }

        public void Stable()
        {
            //
        }
    }
}
