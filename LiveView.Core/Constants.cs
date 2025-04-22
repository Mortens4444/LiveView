namespace LiveView.Core
{
    public static class Constants
    {
        public const string CameraAppExe = "CameraApp.exe";

        public const string SequenceExe = "Sequence.exe";

        // Configuration values
        public const string LiveViewServerIpAddress = "LiveView.Server.IpAddress";
        public const string LiveViewServerListenerPort = "LiveView.Server.ListenerPort";
        public const string LiveViewAgentImageCaptureServerFps= "LiveView.Agent.ImageCaptureServer.FPS";
        public const string LiveViewAgentHideConsoleWindow = "LiveView.Agent.HideConsoleWindow";
        
        public const string AttachDebugger = "AttachDebugger";
        public const string WaitAtStartup = "WaitAtStartup";

        public const string SunellLegacyCameraWindowRotateSpeed = "SunellLegacyCameraWindowRotateSpeed";
        public const string UseMiniSizeForFullscreenWindows = "UseMiniSizeForFullscreenWindows";
        public const string MiniFullscreenWindowWidth = "MiniFullscreenWindowWidth";
        public const string MiniFullscreenWindowHeight = "MiniFullscreenWindowHeight";
        public const string PipeServerName = "KBD300A_Pipe";

        public const string VideoCaptureClientBufferSize = "VideoCaptureClient.BufferSize";
        public const string ImageCaptureServerBufferSize = "ImageCaptureServer.BufferSize";
    }
}
