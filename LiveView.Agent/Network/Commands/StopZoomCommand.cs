using LiveView.Core.Interfaces;
using OpenCvSharp;
using System.Collections.Generic;

namespace LiveView.Agent.Network.Commands
{
    public class StopZoomCommand : ICommand
    {
        private readonly Dictionary<string, VideoCapture> videoCaptures;
        private readonly string videoCaptureId;

        public StopZoomCommand(Dictionary<string, VideoCapture> videoCaptures, string videoCaptureId)
        {
            this.videoCaptures = videoCaptures;
            this.videoCaptureId = videoCaptureId;
        }

        public void Execute()
        {
            videoCaptures[videoCaptureId].Zoom = 0;
        }
    }
}
