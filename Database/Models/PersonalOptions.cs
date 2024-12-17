using Database.Enums;

namespace Database.Models
{
    public class PersonalOptions
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public int UserId { get; set; }

        public OptionType Type { get; set; }

    }
}
