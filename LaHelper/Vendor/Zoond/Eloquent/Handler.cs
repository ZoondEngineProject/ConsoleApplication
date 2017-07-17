using System;
using LaHelper;

namespace Nasty.Vendor.Zoond.Eloquent
{
    class Handler : Commands
    {
        public void Listen()
        {
            string line = Console.ReadLine();

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


                    case Dictionary.COMMAND_SERVER_DATE:
                        {
                            this.OnServerDate();
                            break;
                        }

                    default:
                        {
                            Providers.Monolit.Writeable("Команда не распознана !").Error();
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
    }
}
