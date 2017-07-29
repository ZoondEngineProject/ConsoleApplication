using System;
using System.Threading;

namespace Console.Vendor.EP.App
{
    class Handler : Library
    {
        public Handler Run(bool withArgs)
        {
            if(withArgs)
            {
                return this;
            }
            else
            {
                Providers.Monolit.Writeable("Ищу объект для запуска ...").Info();

                if (this.Finded())
                {
                    Secure();

                    Providers.Monolit.Writeable("Объект обнаружен. Запускаю...").Success();
                    this.Start();
                    return this;
                }
                else
                {
                    Providers.Monolit.Writeable("Я не нашел объект... :(").Error();
                    return this;
                }
            }
        }

        public void Set()
        {
            Providers.Eloquent.Pause(true);

            Providers.Monolit.Writeable("Введите аргументы для запуска ...").Info();

            string line = System.Console.ReadLine();
            this.Args = line;

            var AppRunning = new Thread(() =>
            {
                Providers.Monolit.Writeable("Внедряю аргументы: " + args).Info();

                Run(false);
            });

            AppRunning.Start();

            Providers.Eloquent.Pause(false);
        }

        public void Secure()
        {
            Providers.Monolit.Writeable("Защищаю линию соединения ...").Info();
            //Имитация ла ла ла ...
        }
    }
}
