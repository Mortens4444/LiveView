using System.ComponentModel;

namespace Mtf.Enums.Raid
{
    //[TypeConverter(typeof(EnclosureTypesConverter))]
    public enum EnclosureTypes
    {
        //[Description(Constants.LYING_EXTERNAL_5_HDD)]
        LyingExternal_5_HDD = 5,
        //[Description(Constants.LYING_EXTERNAL_10_HDD)]
        LyingExternal_10_HDD = 10,
        //[Description(Constants.LYING_INTERNAL_4_HDD)]
        LyingInternal_4_HDD = 4,
        //[Description(Constants.LYING_EXTERNAL_24_HDD)]
        LyingExternal_24_HDD = 24,
        //[Description(Constants.STANDING_EXTERNAL_4_HDD)]
        StandingExternal_4_HDD = 1,
        //[Description(Constants.STANDING_INTERNAL_4_HDD)]
        StandingInternal_4_HDD = 2,
        //[Description(Constants.LYING_EXTERNAL_8_HDD)]
        LyingExternal_8_HDD = 8
    }
}
