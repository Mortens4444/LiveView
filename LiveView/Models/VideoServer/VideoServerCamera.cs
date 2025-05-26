using LiveView.Enums;
using Mtf.Extensions.Interfaces;
using System;

namespace LiveView.Models.VideoServer
{
    public class VideoServerCamera : IHaveGuid
    {
        public int Index { get; set; }

        public string Guid { get; set; }

        public string Name { get; set; }

        public object Status { get; set; }

        public object this[CameraStatusInfo cameraStatusInfo]
        {
            get
            {
                if (Status is object[] statuses && Enum.IsDefined(typeof(CameraStatusInfo), cameraStatusInfo))
                {
                    int index = (int)cameraStatusInfo;
                    return index < statuses.Length ? statuses[index] : null;
                }
                return null;
            }
        }
    }
}
