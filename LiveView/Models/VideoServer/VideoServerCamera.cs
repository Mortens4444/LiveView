using Database.Interfaces;

namespace LiveView.Models.VideoServer
{
    public class VideoServerCamera : IHaveGuid
    {
        public string Guid { get; set; }

        public string Name { get; set; }

        public object Status { get; set; }
    }
}
