namespace LaHelper.Vendor.Zoond.Archivarius
{
    sealed class Handler : Distributor
    {
        private string Message = null;

        public Writer Logging()
        {
            if(Message == null)
            {
                Console.Providers.Monolit.Writeable("Отсутствует объект логирования").Error();
                return null;
            }
            else
            {
                base.Write = new Writer(Message);
                return base.Write;
            }
        }

        public Handler PrepareMessage(System.Exception ex)
        {
            Message = System.String.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] [{1}.{2}()] {3} \r\n",
                System.DateTime.Now, ex.TargetSite.DeclaringType, ex.TargetSite.Name, ex.Message);

            return this;
        }

        public void Check()
        {
            Default.Architecture.Check();
        }
    }
}
