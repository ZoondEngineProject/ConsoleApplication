using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Console.Vendor.EP.App
{
    class Library
    {
        protected const string APPLICATION_NAME = "L2.exe";
        protected string args = null;
        protected Process process = new Process();

        protected void Start()
        {
            try
            {
                process.StartInfo.FileName = APPLICATION_NAME;
                process.StartInfo.ErrorDialog = true;

                if (WithArgs())
                {
                    process.StartInfo.Arguments = args;
                    process.Start();
                }
                else
                {
                    process.Start();
                }

                ProcessInfo();
            }
            catch(System.Exception e)
            {
                Providers.Monolit.Writeable(e.Message).Error();
            }
        }

        private void ProcessInfo()
        {
            int elapsed = 0;

            process.Refresh();

            Providers.Monolit.Writeable(System.String.Format("Объект '{3}' запущен (ID: {0}, STI: {1}, PR: {2})",
                process.Id,
                process.StartTime,
                process.BasePriority,
                process.ProcessName)).Success();
            do
            {
                elapsed += 1;
            }
            while (!process.WaitForExit(1000));
            ProcessExited(elapsed);
        }

        private void ProcessExited(int elapsed)
        {
            Providers.Monolit.Writeable(System.String.Format("Очищаю сессию: {0}", process.SessionId)).Warning();

            Providers.Monolit.Writeable("Отключение датчиков...").Warning();

            Providers.Monolit.Writeable(System.String.Format("Процесс '{0}' (ID:{1}) завершен",
                process.ProcessName,
                process.Id)).Warning();

            Providers.Monolit.Writeable("(Приблизительное время работы: ~"+ elapsed +"c)Работа с объектом завершена. EC: " + process.ExitCode).Success();
        }

        private bool WithArgs()
        {
            if (args == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool Finded()
        {
            if(File.Exists(APPLICATION_NAME))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected string Args
        {
            get { return args; }
            set { args = value; }
        }
    }
}
