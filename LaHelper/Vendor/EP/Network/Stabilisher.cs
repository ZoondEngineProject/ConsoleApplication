using System;

namespace Console.Vendor.EP.Network
{
    class Stabilisher : Connector
    {
        public void Connect()
        {
            Providers.Eloquent.Pause(true);

            Providers.Monolit.Writeable("Введите IP-адрес хоста").Info();

            string line = System.Console.ReadLine();

            if(System.Net.IPAddress.TryParse(line, out HostIP))
            {
                HostIP = System.Net.IPAddress.Parse(line);
            }
            else
            {
                Providers.Monolit.Writeable("Недопустимый IP-адрес. Повторите попытку").Error();
            }

            Providers.Eloquent.Pause(false);
        }

        public void Online()
        {
            try
            {
                Providers.Monolit.Writeable("Проверяю доступность сервера: " + HostIP).Warning();

                this.Ping();

                if (this.PingReply.Status.ToString().Equals("TimedOut"))
                {
                    Providers.Monolit.Writeable("Сервер не доступен").Error();
                }
                else
                {
                    Providers.Monolit.Writeable("Сервер в работе").Success();
                }
            }
            catch(Exception)
            {
                Providers.Monolit.Writeable("Сперва нужно указать хост для соединения. (server connect)").Error();
            }
        }

        public void Stable()
        {
            try
            {
                int i = 0;
                long iterator = 0;
                double prcIterator = 0;

                long[] timer = new long[4];

                while (i < 4)
                {
                    Providers.Monolit.Writeable("Отправляю запрос...").Info();

                    this.Ping();
                    long time = this.PingReply.RoundtripTime;

                    if (this.PingReply.Status.ToString().Equals("TimedOut"))
                    {
                        Providers.Monolit.Writeable("Ответ не получен").Error();
                    }
                    else if(this.PingReply.Status.ToString().Equals("DestinationNetworkUnreachable"))
                    {
                        Providers.Monolit.Writeable("Хост не в зоне действия Вашей подсети").Error();
                    }
                    else
                    {
                        Providers.Monolit.Writeable("Получил ответ: " + this.PingReply.Status + " (Пинг: " + time + "мс)").Success();

                        timer[i] = time;
                    }

                    i++;
                }

                foreach (long time in timer)
                {
                    iterator += time;
                }

                iterator = iterator / timer.Length;
                prcIterator = Convert.ToDouble(iterator);

                if (this.PingReply.Status.ToString().Equals("TimedOut"))
                {
                    Providers.Monolit.Writeable("Сервер не доступен").Error();
                }
                else if (iterator < 100)
                {
                    if (prcIterator != 0)
                    {
                        prcIterator = prcIterator / 100 * 100;
                    }
                    else
                    {
                        prcIterator = 100;
                    }

                    Providers.Monolit.Writeable(string.Format("Стабильность сервера: {0}% (Средний пинг: {1}мс)", prcIterator, iterator)).Success();
                }
                else if (iterator < 250)
                {
                    prcIterator = prcIterator / 250 * 100;

                    Providers.Monolit.Writeable(string.Format("Стабильность сервера: {0}% (Средний пинг: {1}мс)", prcIterator, iterator)).Warning();
                }
                else
                {
                    prcIterator = prcIterator / 1000 * 100;

                    Providers.Monolit.Writeable(string.Format("Стабильность сервера: {0}% (Средний пинг: {1}мс)", prcIterator, iterator)).Error();
                }
            }
            catch(Exception)
            {
                Providers.Monolit.Writeable("Сперва нужно указать хост для соединения. (server connect)").Error();
            }
            finally
            {
                Providers.Monolit.Writeable("Анализ закончен").Info();
            }
        }
    }
}
