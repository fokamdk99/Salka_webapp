

namespace Salka.WebApp.Client.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public static class NetworkClientFactory
    {
        public static INetwork GetNetworkClient(string serviceHost, int servicePort)
        {
            //const string serviceHost = "localhost";
            //const int servicePort = 6001;

            //const string serviceHost = "app_webservicerest";
            //const int servicePort = 80;

            return new NetworkClient(serviceHost, servicePort);
        }
        
    }
}
