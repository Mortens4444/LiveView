namespace Database.Models
{
    public class PersonalOption : GeneralOption
    {
        public long UserId { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Value} ({UserId}, {TypeId})";
        }
    }
}
