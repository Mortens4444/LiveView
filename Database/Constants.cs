namespace Database
{
    public static class Constants
    {
        public const string CameraAppExe = "CameraApp.exe";

        public const string SequenceExe = "Sequence.exe";

        // Configuration values

        public const string TopMost = "TopMost";
        public const string StartCameras = "StartCameras";
        public const string LiveViewServerIpAddress = "LiveView.Server.IpAddress";
        public const string LiveViewServerListenerPort = "LiveView.Server.ListenerPort";
        public const string LiveViewAgentImageCaptureServerFps= "LiveView.Agent.ImageCaptureServer.FPS";
        public const string LiveViewAgentHideConsoleWindow = "LiveView.Agent.HideConsoleWindow";
        public const string ShowDebugInfo = "ShowDebugInfo";

        public const string CameraPasswordCryptorKey = "CameraPasswordCryptorKey";
        public const string CameraPasswordCryptorIV = "CameraPasswordCryptorIV";
        public const string DatabaseServerPasswordCryptorKey = "DatabaseServerPasswordCryptorKey";
        public const string DatabaseServerPasswordCryptorIV = "DatabaseServerPasswordCryptorIV";
        public const string UserPasswordCryptorKey = "UserPasswordCryptorKey";
        public const string UserPasswordCryptorIV = "UserPasswordCryptorIV";
        public const string VideoServerPasswordCryptorKey = "VideoServerPasswordCryptorKey";
        public const string VideoServerPasswordCryptorIV = "VideoServerPasswordCryptorIV";
        public const string WindowsPasswordCryptorKey = "WindowsPasswordCryptorKey";
        public const string WindowsPasswordCryptorIV = "WindowsPasswordCryptorIV";

        public const string AttachDebugger = "AttachDebugger";
        public const string WaitAtStartup = "WaitAtStartup";

        public const string SunellCameraWindowRotateSpeed = "SunellCameraWindowRotateSpeed";
        public const string SunellLegacyCameraWindowRotateSpeed = "SunellLegacyCameraWindowRotateSpeed";
        public const string UseMiniSizeForFullscreenWindows = "UseMiniSizeForFullscreenWindows";
        public const string MiniFullscreenWindowWidth = "MiniFullscreenWindowWidth";
        public const string MiniFullscreenWindowHeight = "MiniFullscreenWindowHeight";
        public const string PipeServerName = "KBD300A_Pipe";

        public const string VideoCaptureClientBufferSize = "VideoCaptureClient.BufferSize";
        public const string ImageCaptureServerBufferSize = "ImageCaptureServer.BufferSize";
        public const string VideoSourceCameraWindowReconnectTimeout = "VideoSourceCameraWindowReconnectTimeout";

        public static string StartAppsWithRedirectedOutput = "StartAppsWithRedirectedOutput";
        public static string ProtectPasswordLength = "ProtectPasswordLength";
    }
}
