using Mtf.Database.Interfaces;
using System;

namespace Database.Models
{
    public class BarcodeScanReading : IHaveId<long>
    {
        public long Id { get; set; }
        
        public DateTime Date { get; set; }

        public string Value { get; set; }
    }
}
