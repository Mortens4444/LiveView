using LiveView.WebApi.Dto;
using Database.Models;

namespace LiveView.WebApi.Converters
{
    public class GridConverter
    {
        public GridDto? ToDto(Grid grid)
        {
            if (grid == null)
            {
                return null;
            }

            return new GridDto
            {
                Id = grid.Id,
                Rows = grid.Rows,
                Columns = grid.Columns,
                PixelsFromRight = grid.PixelsFromRight,
                PixelsFromBottom = grid.PixelsFromBottom,
                Name = grid.Name,
                Priority = grid.Priority
            };
        }

        public Grid? ToModel(GridDto grid)
        {
            if (grid == null)
            {
                return null;
            }

            return new Grid
            {
                Id = grid.Id,
                Rows = grid.Rows,
                Columns = grid.Columns,
                PixelsFromRight = grid.PixelsFromRight,
                PixelsFromBottom = grid.PixelsFromBottom,
                Name = grid.Name,
                Priority = grid.Priority
            };
        }
    }
}
