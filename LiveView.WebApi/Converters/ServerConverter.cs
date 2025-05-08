using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;

namespace LiveView.WebApi.Converters
{
    public class ServerConverter : IConverter<Server, ServerDto>
    {
        public ServerDto? ToDto(Server? model)
        {
            if (model == null)
            {
                return null;
            }

            return new ServerDto
            {
                Id = model.Id,
                IpAddress = model.IpAddress,
                Username = model.Username,
                Password = model.Password,
                MacAddress = model.MacAddress,
                Hostname = model.Hostname,
                DongleSn = model.DongleSn,
                SerialNumber = model.SerialNumber,
                WinUser = model.WinUser,
                WinPass = model.WinPass,
                StartInMotionPopup = model.StartInMotionPopup
            };
        }

        public Server? ToModel(ServerDto? dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Server
            {
                Id = dto.Id,
                IpAddress = dto.IpAddress!,
                Username = dto.Username!,
                Password = dto.Password!,
                MacAddress = dto.MacAddress!,
                Hostname = dto.Hostname!,
                DongleSn = dto.DongleSn!,
                SerialNumber = dto.SerialNumber!,
                WinUser = dto.WinUser!,
                WinPass = dto.WinPass!,
                StartInMotionPopup = dto.StartInMotionPopup
            };
        }
    }
}
