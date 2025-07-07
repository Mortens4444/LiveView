using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class Migration : IHaveId<int>
    {
        public int Id { get; private set; }

        public string Name { get; set; }
    }
}
