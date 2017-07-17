using LaHelper;

namespace Nasty.Vendor.Zoond.Eloquent
{
    class Commands
    {
        protected void OnServerTime()
        {
            Providers.Monolit.Writeable(Providers.Accelerator.Time()).Info();
        }

        protected void OnServerDate()
        {
            Providers.Monolit.Writeable(Providers.Accelerator.Date()).Info();
        }

        protected void OnServerStability()
        {
            Providers.Status.Stable();
        }

        protected void OnServerOnline()
        {
            Providers.Status.Online();
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
