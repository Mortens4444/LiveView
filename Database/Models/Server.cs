using Database.Interfaces;
using System;

namespace Database.Models
{
    public class Server : IHaveId<long>, IEquatable<Server>
    {
        public long Id { get; set; }

        public string IpAddress { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string MacAddress { get; set; }

        public string Hostname { get; set; }

        public string DongleSn { get; set; }

        public string SerialNumber { get; set; }

        public string WinUser { get; set; }

        public string WinPass { get; set; }

        public bool StartInMotionPopup { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Server other && Equals(other);
        }

        public bool Equals(Server other)
        {
            return other == null ? false : Id == other.Id;
        }
        public override string ToString()
        {
            return Hostname;
        }
    }
}
