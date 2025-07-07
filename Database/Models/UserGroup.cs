using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class UserGroup : IHaveId<int>
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int GroupId { get; set; }
    }
}
