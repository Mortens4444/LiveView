using Database.Interfaces;

namespace Database.Models
{
    public class Display : IHaveId<int>
    {
        public int Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int MaxWidth { get; set; }

        public int MaxHeight { get; set; }

        public string DeviceName { get; set; }

        public string MonitorName { get; set; }

        public string AdapterName { get; set; }

        public string SziltechId { get; set; }

        public bool IsPrimary { get; set; }

        public bool Removable { get; set; }

        public bool AttachedToDesktop { get; set; }

        public bool Fullscreen { get; set; }
        
        public bool CanShowSequence { get; set; }

        public bool CanShowFullscreen { get; set; }

        public long? AgentId { get; set; }
    }
}
