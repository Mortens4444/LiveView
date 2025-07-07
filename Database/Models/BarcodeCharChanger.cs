using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class BarcodeCharChanger : IHaveId<int>
    {
        public int Id { get; set; }

        public string Chars { get; set; }
    }
}
