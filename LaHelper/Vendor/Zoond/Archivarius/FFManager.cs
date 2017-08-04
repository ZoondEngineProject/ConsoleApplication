using System.IO;

namespace LaHelper.Vendor.Zoond.Archivarius
{
    class FFManager
    {
        private object Locker = new object();

        public void Write(string message)
        {
            lock (Locker)
            {
                File.AppendAllText(
                    Default.Architecture.GetBasePath() + "Main.trace",
                    message,
                    System.Text.Encoding.UTF8);
            }
        }

        public void CheckPlatform()
        {
            Default.Architecture.Check();
        }
    }
}
