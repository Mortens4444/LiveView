using Database.Models;
using System;

namespace CameraForms.Dto
{
    public class VideoCaptureSourceCameraInfo : CameraInfo
    {
        public string ServerIp { get; set; }

        public string VideoSourceName { get; set; }

        public bool IsEmpty()
        {
            return String.IsNullOrEmpty(ServerIp) && String.IsNullOrEmpty(VideoSourceName);
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                if (GridCamera == null)
                {
                    return "VideoCaptureSourceCameraInfo not initialized";
                }

                return $"CameraId: {GridCamera.CameraId}, CameraMode: {GridCamera.CameraMode}, GridCamera {GridCamera.Id}";
            }

            return $"{ServerIp}:{VideoSourceName}";
        }
    }
}
