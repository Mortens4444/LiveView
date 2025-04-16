using Database.Models;
using LiveView.Core;
using LiveView.Core.Dto;
using LiveView.Dto;
using LiveView.Forms;
using Mtf.HardwareKey.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using NetworkServer = Mtf.Network.Server;

namespace LiveView
{
    public static class Globals
    {
        public readonly static ObservableDictionary<Socket, Dictionary<string, string>> VideoCaptureSources = new ObservableDictionary<Socket, Dictionary<string, string>>();

        public readonly static Dictionary<string, int> CameraProcesses = new Dictionary<string, int>(); // Agent IP address:port, Camera process Id

        public readonly static ConcurrentDictionary<string, SequenceProcessInfo> SequenceProcesses = new ConcurrentDictionary<string, SequenceProcessInfo>();

        public readonly static ConcurrentDictionary<Socket, CameraProcessInfo> CameraProcessInfo = new ConcurrentDictionary<Socket, CameraProcessInfo>();

        public static ObservableDictionary<string, Socket> Agents { get; } = new ObservableDictionary<string, Socket>(); // Agent IP address:port, Agent socket

        public readonly static Dictionary<string, DateTimeOffset> AgentPingTimes = new Dictionary<string, DateTimeOffset>(); // Agent IP address:port, last ping time

        public static string Uptime { get; set; }

        public static string SystemUptime { get; set; }

        public static string Day { get; set; }

        public static string Days { get; set; }

        public static ISltHardwareKey HardwareKey { get; set; }

        public static ControlCenter ControlCenter { get; set; }

        public static DisplayDto FullScreenDisplay { get; set; }

        public static UserEvent UserEvent { get; set; }
        
        public static NetworkServer Server { get; set; }
    }
}
