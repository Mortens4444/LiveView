using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record VideoSourceDto : IHaveIdWithSetter<int>
    {
        public int Id { get; set; }

        public int AgentId { get; set; }

        public string Name { get; set; }

        public int Port { get; set; }

        public override string ToString()
        {
            return Name;
        }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>Id: {Id}</strong><br>" +
                $"<small>AgentId: {AgentId}</small><br>" +
                $"<small>Port: {Port}</small><br>" +
                $"<small>Name: {Name}</small>";
        }
    }
}
