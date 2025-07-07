using Mtf.Extensions.Interfaces;
using System;

namespace Database.Models
{
    public class BarcodeScanReading : IHaveId<int>
    {
        public int Id { get; set; }
        
        public DateTime Date { get; set; }

        public string Value { get; set; }
    }
}
