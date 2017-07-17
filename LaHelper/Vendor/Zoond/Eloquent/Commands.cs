using System;
using LaHelper;

namespace Nasty.Vendor.Zoond.Eloquent
{
    class Commands
    {
        protected void OnServerTime()
        {
            //Providers.Monolit.writeable(String.Format("Серверное время: {0}", Providers.Shelf.time())).info();
            Providers.Monolit.Writeable(Providers.Accelerator.Time()).Info();
        }

        protected void OnServerDate()
        {
            Providers.Monolit.Writeable(Providers.Accelerator.Date()).Info();
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
    }
}
