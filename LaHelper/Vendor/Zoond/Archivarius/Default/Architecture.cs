using System;
using System.IO;

namespace LaHelper.Vendor.Zoond.Archivarius.Default
{
    class Architecture
    {
        protected static string BasePath;
        protected static object Locker = new object();

        public static void Check()
        {
            BasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log/");

            if (File.Exists(BasePath + "Main.trace"))
            {
                
            }
            else
            {
                QuestionCreate();
            }
        }

        public static string GetBasePath()
        {
            return BasePath;
        }

        private static void QuestionCreate()
        {
            Console.Providers.Eloquent.Pause(true);

            Console.Providers.Monolit.Writeable("Платформа не обнаружена. Создать ?").Info();

            string key = System.Console.ReadLine();

            if(key.Equals("да"))
            {
                Folders.Create();
                FilesContent.Create();

                Check();
            }
            else if(key.Equals("нет"))
            {
                Console.Providers.Eloquent.Pause(false);

                Console.Providers.Monolit.Writeable("Платформа @Archivarius не инициализирована.").Warning();
            }
            else
            {
                Console.Providers.Monolit.Writeable("Неивестная команда").Error();

                QuestionCreate();
            }
        }
    }
}
