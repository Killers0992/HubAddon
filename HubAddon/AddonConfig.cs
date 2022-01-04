using NetworkedPlugins.API.Interfaces;
using System;

namespace HubAddon
{
    public class AddonConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}
