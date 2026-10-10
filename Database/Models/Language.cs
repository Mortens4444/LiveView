namespace Database.Models
{
    public class Language : Mtf.Database.Interfaces.IHasIdentifier<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
