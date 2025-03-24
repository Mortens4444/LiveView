using Database.Enums;
using System.Collections.Generic;
using System;
using System.Linq;

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
        
        public CameraMode CameraMode { get; set; }

        public List<string> GetProtectedParameters(long userId)
        {
            string[] parameters;
            switch (CameraMode)
            {
                case CameraMode.AxVideoPlayer:
                case CameraMode.SunellCamera:
                case CameraMode.SunellLegacyCamera:
                case CameraMode.FFMpeg:
                case CameraMode.OpenCvSharp:
                case CameraMode.OpenCvSharp4:
                case CameraMode.MortoGraphy:
                case CameraMode.Vlc:
                    parameters = new[]
                    {
                            userId.ToString(),
                            CameraId.ToString(),
                            ((int)CameraMode).ToString()
                    };
                    break;
                case CameraMode.VideoSource:
                    parameters = new[]
                    {
                        userId.ToString(),
                        ServerIp,
                        VideoCaptureSource,
                        ((int)CameraMode.VideoSource).ToString()
                    };
                    break;
                default:
                    throw new NotSupportedException();

            }

            return parameters.Select(p => p.Contains(' ') ? $"\"{p}\"" : p).ToList();
        }
    }
}