using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class UserEvent : IHaveId<int>
    {
        public int Id { get; set; }

        public string Note { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
