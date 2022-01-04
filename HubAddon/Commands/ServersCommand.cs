using NetworkedPlugins.API;
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
    public class ServersCommand : ICommand
    {
        public string CommandName { get; } = "SERVERS";

        public string Description { get; } = "Total servers.";

        public string Permission { get; } = "";

        public CommandType Type { get; } = CommandType.GameConsole;

        public void Invoke(NPPlayer player, string[] arguments)
        {
            List<string> servers = new List<string>();
            var add = (HubAddonDedicated)player.Server.GetAddon(HubAddonDedicated.singleton.AddonId);
            foreach(var srv in add.GetServers().OrderBy(p => p.FullAddress))
            {
                servers.Add($" - <color=green>{(string.IsNullOrEmpty(srv.ServerConfig.ServerName) ? "Default Name" : srv.ServerConfig.ServerName)}</color> (<color=yellow>{srv.PlayersDictionary.Count}</color>/<color=yellow>{srv.MaxPlayers}</color>)" + (srv.FullAddress == player.Server.FullAddress ? " <- <color=white>Current Server</color>" : ""));
            }
            player.SendConsoleMessage($"Servers \n{string.Join("\n", servers)}", "HUB", "BLACK");
        }
    }
}
