using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using Microsoft.Extensions.Logging;
using Mtf.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LiveView.Agent.Network.Commands
{
    public class StartCameraProcessCommand : StartProcessCommand, ICommand
    {
        private readonly Dictionary<long, Process> cameraProcesses;
        private readonly Client client;
        private readonly string message;
        private readonly string[] messageParts;

        public StartCameraProcessCommand(Dictionary<long, Process> cameraProcesses, Client client, string message, string[] messageParts, ILogger<LiveViewConnector> logger) : base(logger)
        {
            this.cameraProcesses = cameraProcesses;
            this.client = client;
            this.message = message;
            this.messageParts = messageParts;
        }

        public void Execute()
        {
            Console.WriteLine($"Starting process {Core.Constants.CameraAppExe} ({message}).");
            var cameraProcessId = StartProcess(messageParts, cameraProcesses);
            Console.WriteLine($"Process started with PID: {cameraProcessId}.");

            Console.WriteLine("Sending process ID...");
            _ = client.SendAsync($"{NetworkCommand.SendCameraProcessId}|{cameraProcessId}", true);
            Console.WriteLine("Process ID sent.");
        }
    }
}
