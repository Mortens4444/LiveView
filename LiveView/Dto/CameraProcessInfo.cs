using Database.Enums;
using System;
using System.Collections.Generic;
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

            parameters = CameraMode == CameraMode.VideoSource ?
                new[]
                {
                    userId.ToString(),
                    ServerIp,
                    VideoCaptureSource,
                    ((int)CameraMode.VideoSource).ToString()
                } :
                new[]
                {
                    userId.ToString(),
                    CameraId.ToString(),
                    ((int)CameraMode).ToString()
                };

            return parameters.Select(p => p.Contains(' ') ? $"\"{p}\"" : p).ToList();
        }
    }
}