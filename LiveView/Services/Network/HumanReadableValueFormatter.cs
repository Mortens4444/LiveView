namespace LiveView.Services.Network
{
    public static class HumanReadableValueFormatter
    {
        public static string FormatValue(long sentDataPerSecond, bool bitPerSec)
        {
            var unit = bitPerSec ? "Bit" : "B";
            if (ChangeValue(ref sentDataPerSecond, ref unit, bitPerSec ? "KBit" : "KB"))
            {
                if (ChangeValue(ref sentDataPerSecond, ref unit, bitPerSec ? "MBit" : "MB"))
                {
                    ChangeValue(ref sentDataPerSecond, ref unit, bitPerSec ? "GBit" : "GB");
                }
            }
            return $"{sentDataPerSecond} {unit}/s";
        }

        private static bool ChangeValue(ref long value, ref string unit, string newUnit)
        {
            if (value >= 1024)
            {
                value /= 1024;
                unit = newUnit;
                return true;
            }
            return false;
        }
    }
}
