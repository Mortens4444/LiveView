using System;
using System.Net.Sockets;

namespace LiveView.Dto
{
    public class SequenceProcessInfo
    {
        public Database.Models.Agent Agent { get; set; }

        public Socket SequenceSocket { get; set; }

        public long UserId { get; set; }

        public long? SequenceId { get; set; }

        public long DisplayId { get; set; }

        public bool IsMdi { get; set; }

        public int ProcessId { get; set; }

        public bool IsLocalSequence => Agent == null;

        public string GetDisplayId()
        {
            return Agent != null ? String.Concat(DisplayId.ToString(), Agent.ServerIp, ":", Agent.AgentPort) : DisplayId.ToString();
        }
    }
}
