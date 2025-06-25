using Database.Models;
using LiveView.Web.Services;
using LiveView.WebApi.Dto;

namespace LiveView.WebApi.Converters
{
    /// <summary>
    /// Converts between Database.Models.Agent and LiveView.WebApi.Dto.AgentDto.
    /// Handles the mapping of properties between the database model and the DTO.
    /// </summary>
    public class AgentConverter : BaseConverter<Agent, AgentDto>
    {
    }
}
