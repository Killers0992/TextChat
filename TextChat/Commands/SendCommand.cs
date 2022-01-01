using NetworkedPlugins.API;
using NetworkedPlugins.API.Enums;
using NetworkedPlugins.API.Interfaces;
using NetworkedPlugins.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TextChat.Commands
{
    public class SendCommand : ICommand
    {
        public string CommandName { get; } = "S";

        public string Description { get; } = "Send textchat message.";

        public string Permission { get; } =  "";

        public CommandType Type { get; } = CommandType.GameConsole;

        public void Invoke(NPPlayer player, string[] arguments)
        {
            if (arguments.Length == 0)
            {
                player.SendConsoleMessage($"Syntax: .s <message>");
                return;
            }

            string filterMessage = (string.Join(" ", arguments)).Replace("<", "＜").Replace(">", "＞").Replace("\n", string.Empty).Replace("\r", string.Empty).Trim();

            if (string.IsNullOrEmpty(filterMessage))
            {
                player.SendConsoleMessage($"Message cant be empty!", "TextChat", "RED");
                return;
            }

            foreach (var server in TextChatDedicated.singleton.GetServers())
            {
                var addon = server.GetAddon<TextChatDedicated>(TextChatDedicated.singleton.AddonId);

                foreach(var plr in server.Players)
                {
                    plr.SendConsoleMessage(addon.RemoteConfig.LocalMessageFormat
                        .Replace("%serverName%", player.Server.ServerConfig.ServerName)
                        .Replace("%serverIp%", player.Server.ServerAddress)
                        .Replace("%serverPort%", player.Server.ServerPort.ToString())
                        .Replace("%rankColor%", player.RankColor)
                        .Replace("%rankName%", string.IsNullOrEmpty(player.RankName) ? "USER" : $"<b>{player.RankName.ToUpper()}</b>")
                        .Replace("%nickname%", player.Nickname)
                        .Replace("%message%", filterMessage), "", "BLACK");
                }
            }
        }
    }
}
