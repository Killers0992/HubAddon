using NetworkedPlugins.API;
using NetworkedPlugins.API.Enums;
using NetworkedPlugins.API.Models;
using System;
using System.Collections.Generic;

namespace HubAddon
{
    public class HubAddonDedicated : NPAddonDedicated<AddonConfig, AddonConfig>
    {
        public override string AddonAuthor { get; } = "Killers0992";
        public override string AddonId { get; } = "c6vKzQHnPQ9JhRwb";
        public override string AddonName { get; } = "Hub";
        public override Version AddonVersion { get; } = new Version(1, 0, 0);

        public static HubAddonDedicated singleton;

        public override NPPermissions Permissions { get; } = new NPPermissions()
        {
            ReceivePermissions = new List<AddonSendPermissionTypes>(),
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
