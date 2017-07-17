using System;

namespace Nasty.Vendor.Zoond.Shelf
{
    class Handler
    {
        /// <summary>
        /// Возвращает настоящее количество часов.
        /// </summary>
        /// <returns>int</returns>
        public int hours()
        {
            return DateTime.Now.Hour;
        }

        /// <summary>
        /// Возвращает настоящее количество минут.
        /// </summary>
        /// <returns>int</returns>
        public int minutes()
        {
            return DateTime.Now.Minute;
        }

        /// <summary>
        /// Возвращает настоящее количество секунд.
        /// </summary>
        /// <returns>int</returns>
        public int seconds()
        {
            return DateTime.Now.Second;
        }

        /// <summary>
        /// Возвращает настоящее количество миллисекунд.
        /// </summary>
        /// <returns>int</returns>
        public int milliseconds()
        {
            return DateTime.Now.Millisecond;
        }

        /// <summary>
        /// Возвращает текущее число.
        /// </summary>
        /// <returns></returns>
        public int days()
        {
            return DateTime.Now.Day;
        }

        /// <summary>
        /// Возвращает текущий месяц.
        /// </summary>
        /// <returns></returns>
        public int month()
        {
            return DateTime.Now.Month;
        }

        /// <summary>
        /// Возвращает текущий год.
        /// </summary>
        /// <returns></returns>
        public int year()
        {
            return DateTime.Now.Year;
        }

        /// <summary>
        /// Возвращает готовый формат времени.
        /// </summary>
        /// <returns></returns>
        public string time()
        {
            return String.Format("[{0}:{1}:{2}]", this.hours(), this.minutes(), this.seconds());
        }

        /// <summary>
        /// Возвращает готовый формат даты.
        /// </summary>
        /// <returns></returns>
        public string date()
        {
            return String.Format("{0}.{1}.{2}", this.days(), this.month(), this.year());
        }
    }
}
