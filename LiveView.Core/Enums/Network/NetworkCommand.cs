namespace LiveView.Core.Enums.Network
{
    public enum NetworkCommand
    {
        Kill,
        KillAll,
        RegisterAgent,
        UnregisterAgent,
        RegisterDisplay,
        UnregisterDisplay,
        SendCameraProcessId,
        RegisterSequence,
        UnregisterSequence,
        Close,
        FrameArrived,
        VideoCaptureCreationFailure,
        VideoCaptureFailure,
        StopVideoCapture,
        VideoCaptureSourcesRequest,
        VideoCaptureSourcesResponse,
        Ping
    }
}
