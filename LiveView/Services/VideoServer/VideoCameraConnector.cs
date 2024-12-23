using AxVIDEOCONTROL4Lib;
using LiveView.Models.VideoServer;
using System.Collections.Generic;

namespace LiveView.Services.VideoServer
{
    public static class VideoCameraConnector
    {
        public static List<VideoServerCamera> GetOrUpdateCameras(AxVideoServer axVideoServer)
        {
            var result = new List<VideoServerCamera>();
            for (int i = 0; i < axVideoServer.NumberOfCameras; i++)
            {
                result.Add(new VideoServerCamera
                {
                    Index = i,
                    Guid = axVideoServer.GetCameraID(i),
                    Name = axVideoServer.GetCameraName(i),
                    Status = axVideoServer.GetCameraStatus(i)
                });
            }
            return result;
        }
    }
}
