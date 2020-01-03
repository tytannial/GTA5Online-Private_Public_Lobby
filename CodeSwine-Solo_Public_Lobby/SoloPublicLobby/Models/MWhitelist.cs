using System.Collections.Generic;

namespace SoloPublicLobby.Models
{
    public class MWhitelist
    {
        public List<string> Ips { get; set; }

        public MWhitelist()
        {
            Ips = new List<string>();
        }
    }
}
