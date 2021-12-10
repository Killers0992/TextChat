using NetworkedPlugins.API;
using NetworkedPlugins.API.Enums;
using NetworkedPlugins.API.Interfaces;
using NetworkedPlugins.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChat.Commands
{
    public class GlobalCommand : ICommand
    {
        public string CommandName { get; } = "SG";

        public string Description { get; } = "Send global textchat message.";

        public string Permission { get; } = "";

        public CommandType Type { get; } = CommandType.GameConsole;

        public void Invoke(NPPlayer player, string[] arguments)
        {
            if (arguments.Length == 0)
            {
                player.SendConsoleMessage($"Syntax: .sg <message>", "Global TextChat");
                return;
            }

            string filterMessage = (string.Join(" ", arguments)).Replace("<", "＜").Replace(">", "＞").Replace("\n", string.Empty).Replace("\r", string.Empty).Trim();

            if (string.IsNullOrEmpty(filterMessage))
            {
                player.SendConsoleMessage($"Message cant be empty!", "Global TextChat", "RED");
                return;
            }

            foreach (var server in TextChatDedicated.singleton.GetAllServers())
            {
                var addon = server.GetAddon(TextChatDedicated.singleton.AddonId) as TextChatDedicated;

                foreach (var plr in server.Players)
                {
                    plr.SendConsoleMessage(addon.RemoteConfig.GlobalMessageFormat
                        .Replace("%serverName%", player.Server.ServerConfig.ServerName)
                        .Replace("%serverIp%", player.Server.ServerAddress)
                        .Replace("%serverPort%", player.Server.ServerPort.ToString())
                        .Replace("%nickname%", player.Nickname)
                        .Replace("%message%", filterMessage), "", "BLACK");
                }
            }
        }
    }
}
