using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class Template : IHaveId<int>
    {
        public int Id { get; set; }

        public string TemplateName { get; set; }

        public override string ToString()
        {
            return TemplateName;
        }
    }
}
