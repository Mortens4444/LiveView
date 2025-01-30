namespace LiveView.Enums
{
    public enum CameraStatusInfo : byte
    {
        RPC_ReturnCode = 0,
        FrameRate = 1,
        CapturedFrames = 2,
        DroppedFrames = 3,
        StoredFrames = 4,
        DiskUsage = 5,
        EstimatedCapacity = 6,
        Motion = 7,
        Light = 8,
        Alarm = 9,
        Error = 10,
        Compression = 11,
        VideoSignal = 12,
        CarSignReader = 13,
        EstimatedCapacity_ = 14,
        GUID
    }
}
