using NetworkedPlugins.API.Enums;
using NetworkedPlugins.API.Interfaces;
using NetworkedPlugins.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubAddon.Commands
{
    public class ChangeServerCommand : ICommand
    {
        public string CommandName { get; } = "CHANGESERVER";

        public string Description { get; } = "Change server.";

        public string Permission { get; } = "";

        public CommandType Type { get; } = CommandType.GameConsole;

        public void Invoke(NPPlayer player, string[] arguments)
        {
            var add = (HubAddonDedicated)player.Server.GetAddon(HubAddonDedicated.singleton.AddonId);

            if (arguments.Length == 0)
            {
                player.SendConsoleMessage($"<color=white>You can find avaliable servers under command <color=green>.servers</color>.</color>", "HUB", "BLACK");
                return;
            }

            var srvName = String.Join("", arguments);

            var targetServer = add.GetServers().FirstOrDefault(p => p.ServerName.ToUpper().Replace(" ", "") == srvName.ToUpper());

            if (targetServer == null)
            {
                player.SendConsoleMessage($"<color=white>Target server <color=green>{srvName}</color> is not online!</color>", "HUB", "BLACK");
                return;
            }

            if (targetServer.FullAddress == player.Server.FullAddress)
            {
                player.SendConsoleMessage($"<color=white>You are already connected to that server!</color>", "HUB", "BLACK");
                return;
            }

            if (targetServer.ServerAddress != player.Server.ServerAddress)
            {
                player.SendConsoleMessage($"<color=white>You cant change server if target server dont have same ip as current one!</color>", "HUB", "BLACK");
                return;
            }
            player.Redirect(targetServer.ServerPort);
            player.SendConsoleMessage($"<color=white>Connecting to server <color=green>{srvName}</color>...</color>", "HUB", "BLACK");
        }
    }
}
