using System;
using System.Net;
using System.Threading.Tasks;

namespace SoloPublicLobby.Helpers
{
    public class IPTool
    {
        /// <summary>
        /// Gets the hosts IP Address.
        /// </summary>
        /// <returns>String value of IP.</returns>
        public async Task<string> GetPublicIp()
        {
            // Still needs check to see if we could retrieve the IP.
            // Try for ipv6 first, but if that fails get ipv4
            Exception ex;
            try
            {
                return await new WebClient().DownloadStringTaskAsync("https://ipv6.icanhazip.com");
            }
            catch
            {
            }

            //ErrorLogger.LogException(e);
            //IPv4 Mode
            try
            {
                return await new WebClient().DownloadStringTaskAsync("https://ipv4.icanhazip.com");
            }
            catch (Exception e)
            {
                ex = e;
            }

            ErrorLogger.LogException(ex);
            return "IP not found.";
        }

        public static bool ValidateIP(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            IPAddress address;
            if (IPAddress.TryParse(ipString, out address))
            {
                switch (address.AddressFamily)
                {
                    case System.Net.Sockets.AddressFamily.InterNetwork:
                        // we have IPv4 
                        return true;
                    case System.Net.Sockets.AddressFamily.InterNetworkV6:
                        // we have IPv6
                        return true;
                }
            }
            return false;
        }
    }
}
