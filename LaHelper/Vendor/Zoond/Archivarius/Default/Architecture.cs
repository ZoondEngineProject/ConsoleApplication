using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaHelper.Vendor.Zoond.Archivarius.Default
{
    class Architecture
    {
        private static bool PlatformCreated;

        public static void Check()
        {
            if(PlatformCreated)
            {
                Console.Providers.Monolit.Writeable("Платформа для логирования инициализирована").Success();
            }
            else
            {
                QuestionCreate();
            }
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
