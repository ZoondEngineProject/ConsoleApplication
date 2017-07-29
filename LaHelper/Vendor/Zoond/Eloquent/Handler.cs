using System;
using Console;

namespace Nasty.Vendor.Zoond.Eloquent
{
    class Handler : Commands
    {
        public void Listen()
        {
            string line = System.Console.ReadLine();

            try
            {
                this.Loop(line);
            }
            catch(Exceptions.RunErrorException e)
            {
                Providers.Monolit.Writeable(e.Message).Error();
            }
        }

        private void Loop(string command)
        {
            try
            {
                switch (command)
                {
                    case Dictionary.COMMAND_HELP:
                        {
                            this.OnHelp();
                            break;
                        }

                    case Dictionary.COMMAND_PROGRAM_SHUTDOWN:
                        {
                            this.OnProgramShutdown();
                            break;
                        }

                    case Dictionary.COMMAND_PROGRAM_FORCE_SH:
                        {
                            this.OnProgramForceShutdown();
                            break;
                        }

                    case Dictionary.COMMAND_PROGRAM_RESTART:
                        {
                            this.OnProgramRestart();
                            break;
                        }

                    case Dictionary.COMMAND_SERVER_TIME:
                        {
                            this.OnServerTime();
                            break;
                        }

                    case Dictionary.COMMAND_SERVER_STABILITY:
                        {
                            this.OnServerStability();
                            break;
                        }

                    case Dictionary.COMMAND_SERVER_ISONLINE:
                        {
                            this.OnServerOnline();
                            break;
                        }

                    case Dictionary.COMMAND_SERVER_CONNECT:
                        {
                            this.OnServerConnect();
                            break;
                        }

                    case Dictionary.COMMAND_SERVER_DATE:
                        {
                            this.OnServerDate();
                            break;
                        }

                    case Dictionary.COMMAND_APP_START:
                        {
                            this.OnAppStart();
                            break;
                        }

                    case Dictionary.COMMAND_APP_INJECT:
                        {
                            this.OnAppInject();
                            break;
                        }

                    case Dictionary.COMMAND_NETWORK_START:
                        {
                            this.OnNetworkStart();
                            break;
                        }

                    case Dictionary.COMMAND_NETWORK_STOP:
                        {
                            this.OnNetworkStop();
                            break;
                        }

                    default:
                        {
                            Providers.Monolit.Writeable("Команда не распознана").Error();
                            break;
                        }
                }
            }
            catch(Exceptions.CommandErrorException e)
            {
                Providers.Monolit.Writeable(e.Message).Error();
            }

            this.Listen();
        }

        public void Pause(bool value)
        {
            if(value)
            {
                Providers.Monolit.Writeable("Модуль @Eloquent приостановлен").Error();
                
            }
            else
            {
                Providers.Monolit.Writeable("Модуль @Eloquent возобновлен").Success();
                this.Listen();
            }
        }

        public void Inject(string command)
        {
            Loop(command);
        }
    }
}
