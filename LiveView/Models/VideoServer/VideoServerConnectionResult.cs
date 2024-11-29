using System.Collections.Generic;

namespace LiveView.Models.VideoServer
{
    public class VideoServerConnectionResult
    {
        public int ErrorCode { get; private set; }

        public List<VideoServerCamera> Cameras { get; private set; }

        public VideoServerConnectionResult(int errorCode, List<VideoServerCamera> cameras)
        {
            ErrorCode = errorCode;
            Cameras = cameras;
        }
    }
}
