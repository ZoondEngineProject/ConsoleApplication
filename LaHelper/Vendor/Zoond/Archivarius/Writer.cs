namespace LaHelper.Vendor.Zoond.Archivarius
{
    class Writer
    {
        private FFManager Filer;
        private string Message;
        private string errlevel;

        public Writer(string message)
        {
            Filer = new FFManager();
            Message = message;
        }

        public void Debug()
        {
            errlevel = "DEBUG::";
            errlevel += Message;

            Filer.Write(errlevel);
        }

        public void Custom(string caller)
        {
            errlevel = "CUSTOM::" + caller;
            errlevel += Message;

            Filer.Write(errlevel);
        }

        public void Custom(string caller, int errorlevel)
        {

            errlevel = errorlevel + "::" + caller;
            errlevel += Message;

            Filer.Write(errlevel);
        }

        public void Warning()
        {
            errlevel = "WARNING::";
            errlevel += Message;

            Filer.Write(errlevel);
        }

        public void Success()
        {
            errlevel = "SUCCESS::";
            errlevel += Message;

            Filer.Write(errlevel);
        }

        public void Error()
        {
            errlevel = "ERROR::";
            errlevel += Message;

            Filer.Write(errlevel);
        }
    }
}
