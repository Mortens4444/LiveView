using Database.Enums;

namespace Database.Models
{
    public class PersonalOption
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public long UserId { get; set; }

        public OptionType TypeId { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Value} ({UserId}, {TypeId})";
        }
    }
}
