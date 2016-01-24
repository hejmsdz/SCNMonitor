using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SCNMonitor
{
    class NetworkChecker
    {
        private bool state;
        public bool State
        {
            get
            {
                return state;
            }
            private set
            {
                state = value;
            }
        }

        public event EventHandler StateChanged;

        public NetworkChecker()
        {
            NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(OnAddressChanged);
        }

        public void Check(bool forceBroadcast = false)
        {
            bool newState = false;
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface n in adapters)
            {
                if (n.NetworkInterfaceType == NetworkInterfaceType.Ethernet && n.OperationalStatus == OperationalStatus.Up && n.GetIPProperties().DnsSuffix == "hstl.put.poznan.pl")
                {
                    newState = true;
                }
            }

            if (newState != state || forceBroadcast)
            {
                state = newState;
                StateChanged(this, EventArgs.Empty);
            }
        }

        private void OnAddressChanged(object sender, EventArgs e)
        {
            Check();
        }
    }
}
