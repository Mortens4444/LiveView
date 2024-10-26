using System.ComponentModel;

namespace Mtf.Enums.Game
{
    public enum ColourEnum
    {
        [Description("Trèfle")]
        Clover = 0,
        [Description("Carreau")]
        Tile = 1,
        [Description("Cœur")]
        Heart = 2,
        [Description("Pique")]
        Pike = 3,
    }
}
