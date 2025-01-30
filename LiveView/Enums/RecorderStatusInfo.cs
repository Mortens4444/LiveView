namespace LiveView.Enums
{
    public enum RecorderStatusInfo : byte
    {
        ReturnCode = 0,
        ProtocolVersion = 1,
        On_Off = 2,
        OnTimeInSeconds = 3,
        NumberOfLocalCameras = 4,
        ServerLocalTime_UnixTime = 5,
        CPU_Usage = 6,
        DongleSerial = 7,
        DongleSubtype = 8,
        CameraLicense = 9,
        RecorderVersion = 10,
        ServerVersion = 11,
        FullScreenMode = 12
    }
}
