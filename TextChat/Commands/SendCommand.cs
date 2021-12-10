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

            var playerOnServer = TextChatDedicated.singleton.GetServers().FirstOrDefault(p => p.GetPlayer(player.UserID) != null);
            if (playerOnServer == null)
                return;

            string filterMessage = (string.Join(" ", arguments)).Replace("<", "＜").Replace(">", "＞").Replace("\n", string.Empty).Replace("\r", string.Empty).Trim();

            if (string.IsNullOrEmpty(filterMessage))
            {
                player.SendConsoleMessage($"Message cant be empty!", "TextChat", "RED");
                return;
            }

            foreach (var server in TextChatDedicated.singleton.GetServers())
            {
                foreach(var plr in server.Players)
                {
                    plr.SendConsoleMessage(string.Concat(
                        $"<color=white>Server <color=green>{playerOnServer.ServerPort}</color></color>",
                        Environment.NewLine,
                        " ",
                        $"[<color={player.RankColor}>",
                        $"{(string.IsNullOrEmpty(player.RankName) ? "USER" : $"<b>{player.RankName.ToUpper()}</b>")}</color>]",
                        " ",
                        $"<color=white>{player.Nickname}</color> ",
                        $"<color=gray>»</color> ",
                        $"<color=white>{filterMessage}</color>"), "", "BLACK");
                }
            }
        }
    }
}
