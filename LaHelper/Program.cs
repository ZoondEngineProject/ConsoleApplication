using System;
using System.Threading;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintInfo();
            ArchivariusAdapter();
            MonolitAdapter();
            EloquentAdapter();
        }

        private static void PrintInfo()
        {
            Providers.Monolit.Writeable("Добро пожаловать в Zoond Console App").Info();
            Providers.Monolit.Writeable("Версия: 0.37.143а").Info();
            Providers.Monolit.Writeable("Автор: Alexey Mango").Info();
            Providers.Monolit.Writeable("Zoond Engine Lab 2017 (c)").Info();
        }

        static void ArchivariusAdapter()
        {
            try
            {
                Console.Providers.Monolit.Writeable("Модуль @Archivarius инициализирован").Success();
                Providers.Archivarius.Check();
            }
            catch(Exception e)
            {
                Providers.Monolit.Writeable("Не удалось инициализировать @Archivarius. Trace: ").Error();
                Providers.Monolit.Writeable(e.StackTrace).Error();
            }
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
                Providers.Archivarius.PrepareMessage(e).Logging().Error();
            }
            finally
            {
                Providers.Monolit.Writeable("Модуль @Eloquent инициализирован.").Success();
                Providers.Monolit.Writeable("Введите help для доступа к списку команд").Info();
            }
        }

        static void MonolitAdapter()
        {
            if(Providers.Monolit.IsOk())
            {
                Providers.Monolit.Writeable("Модуль @Monolit инициализирован.").Success();
            } else
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Ошибка ! Модуль @Monolit не инициализирован !");
            }
        }

        public static void Restart()
        {
            Providers.Monolit.Writeable("В разработке...").Error();
        }
    }
}
