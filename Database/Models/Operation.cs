using Database.Interfaces;

namespace Database.Models
{
    public class Operation : IHaveId<long>
    {
        public long Id { get; set; }

        public long LanguageElementId { get; set; }

        public string Note { get; set; }
    }
}
