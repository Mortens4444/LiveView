using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class DatabaseServer : IHaveId<int>
    {
        public int Id { get; set; }

        public string IpAddress { get; set; }

        public string Hostname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string MacAddress { get; set; }

        public string DbName { get; set; }

        public int DbPort { get; set; }

        public override string ToString()
        {
            return Hostname;
        }
    }
}
