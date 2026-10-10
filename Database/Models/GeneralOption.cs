using Database.Enums;

namespace Database.Models
{
    public class GeneralOption : Mtf.Database.Interfaces.IHasIdentifier<string>
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public OptionType TypeId { get; set; }

        public string Id
        {
            get => Name;
            set => Name = value;
        }

        public override string ToString()
        {
            return $"{Name}: {Value} ({TypeId})";
        }
    }
}
