using LanguageService;

namespace LiveView.Services.VideoServer
{
    public static class VideoServerErrorHandler
    {
        public const int Success = 0;
        public const int WrongCameraName = 3001;
        public const int LowVirtualMemory = 3003;
        public const int ConnectionLost = 3004;
        public const int HardwareError = 3009;
        public const int WrongCredentials = 3012;
        public const int NetworkError = 3018;
        public const int ConnectionFailed = 3019;
        public const int PermissionError = 3026;

        public const int TimeoutErrorCode = 4000;
        public const int NoVideoServerCredentialsFound = 4001;
        public const int UnknownErrorOccurred = 4002;
        public const int NoResult = 4003;

        public static string GetMessage(int errorCode)
        {
            switch (errorCode)
            {
                case Success: return Lng.Elem("Operation successful");
                case WrongCameraName: return Lng.Elem("Wrong camera name");
                case LowVirtualMemory: return Lng.Elem("Virtual memory is too low");
                case ConnectionLost: return Lng.Elem("Connection has been lost");
                case HardwareError: return Lng.Elem("Hardware error");
                case WrongCredentials: return Lng.Elem("Wrong username or password");
                case NetworkError: return Lng.Elem("Network (RPC) error");
                case ConnectionFailed: return Lng.Elem("Remote Video Server appplication is not responding");
                case PermissionError: return Lng.Elem("Security permission error / Invalid version");
                case TimeoutErrorCode: return Lng.Elem("Connection timed out");
                case NoVideoServerCredentialsFound: return Lng.Elem("No video server credentials found");
                case UnknownErrorOccurred: return Lng.Elem("Unknown error occurred during connection");
                case NoResult: return Lng.Elem("No result");
                default: return $"{Lng.Elem("Unknown error")}: {errorCode}";
            }
        }
    }

}
