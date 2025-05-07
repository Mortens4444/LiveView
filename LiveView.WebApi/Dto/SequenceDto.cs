namespace LiveView.WebApi.Dto
{
    public record SequenceDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public int? Priority { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
