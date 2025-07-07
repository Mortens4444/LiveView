using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class Permission : IHaveId<int>
    {
        public int Id { get; set; }

        public int? OperationId { get; set; }

        public int? UserEventId { get; set; }

        public int GroupId { get; set; }
    }
}
