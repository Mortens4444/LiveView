using LiveView.Core.Dto;
using System.Collections.Generic;
using System.Drawing;

namespace LiveView.Interfaces
{
    public interface IBaseDisplayView : IView
    {
        List<DisplayDto> CachedDisplays { get; }

        Dictionary<int, Rectangle> CachedBounds { get; }
    }
}
