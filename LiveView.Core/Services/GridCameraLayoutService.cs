using Database.Models;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Display;
using System.Drawing;

namespace LiveView.Core.Services
{
    public static class GridCameraLayoutService
    {
        public static Rectangle Get(DisplayDto display, Grid grid, GridCamera gridCamera, LocationType locationType = LocationType.Window)
        {
            var width = display.MaxWidth - grid.PixelsFromRight;
            var height = display.MaxHeight - grid.PixelsFromBottom;

            var unitWidth = width / grid.Columns;
            var unitHeight = height / grid.Rows;

            var fromRow = gridCamera.MatrixRegion.FromRow;
            var fromColumn = gridCamera.MatrixRegion.FromColumn;
            var toRow = gridCamera.MatrixRegion.ToRow;
            var toColumn = gridCamera.MatrixRegion.ToColumn;

            var calculatedLocation = new Point(fromColumn * unitWidth, fromRow * unitHeight);
            var calculatedSize = new Size((toColumn - fromColumn + 1) * unitWidth, (toRow - fromRow + 1) * unitHeight);

            var location = gridCamera.Left.HasValue && gridCamera.Top.HasValue
                ? new Point(gridCamera.Left.Value, gridCamera.Top.Value)
                : calculatedLocation;

            var size = gridCamera.Width.HasValue && gridCamera.Height.HasValue
                ? new Size(gridCamera.Width.Value, gridCamera.Height.Value)
                : calculatedSize;

            if (locationType == LocationType.Window)
            {
                return new Rectangle(location, size);
            }

            var screenLocation = new Point(location.X + display.X, location.Y + display.Y);
            return new Rectangle(screenLocation, size);
        }
    }
}
