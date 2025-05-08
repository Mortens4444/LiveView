using Mtf.Database.Interfaces;

namespace Database.Models
{
    public class Migration : IHaveId<long>
    {
        public long Id { get; private set; }

        public string Name { get; set; }
    }
}
