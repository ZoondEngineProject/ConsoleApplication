using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaHelper
{
    class Application
    {
        public static void Shutdown()
        {
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
