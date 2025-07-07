using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class BarcodeScanOptions : IHaveId<int>
    {
        public int Id { get; set; }

        public int CustomIn { get; set; }

        public int CustomOut { get; set; }

        public int LcidIn { get; set; }

        public int LcidOut { get; set; }

        public int MaxDelay { get; set; }

        public int SelectedComPort { get; set; }
        
        public bool SerialScanner { get; set; }
    }
}
