using Database.Enums;

namespace Database.Models
{
    public class GeneralOption
    {
        public string Name { get; set; }

        public string Value { get; set; }
        
        public OptionType TypeId { get; set; }
    }
}
