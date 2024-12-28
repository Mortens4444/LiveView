using Database.Interfaces;
using System;

namespace Database.Models
{
    public class User : IHaveId<long>
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }
        
        public string Email { get; set; }

        public string Phone { get; set; }
        
        public string LicensePlate { get; set; }
        
        public string Barcode { get; set; }
        
        public string OtherInformation { get; set; }
        
        public byte[] Image { get; set; }
        
        public int SecondaryLogonPriority { get; set; }

        public int NeededSecondaryLogonPriority { get; set; }

        public override string ToString()
        {
            var result = string.Empty;

            if (!String.IsNullOrWhiteSpace(Username))
            {
                result += $"{Username}{Environment.NewLine}";
            }

            if (!String.IsNullOrWhiteSpace(Phone))
            {
                result += $"{Phone}{Environment.NewLine}";
            }

            if (!String.IsNullOrWhiteSpace(Email))
            {
                result += $"{Email}{Environment.NewLine}";
            }

            if (!String.IsNullOrWhiteSpace(Address))
            {
                result += $"{Address}{Environment.NewLine}";
            }

            return result.TrimEnd(Environment.NewLine.ToCharArray());
        }
    }
}
