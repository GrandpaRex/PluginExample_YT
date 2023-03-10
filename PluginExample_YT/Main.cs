using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using FivePD.API;
using FivePD.API.Utils;

#pragma warning disable 1998
namespace PluginExample_YT
{
    public class Main : Plugin
    {
        internal Main()
        {
            _ = Command();
        }

        internal async Task Command()
        {
            RegisterCommand("minfo", new Action<int, List<object>, string>((source, args, rawCommand) =>
            {
                //Get Player data
                PlayerData pdata = Utilities.GetPlayerData();

                //Assign all data to variables
                string badge = pdata.Callsign;
                string dept = pdata.DepartmentShortName;
                int deptid = pdata.DepartmentID;
                string deptln = pdata.Department;
                string rank = pdata.Rank;
                string pname = pdata.DisplayName;

                //Trigger a chat message
                TriggerEvent("chat:addMessage", new
                {
                    color = new[] {178,190,181},
                    args = new[] {$"{badge} {pname}, {rank} | {deptln} | {deptid} {dept}"}
                });
            }), false);
        }
    }
}
