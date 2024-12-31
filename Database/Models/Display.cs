using Database.Interfaces;

namespace Database.Models
{
    public class Display : IHaveId<int>
    {
        public int Id { get; set; }

        public string PnPDeviceId { get; set; }

        public string MonitorName { get; set; }

        public string AdapterName { get; set; }

        public string SziltechId { get; set; }

        public bool Fullscreen { get; set; }
        
        public bool CanShowSequence { get; set; }

        public bool CanShowFullscreen { get; set; }
    }
}
