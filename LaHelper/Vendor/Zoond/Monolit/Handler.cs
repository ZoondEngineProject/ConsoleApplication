using System;
using LaHelper;

namespace Nasty.Vendor.Zoond.Monolit
{
    class Handler
    {
        private string text;

        public Handler Writeable(string str)
        {
            this.text = str;

            return this;
        }

        public bool IsOk()
        {
            return true;
        }

        public void Error()
        {
            this.Set(ConsoleColor.Black, ConsoleColor.Red);

            this.text = String.Format("{0} >> {1}", Providers.Shelf.time(), this.text);
            Console.WriteLine(this.text);

            this.Reset();
        }
        public void Warning()
        {
            this.Set(ConsoleColor.Black, ConsoleColor.DarkYellow);

            this.text = String.Format("{0} >> {1}", Providers.Shelf.time(), this.text);
            Console.WriteLine(this.text);

            this.Reset();
        }

        public void Info()
        {
            this.Set(ConsoleColor.Black, ConsoleColor.Gray);

            this.text = String.Format("{0} >> {1}", Providers.Shelf.time(), this.text);
            Console.WriteLine(this.text);

            this.Reset();
        }

        public void Success()
        {
            this.Set(ConsoleColor.Black, ConsoleColor.DarkGreen);

            this.text = String.Format("{0} >> {1}", Providers.Shelf.time(), this.text);
            Console.WriteLine(this.text);

            this.Reset();
        }


        private void Set(ConsoleColor back, ConsoleColor fore)
        {
            Console.BackgroundColor = back;
            Console.ForegroundColor = fore;
        }

        private void Reset()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
