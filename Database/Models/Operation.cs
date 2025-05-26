using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class Operation : IHaveId<long>
    {
        public long Id { get; set; }

        public string PermissionGroup { get; set; }

        public string PermissionValue { get; set; }
    }
}
