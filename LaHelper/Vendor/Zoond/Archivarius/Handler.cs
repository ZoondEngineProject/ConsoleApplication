namespace LaHelper.Vendor.Zoond.Archivarius
{
    sealed class Handler : Distributor
    {
        private string Message;

        public Writer Logging()
        {
            base.Write = new Writer(Message);
            return base.Write;
        }

        public Handler PrepareMessage(string message)
        {
            string timestamp = Console.Providers.Shelf.date() + "||" + Console.Providers.Shelf.time() + ">>";

            timestamp += message;

            Message = timestamp;

            return this;
        }
    }
}
