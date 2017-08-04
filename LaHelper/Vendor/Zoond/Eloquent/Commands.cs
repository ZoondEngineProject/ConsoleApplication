using System;
using Console;

namespace Nasty.Vendor.Zoond.Eloquent
{
    class Commands
    {
        protected void OnHelp()
        {
            foreach(string line in CommandList.cmdList)
            {
                Providers.Monolit.Writeable(line).Info();
            }
        }
        protected void OnServerTime()
        {
            Providers.Monolit.Writeable(String.Format("Время сервера: {0}", Providers.Accelerator.Time())).Info();
        }

        protected void OnServerDate()
        {
            Providers.Monolit.Writeable(String.Format("Дата сервера: {0}", Providers.Accelerator.Date())).Info();
        }

        protected void OnServerStability()
        {
            Providers.Status.Stable();
        }

        protected void OnServerOnline()
        {
            Providers.Status.Online();
        }

        protected void OnServerConnect()
        {
            Providers.Status.Connect();
        }

        public void OnProgramRestart()
        {
            Application.Restart();
        }

        protected void OnProgramShutdown()
        {
            Application.Shutdown();
        }

        protected void OnProgramForceShutdown()
        {
            Application.ForceShutdown(-1);
        }

        protected void OnAppStart()
        {
            Providers.App.Run(false);
        }

        protected void OnAppInject()
        {
            Providers.App.Run(true).Set();
        }

        protected void OnNetworkStart()
        {
            Providers.Shifter.Start();
        }

        protected void OnNetworkStop()
        {
            Providers.Shifter.Stop();
        }
    }
}
