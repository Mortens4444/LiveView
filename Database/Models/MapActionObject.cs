namespace Database.Models;

public class MapActionObject : Mtf.Database.Interfaces.IHasIdentifier<int>
{
    public int Id { get; set; }

    public int ActionObjectId { get; set; }

    public int MapId { get; set; }
}
