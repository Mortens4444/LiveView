using Database.Interfaces;

namespace Database.Models
{
    public class VideoSource : IHaveId<long>
    {
        public long Id { get; set; }

        public string ServerIp { get; set; }

        public string VideoSourceName { get; set; }
    }
}
