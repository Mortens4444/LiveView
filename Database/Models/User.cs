namespace Database.Models
{
    public class User
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }
        
        public string Email { get; set; }

        public string Telephone { get; set; }
        
        public string LicensePlateNumber { get; set; }
        
        public string Barcode { get; set; }
        
        public string OtherInformation { get; set; }
        
        public byte[] Image { get; set; }
        
        public int SecondaryLogonPriority { get; set; }

        public int NeededSecondaryLogonPriority { get; set; }
    }
}
