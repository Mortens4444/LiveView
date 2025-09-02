using LiveView.Core.Dto;
using System.Collections.Generic;
using System.Drawing;

namespace LiveView.Core.Interfaces
{
    public interface IDisplayManager
    {
        DisplayDimensions ScreensBounds { get; }

        double GetScaleFactor(Rectangle screenBounds, Size drawnSize);

        List<DisplayDto> GetAll();

        DisplayDto GetDisplay(string deviceName);

        Dictionary<string, Rectangle> GetScaledDisplayBounds(List<DisplayDto> displays, Size drawnSize);
    }
}