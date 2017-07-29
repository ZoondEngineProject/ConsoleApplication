using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Vendor.EP.Shifter.Packets
{
    class Actions
    {
        public void OnPacketSendMsgShutdowned()
        {
            //
        }

        public void OnPacketReceiveMsgShutdown()
        {
            Providers.Eloquent.Inject("this shutdown");
        }
    }
}
