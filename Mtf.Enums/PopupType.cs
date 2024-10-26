using System;

namespace Mtf.Enums
{
    [Flags]
    public enum PopupType : byte
    {
        None = 0,
        MotionPopup = 1,
        IOPopup = 2,
        IOPopupAndMotionPopup = MotionPopup | IOPopup
    }
}
