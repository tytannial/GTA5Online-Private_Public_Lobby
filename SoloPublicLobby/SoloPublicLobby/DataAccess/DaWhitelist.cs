﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using SoloPublicLobby.Helpers;
using SoloPublicLobby.Models;

namespace SoloPublicLobby.DataAccess
{
    public class DaWhitelist
    {
        private static string path = AppDomain.CurrentDomain.BaseDirectory + "settings.json";

        public static List<IPAddress> ReadIPsFromJSON()
        {
            List<IPAddress> addresses = new List<IPAddress>();

            if(!File.Exists(path))
            {
                SaveToJson(new MWhitelist());
            }

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                MWhitelist whitelist = JsonConvert.DeserializeObject<MWhitelist>(json);
                foreach (string address in whitelist.Ips)
                {
                    if (IPTool.ValidateIP(address.ToString())) addresses.Add(IPAddress.Parse(address));
                }
            }
            return addresses;
        }

        public static void SaveToJson(MWhitelist whitelist)
        {
            string json = JsonConvert.SerializeObject(whitelist);
            File.WriteAllText(path, json);
        }
    }
}
