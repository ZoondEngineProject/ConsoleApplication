using System;
using System.Threading;

namespace LaHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            EloquentAdapter();

            Providers.Status.CheckStatus();
        }
        
        static void EloquentAdapter()
        {
            try
            {
                var Eloquent = new Thread(() =>
                {
                    Providers.Eloquent.Listen();
                });

                Eloquent.Start();
            }
            catch (Exception e)
            {
                Providers.Monolit.Writeable(e.Message).Error();
            }
            finally
            {
                Providers.Monolit.Writeable("Модуль @Eloquent инициализирован.").Success();
            }
        }

        static void MonolitAdapter()
        {
            if(Providers.Monolit.IsOk())
            {
                Providers.Monolit.Writeable("Модуль @Monolit инициализирован.").Success();
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка ! Модуль @Monolit не инициализирован !");
            }
        }

        public static void Restart()
        {
            Main(null);
        }
    }
}
