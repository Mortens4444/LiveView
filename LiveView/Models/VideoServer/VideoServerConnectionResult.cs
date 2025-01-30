using LiveView.Enums;
using System;
using System.Collections.Generic;

namespace LiveView.Models.VideoServer
{
    public class VideoServerConnectionResult
    {
        public int ErrorCode { get; private set; }

        public List<VideoServerCamera> Cameras { get; private set; }

        public object RecorderStatus { get; private set; }
        
        public object this[RecorderStatusInfo recorderStatusInfo]
        {
            get
            {
                if (RecorderStatus is object[] statuses && Enum.IsDefined(typeof(RecorderStatusInfo), recorderStatusInfo))
                {
                    int index = (int)recorderStatusInfo;
                    return index < statuses.Length ? statuses[index] : null;
                }
                return null;
            }
        }

        public VideoServerConnectionResult(int errorCode, List<VideoServerCamera> cameras, object recorderStatus)
        {
            ErrorCode = errorCode;
            Cameras = cameras;
            RecorderStatus = recorderStatus;
        }
    }
}
