using AxVIDEOCONTROL4Lib;
using Database.Models;
using Mtf.Controls.Video.ActiveX;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IMotionPopupView : IView
    {
        AxVideoPlayerWindow AxVideoPlayerWindow { get; }

        AxVideoPlayerWindow AxVideoPlayerWindow2 { get; }

        AxVideoMotion AxVideoMotion { get; }

        Camera Camera { get; }

        Camera PartnerCamera { get; }

        Panel PRight { get; }
    }
}
