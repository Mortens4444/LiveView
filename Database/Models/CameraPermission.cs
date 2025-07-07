using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class CameraPermission : IHaveId<int>
    {
        public int Id { get; set; }

        public int? CameraId { get; set; }

        public int? UserEventId { get; set; }

        public int GroupId { get; set; }
    }
}
