namespace Console.Vendor.EP.Network
{
    class Accelerator : Connector
    {
        public string Time()
        {
            int hour = Providers.Shelf.hours();
            int minute = Providers.Shelf.minutes();
            int second = Providers.Shelf.seconds();

            hour = hour - 9;

            return hour.ToString() + ":" + minute.ToString() + ":" + second.ToString();
        }

        public string Date()
        {
            int day = Providers.Shelf.days();
            int month = Providers.Shelf.month();
            int year = Providers.Shelf.year();

            if (Providers.Shelf.hours() < 9)
            {
                day = day - 1;
            }

            return day.ToString() + "/" + month.ToString() + "/" + year.ToString();
        }
    }
}
