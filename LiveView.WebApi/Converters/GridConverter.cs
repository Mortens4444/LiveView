using Database.Models;
using LiveView.WebApi.Dto;
using LiveView.WebApi.Interfaces;

namespace LiveView.WebApi.Converters
{
    public class GridConverter : IConverter<Grid, GridDto>
    {
        /// <summary>
        /// Converts a Database.Models.Grid object to a GridDto object.
        /// </summary>
        /// <param name="model">The source Grid model.</param>
        /// <returns>The converted GridDto, or null if the source is null.</returns>
        public GridDto? ToDto(Grid? model)
        {
            if (model == null)
            {
                return null;
            }

            return new GridDto
            {
                Id = model.Id,
                Rows = model.Rows,
                Columns = model.Columns,
                PixelsFromRight = model.PixelsFromRight,
                PixelsFromBottom = model.PixelsFromBottom,
                Name = model.Name,
                Priority = model.Priority
            };
        }

        /// <summary>
        /// Converts a GridDto object to a Database.Models.Grid object.
        /// </summary>
        /// <param name="dto">The source GridDto.</param>
        /// <returns>The converted Database.Models.Grid, or null if the source DTO is null.</returns>
        public Grid? ToModel(GridDto? dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Grid
            {
                Id = dto.Id,
                Rows = dto.Rows,
                Columns = dto.Columns,
                PixelsFromRight = dto.PixelsFromRight,
                PixelsFromBottom = dto.PixelsFromBottom,
                Name = dto.Name,
                Priority = dto.Priority
            };
        }
    }
}
