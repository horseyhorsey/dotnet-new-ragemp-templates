using System;
using System.Linq;
using GTANetworkAPI;

namespace Company.RageMpServerResource
{
    public class Main : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void ResourceStart()
        {
            NAPI.Util.ConsoleOutput("Script running");
        }
        
        [Command]
        public static void TestCmd(Client sender, int optionparam) // Method must be static!
        {
            NAPI.Util.ConsoleOutput($"TestCmd with params {optionparam}");            
        }
    }
}