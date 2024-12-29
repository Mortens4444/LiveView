using Database.Interfaces;

namespace Database.Models
{
    public class CameraRight : IHaveId<long>
    {
        public long Id { get; set; }

        public long? CameraId { get; set; }

        public long? UserEventId { get; set; }

        public long GroupId { get; set; }
    }
}
