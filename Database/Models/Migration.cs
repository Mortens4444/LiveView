using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class Migration : IHaveId<int>, Mtf.Database.Interfaces.IHasIdentifier<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
