using System.ComponentModel;

namespace Mtf.Enums.HardwareKey
{
    public enum SubType
    {
        [Description("Sziltech Electronic Kft.")]
        Sziltech = 287,
        [Description("Unknown testable")] // Sziltech has one key
        Unknown_testable = 290,
        [Description("Vagyonvill Debrecen Kft.")]
        Vagyonvill = 387,
        [Description("Unknown")]
        Unknown = 1,
        [Description("Missing or unknown")]
        MissingOrUnknown = 0
    }
}
