using Mtf.Database.Interfaces;

namespace Database.Models
{
    public class BarcodeCharChanger : IHaveId<long>
    {
        public long Id { get; set; }

        public string Chars { get; set; }
    }
}
