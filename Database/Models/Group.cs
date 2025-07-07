using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class Group : IHaveId<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string OtherInformation { get; set; }

        public int? ParentGroupId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
