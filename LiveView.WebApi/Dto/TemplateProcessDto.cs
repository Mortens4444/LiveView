using Mtf.Extensions.Interfaces;
using System.Text.Json.Serialization;

namespace LiveView.WebApi.Dto
{
    public record TemplateProcessDto : IHaveIdWithSetter<long>
    {
        public long Id { get; set; }

        public long TemplateId { get; set; }

        public long? AgentId { get; set; }

        public string ProcessName { get; set; }

        public string ProcessParameters { get; set; }

        public override string ToString()
        {
            return String.Concat(ProcessName, " ", ProcessParameters);
        }

        [JsonPropertyName("html")]
        public string Html => ToHtml();

        public string ToHtml()
        {
            return $"<strong>Id: {Id}</strong><br>" +
                $"<small>TemplateId: {TemplateId}</small><br>" +
                $"<small>AgentId: {AgentId}</small><br>" +
                $"<small>ProcessName: {ProcessName}</small><br>" +
                $"<small>ProcessParameters: {ProcessParameters}</small>";
        }
    }
}
