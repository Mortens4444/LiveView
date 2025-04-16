using LiveView.Core.Interfaces;
using OpenCvSharp;
using System;
using System.Collections.Generic;

namespace LiveView.Agent.Network.Commands
{
    public class PanToWestCommand : ICommand
    {
        private readonly Dictionary<string, VideoCapture> videoCaptures;
        private readonly string videoCaptureId;
        private readonly double value;

        public PanToWestCommand(Dictionary<string, VideoCapture> videoCaptures, string videoCaptureId, string value)
        {
            this.videoCaptures = videoCaptures;
            this.videoCaptureId = videoCaptureId;
            _ = Double.TryParse(value?.Replace(',', '.'), out this.value);
        }

        public void Execute()
        {
            videoCaptures[videoCaptureId].Pan = value;
        }
    }
}
