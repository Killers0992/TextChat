using NetworkedPlugins.API.Interfaces;
using System;

namespace TextChat
{
    public class AddonConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}
