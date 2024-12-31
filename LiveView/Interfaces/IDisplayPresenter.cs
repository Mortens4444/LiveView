using LiveView.Core.Dto;
using LiveView.Dto;
using System.Collections.Generic;
using System.Drawing;

namespace LiveView.Interfaces
{
    public interface IDisplayPresenter
    {
        Point GetMouseLocation(Size size);

        List<DisplayDto> GetDisplays();

        Dictionary<int, Rectangle> GetScaledDisplayBounds(List<DisplayDto> displays, Size size);

        List<SequenceEnvironment> GetSequenceEnvironments();
    }
}
