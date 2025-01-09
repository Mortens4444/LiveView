using Database.Interfaces;

namespace Database.Models
{
    public class UserEvent : IHaveId<long>
    {
        public long Id { get; set; }

        public long LanguageElementId { get; set; }

        public string Note { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
