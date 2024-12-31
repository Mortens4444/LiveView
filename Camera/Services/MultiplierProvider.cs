namespace CameraApp.Services
{
    public static class MultiplierProvider
    {
        private const int Limit1 = 16;
        private const int Limit2 = 32;
        private const int Limit3 = 48;

        private const int Kbd300AMoveMultiplier1 = 100;
        private const int Kbd300AMoveMultiplier2 = 120;
        private const int Kbd300AMoveMultiplier3 = 140;
        private const int Kbd300AMoveMultiplier4 = 180;

        public static int GetMultiplier(int value)
        {
            return value < Limit1 ? Kbd300AMoveMultiplier1
                : value > Limit3 ? Kbd300AMoveMultiplier4
                : (value > Limit1) && (value < Limit2) ? Kbd300AMoveMultiplier2 : Kbd300AMoveMultiplier3;
        }
    }
}
