using LiveView.Core.Dto;
using LiveView.Dto;
using LiveView.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace LiveView.Interfaces
{
    public interface IDisplayPresenter
    {
        Point GetMouseLocation(Size size);

        List<DisplayDto> GetDisplays();

        Dictionary<string, Rectangle> GetScaledDisplayBounds(List<DisplayDto> displays, Size size);

        List<SequenceEnvironment> GetSequenceEnvironments();

        (Pen, SolidBrush) GetDrawingTools(DisplayDto display, DisplayDrawingTools displayDrawingTools);
    }
}
