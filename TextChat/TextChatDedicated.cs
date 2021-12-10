using NetworkedPlugins.API;
using NetworkedPlugins.API.Enums;
using NetworkedPlugins.API.Models;
using System;
using System.Collections.Generic;

namespace TextChat
{
    public class TextChatDedicated : NPAddonDedicated<AddonConfig, AddonConfig>
    {
        public override string AddonAuthor { get; } = "Killers0992";
        public override string AddonId { get; } = "mg4vj5MqbV3CaA3j";
        public override string AddonName { get; } = "TextChat";
        public override Version AddonVersion { get; } = new Version(1, 0, 0);

        public static TextChatDedicated singleton;

        public override NPPermissions Permissions { get; } = new NPPermissions()
        {
            ReceivePermissions = new List<AddonSendPermissionTypes>() 
            { 
                AddonSendPermissionTypes.PlayerNickname,
                AddonSendPermissionTypes.PlayerRankName,
                AddonSendPermissionTypes.PlayerRankColor
            },
            SendPermissions = new List<AddonReceivePermissionTypes>() 
            { 
                AddonReceivePermissionTypes.GameConsoleNewCommands,
                AddonReceivePermissionTypes.GameConsoleMessages,
            },
        };

        public override void OnEnable()
        {
            singleton = this;
            base.OnEnable();
        }
    }
}
