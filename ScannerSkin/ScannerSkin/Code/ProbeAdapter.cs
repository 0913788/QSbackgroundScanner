using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerSkin.Code
{
    class ProbeAdapter
    {
        bool ActiveDevice = false;

        public ProbeAdapter()
        {
            SetWifiDevice();
        }

        private async void SetWifiDevice()
        {
            var access = await WiFiAdapter.RequestAccessAsync();
            if (access != WiFiAccessStatus.Allowed)
            {
                throw new Exception("WiFiAccessStatus not allowed");
            }
            else
            {
                var WifiDeviceScan = await WiFiAdapter.FindAllAdaptersAsync();
                if (WifiDeviceScan.Count >= 1)
                {
                    WifiDevice = WifiDeviceScan[0];
                    ActiveDevice = true;
                }
            }
        }
        private async void Scan()
        {
            if (ActiveDevice) await WifiDevice.ScanAsync();
            else return;
        }
    }
}
