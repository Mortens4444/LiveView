using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class UserGroup : IHaveId<long>
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long GroupId { get; set; }
    }
}
