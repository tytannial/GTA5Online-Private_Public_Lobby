using System;
using System.IO;
using System.Text;

namespace SoloPublicLobby.Helpers
{
    public class ErrorLogger
    {
        public static void LogException(Exception e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "error.log";
            using StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8);
            sw.WriteLine($"[{DateTime.Now.ToShortDateString()}] {e.Message}");
        }
    }
}