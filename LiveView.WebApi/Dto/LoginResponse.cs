namespace LiveView.WebApi.Dto
{
    public record LoginResponse
    {
        public string Token { get; set; } = string.Empty;

        public DateTime ExpiresAt { get; set; }
    }
}
