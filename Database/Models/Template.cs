using Database.Interfaces;

namespace Database.Models
{
    public class Template : IHaveId<long>
    {
        public long Id { get; set; }

        public string TemplateName { get; set; }

        public override string ToString()
        {
            return TemplateName;
        }
    }
}
