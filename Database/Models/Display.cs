namespace Database.Models
{
    public class Display
    {
        public int Id { get; set; }

        public string PnPDeviceId { get; set; }

        public string ShownName { get; set; }

        public bool FullscreenDisplay { get; set; }
        
        public bool CanShowSequence { get; set; }

        public bool CanShowFullscreen { get; set; }
    }
}
