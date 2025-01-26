namespace LiveView.Dto
{
    public class CameraProcessInfo
    {
        public string LocalEndPoint { get; set; }

        public long UserId { get; set; }

        public long? CameraId { get; set; }

        public string ServerIp { get; set; }

        public string VideoCaptureSource { get; set; }

        public long? DisplayId { get; set; }

        public int ProcessId { get; set; }
    }
}