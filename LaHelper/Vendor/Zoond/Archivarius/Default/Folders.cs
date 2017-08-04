using System.IO;

namespace LaHelper.Vendor.Zoond.Archivarius.Default
{
    sealed class Folders : Architecture
    {
        public static void Create()
        {
            if(Directory.Exists(BasePath))
            {
                Console.Providers.Monolit.Writeable("Директория Logs уже создана").Error();
            }
            else
            {
                lock(Locker)
                {
                    Directory.CreateDirectory(BasePath);
                    Console.Providers.Monolit.Writeable("Директория Logs создана").Success();
                }
            }
        }
    }
}
