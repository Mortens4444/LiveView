using Mtf.Extensions.Interfaces;

namespace Database.Models;

public class Operation : IHaveId<int>, Mtf.Database.Interfaces.IHasIdentifier<int>
{
    public int Id { get; set; }

    public string PermissionGroup { get; set; }

    public string PermissionValue { get; set; }
}
