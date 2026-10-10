using LiveView.Core.Interfaces;
using OpenCvSharp;
using System;
using System.Collections.Generic;

namespace LiveView.Agent.Network.Commands
{
    public class PanToWestAndTiltToNorthCommand : ICommand
    {
        private readonly Dictionary<string, VideoCapture> videoCaptures;
        private readonly string videoCaptureId;
        private readonly double panValue;
        private readonly double tiltValue;

        public PanToWestAndTiltToNorthCommand(Dictionary<string, VideoCapture> videoCaptures, string videoCaptureId, string panValue, string tiltValue)
        {
            this.videoCaptures = videoCaptures;
            this.videoCaptureId = videoCaptureId;
            _ = Double.TryParse(panValue?.Replace(',', '.'), out this.panValue);
            _ = Double.TryParse(tiltValue?.Replace(',', '.'), out this.tiltValue);
        }

        public void Execute()
        {
            videoCaptures[videoCaptureId].Pan = panValue;
            videoCaptures[videoCaptureId].Tilt = tiltValue;
        }
    }
}
