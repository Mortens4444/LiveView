using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using Mtf.Network;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiveView.Agent.Network.Commands
{
    public class RequestVideoCaptureSourcesCommand : ICommand
    {
        private readonly Client client;
        private readonly Dictionary<string, Server> cameraServers;

        public RequestVideoCaptureSourcesCommand(Client client, Dictionary<string, Server> cameraServers)
        {
            this.client = client;
            this.cameraServers = cameraServers;
        }

        public void Execute()
        {
            client.Send($"{NetworkCommand.VideoCaptureSourcesResponse}|{String.Join(";", cameraServers.Select(kvp => $"{kvp.Key}={kvp.Value}"))}", true);
        }
    }
}
