using LiveView.Core.Services;
using Mtf.Network;
using Mtf.Network.EventArg;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        private static Client client;

        private static readonly Dictionary<long, Process> cameraProcesses = new Dictionary<long, Process>();
        private static readonly Dictionary<long, Process> sequenceProcesses = new Dictionary<long, Process>();

        static void Main(string[] args)
        {
            var serverIp = ConfigurationManager.AppSettings["LiveViewServer.IpAddress"];

            var listenerPort = ConfigurationManager.AppSettings["LiveViewServer.ListenerPort"];
            if (UInt16.TryParse(listenerPort, out var serverPort))
            {
                while (true)
                {
                    try
                    {
                        client = new Client(serverIp, serverPort);
                        client.DataArrived += ClientDataArrivedEventHandler;
                        client.Connect();

                        Console.WriteLine($"Connected to server {serverIp}:{serverPort}.");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Connection failed: {ex}");
                        Thread.Sleep(5000);
                    }
                }

                Console.WriteLine("Press Ctrl+C to exit.");
                while (true)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        private static void ClientDataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            try
            {
                var message = $"{client?.Encoding.GetString(e.Data)}";
                var messageParts = message.Split('|');

                if (message.StartsWith("Camera.exe|", StringComparison.InvariantCulture))
                {
                    StartProcess(messageParts, cameraProcesses);
                }
                else if (message.StartsWith("Sequence.exe|", StringComparison.InvariantCulture))
                {
                    StartProcess(messageParts, sequenceProcesses);
                }
                else if (message.StartsWith("Kill|", StringComparison.InvariantCulture))
                {
                    long id = Convert.ToInt64(messageParts[2], CultureInfo.InvariantCulture);
                    switch (messageParts[1])
                    {
                        case "Camera.exe":
                            cameraProcesses[id].Kill();
                            break;
                        case "Sequence.exe":
                            sequenceProcesses[id].Kill();
                            break;
                    }
                }
                else if (message.StartsWith("KillAll|", StringComparison.InvariantCulture))
                {
                    switch (messageParts[1])
                    {
                        case "Camera.exe":
                            foreach (var process in cameraProcesses.Values)
                            {
                                process.Kill();
                            }
                            break;
                        case "Sequence.exe":
                            foreach (var process in sequenceProcesses.Values)
                            {
                                process.Kill();
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Message parse or execution failed: {ex}");
            }
        }

        private static void StartProcess(string[] messageParts, Dictionary<long, Process> processes)
        {
            var process = AppStarter.Start(messageParts[0], messageParts[1]);
            var parameters = messageParts[1].Split();
            var id = Convert.ToInt64(parameters[1], CultureInfo.InvariantCulture);
            processes.Add(id, process);
        }
    }
}