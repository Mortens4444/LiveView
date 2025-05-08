using Mtf.Database.Interfaces;

namespace Database.Models
{
    public class Right : IHaveId<long>
    {
        public long Id { get; set; }

        public long? OperationId { get; set; }

        public long? UserEvent { get; set; }

        public long GroupId { get; set; }
    }
}
