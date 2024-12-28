namespace Database.Models
{
    public class Group
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string OtherInformation { get; set; }

        public long ParentGroupId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
