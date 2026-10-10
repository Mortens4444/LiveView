namespace LiveView.WebApi.Dto
{
    public record LoginRequest
    {
        public string? Username { get; set; }

        public string? Password { get; set; }
    }
}
