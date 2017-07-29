using System;
using Console;

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
            System.Console.WriteLine(this.text);

            this.Reset();
        }
        public void Warning()
        {
            this.Set(ConsoleColor.Black, ConsoleColor.DarkYellow);

            this.text = String.Format("{0} >> {1}", Providers.Shelf.time(), this.text);
            System.Console.WriteLine(this.text);

            this.Reset();
        }

        public void Info()
        {
            this.Set(ConsoleColor.Black, ConsoleColor.Gray);

            this.text = String.Format("{0} >> {1}", Providers.Shelf.time(), this.text);
            System.Console.WriteLine(this.text);

            this.Reset();
        }

        public void Success()
        {
            this.Set(ConsoleColor.Black, ConsoleColor.DarkGreen);

            this.text = String.Format("{0} >> {1}", Providers.Shelf.time(), this.text);
            System.Console.WriteLine(this.text);

            this.Reset();
        }


        private void Set(ConsoleColor back, ConsoleColor fore)
        {
            System.Console.BackgroundColor = back;
            System.Console.ForegroundColor = fore;
        }

        private void Reset()
        {
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
