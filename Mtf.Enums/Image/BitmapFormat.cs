namespace Mtf.Enums.Image
{
    public enum BitmapFormat : uint
    {
        BI_RGB = 0x00000000,
        RGB = 0x32424752,
        BI_RLE8 = 0x00000001,
        RLE8 = 0x38454C52,
        BI_RLE4 = 0x00000002,
        RLE = 0x34454C52,
        BI_BITFIELDS = 0x00000003,
        raw = 0x32776173,
        RGBA = 0x41424752,
        RGBT = 0x54424752
    }
}
