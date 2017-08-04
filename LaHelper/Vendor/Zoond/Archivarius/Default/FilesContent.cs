using System.IO;

namespace LaHelper.Vendor.Zoond.Archivarius.Default
{
    sealed class FilesContent : Architecture
    {
        public static void Create()
        {
            if(File.Exists(BasePath + "Main.trace"))
            {
                Console.Providers.Monolit.Writeable("Файл логирования уже создан").Error();
            }
            else
            {
                lock (Locker)
                {
                    File.Create(BasePath + "Main.trace");
                    Console.Providers.Monolit.Writeable("Файл логирования создан").Success();
                }
            }
        }
    }
}
