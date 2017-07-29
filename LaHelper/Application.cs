using System;
using System.Threading;

namespace Console
{
    class Application
    {
        public static void Shutdown()
        {
            Providers.Monolit.Writeable("Сервер будет выключен через 3 секунды").Warning();
            Thread.Sleep(3000);
            Environment.Exit(0);
        }

        public static void ForceShutdown(int code)
        {
            Environment.Exit(code);
        }

        public static void Restart()
        {
            Providers.Monolit.Writeable("Сервер перезагрузится....").Warning();
            Program.Restart();
        }
    }
}
