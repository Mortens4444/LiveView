using System.Drawing;

namespace CameraForms.Dto
{
    public class OsdSettings
    {
        public float LargeFontSize { get; set; }
        
        public float SmallFontSize { get; set; }

        public string FontName { get; set; }

        public Color FontColor { get; set; }

        public Color ShadowColor { get; set; }

        public SolidBrush FontBrush => new SolidBrush(FontColor);

        public Font OverlayFont => new Font(FontName, LargeFontSize, FontStyle.Bold);

        public Font OverlaySmallFont => new Font(FontName, SmallFontSize, FontStyle.Bold);
    }
}
