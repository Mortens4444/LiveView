using LiveView.Agent.Dto;
using LiveView.Core.Enums.Network;
using LiveView.Core.Interfaces;
using Microsoft.Extensions.Logging;
using Mtf.Network;
using System;
using System.Collections.Generic;

namespace LiveView.Agent.Network.Commands
{
    public class StartCameraProcessCommand : StartProcessCommand, ICommand
    {
        private readonly Dictionary<long, ProcessInfo> cameraProcesses;
        private readonly Client client;
        private readonly string message;
        private readonly string[] messageParts;

        public StartCameraProcessCommand(Dictionary<long, ProcessInfo> cameraProcesses, Client client, string message, string[] messageParts, ILogger<LiveViewConnector> logger) : base(logger)
        {
            this.cameraProcesses = cameraProcesses;
            this.client = client;
            this.message = message;
            this.messageParts = messageParts;
        }

        public void Execute()
        {
            Console.WriteLine($"Starting process {Database.Constants.CameraAppExe} ({message}).");
            var cameraProcessId = StartProcess(messageParts, cameraProcesses);
            Console.WriteLine($"Process started with PID: {cameraProcessId}.");

            Console.WriteLine("Sending process ID...");
            _ = client.SendAsync($"{NetworkCommand.SendCameraProcessId}|{cameraProcessId}", true);
            Console.WriteLine("Process ID sent.");
        }
    }
}
