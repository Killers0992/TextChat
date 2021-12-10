using NetworkedPlugins.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChat
{
    public class RemoteAddonConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public string LocalMessageFormat { get; set; } = "<color=white>Server <color=green>%serverName%</color> (%serverIp%:%serverPort%)</color>\n [<color=%rankColor%>%rankName%</color>] <color=white>%nickname%</color> <color=gray>»</color> <color=white>%message%</color>";
        public string GlobalMessageFormat { get; set; } = "<color=white>Server <color=green>%serverName%</color> (%serverIp%:%serverPort%)</color>\n <color=white>%nickname%</color> <color=gray>»</color> <color=white>%message%</color>";
    }
}
