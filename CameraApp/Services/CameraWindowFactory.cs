using CameraApp.Interfaces;
using CameraForms.Dto;
using CameraForms.Enums;
using CameraForms.Forms;
using Database.Enums;
using System;
using System.Windows.Forms;

namespace CameraApp.Services
{
    sealed class CameraWindowFactory : ICameraWindowFactory
    {
        public Form Create(CameraLaunchContext context, IServiceProvider serviceProvider)
        {
            switch (context.StartType)
            {
                case StartType.StartCamera:
                    switch (context.CameraMode)
                    {
                        case CameraMode.AxVideoPlayer:
                            return new AxVideoCameraWindow(serviceProvider, context.UserId, context.CameraId, null);
                        case CameraMode.SunellLegacyCamera:
                            return new SunellLegacyCameraWindow(serviceProvider, context.UserId, context.CameraId, null);
                        case CameraMode.SunellCamera:
                            return new SunellCameraWindow(serviceProvider, context.UserId, context.CameraId, null);
                        case CameraMode.MortoGraphy:
                            return new MortoGraphyCameraWindow(serviceProvider, context.UserId, context.CameraId, null);
                        case CameraMode.FFMpeg:
                            return new FFMpegCameraWindow(serviceProvider, context.UserId, context.CameraId, null);
                        case CameraMode.OpenCvSharp:
                            return new OpenCvSharpCameraWindow(serviceProvider, context.UserId, context.CameraId, null);
                        case CameraMode.OpenCvSharp4:
                            return new OpenCvSharp4CameraWindow(serviceProvider, context.UserId, context.CameraId, null);
                        case CameraMode.Vlc:
                            return new VlcCameraWindow(serviceProvider, context.UserId, context.CameraId, null);
                        default:
                            throw new NotSupportedException($"{context.CameraMode} is not supported.");
                    }
                case StartType.StartCameraOnDisplay:
                    switch (context.CameraMode)
                    {
                        case CameraMode.AxVideoPlayer:
                            return new AxVideoCameraWindow(serviceProvider, context.UserId, context.CameraId, context.DisplayId);
                        case CameraMode.SunellLegacyCamera:
                            return new SunellLegacyCameraWindow(serviceProvider, context.UserId, context.CameraId, context.DisplayId);
                        case CameraMode.SunellCamera:
                            return new SunellCameraWindow(serviceProvider, context.UserId, context.CameraId, context.DisplayId);
                        case CameraMode.MortoGraphy:
                            return new MortoGraphyCameraWindow(serviceProvider, context.UserId, context.CameraId, context.DisplayId);
                        case CameraMode.FFMpeg:
                            return new FFMpegCameraWindow(serviceProvider, context.UserId, context.CameraId, context.DisplayId);
                        case CameraMode.OpenCvSharp:
                            return new OpenCvSharpCameraWindow(serviceProvider, context.UserId, context.CameraId, context.DisplayId);
                        case CameraMode.OpenCvSharp4:
                            return new OpenCvSharp4CameraWindow(serviceProvider, context.UserId, context.CameraId, context.DisplayId);
                        case CameraMode.Vlc:
                            return new VlcCameraWindow(serviceProvider, context.UserId, context.CameraId, context.DisplayId);
                        default:
                            throw new NotSupportedException($"{context.CameraMode} is not supported.");
                    }
                case StartType.StartVideoSource:
                    switch (context.CameraMode)
                    {
                        case CameraMode.VideoSource:
                            return new VideoSourceCameraWindow(serviceProvider, context);
                            //return new VideoSourceCameraWindow(serviceProvider, context.UserId, context.ServerIp, context.VideoCaptureSource, null);
                        default:
                            throw new NotSupportedException($"{context.CameraMode} is not supported.");
                    }
                case StartType.StartVideoSourceOnDisplay:
                    switch (context.CameraMode)
                    {
                        case CameraMode.VideoSource:
                            return new VideoSourceCameraWindow(serviceProvider, context); // Need a refactor where all form uses context.
                            //return new VideoSourceCameraWindow(serviceProvider, context.UserId, context.ServerIp, context.VideoCaptureSource, context.DisplayId);
                        default:
                            throw new NotSupportedException($"{context.CameraMode} is not supported.");
                    }
                case StartType.StartCameraInRectangle:
                    switch (context.CameraMode)
                    {
                        case CameraMode.AxVideoPlayer:
                            return new AxVideoCameraWindow(serviceProvider, context.UserId, context.CameraId, context.Rectangle.Location, context.Rectangle.Size);
                        case CameraMode.SunellLegacyCamera:
                            return new SunellLegacyCameraWindow(serviceProvider, context.UserId, context.CameraId, context.Rectangle);
                        case CameraMode.SunellCamera:
                            return new SunellCameraWindow(serviceProvider, context.UserId, context.CameraId, context.Rectangle);
                        case CameraMode.MortoGraphy:
                            return new MortoGraphyCameraWindow(serviceProvider, context.UserId, context.CameraId, context.Rectangle);
                        case CameraMode.FFMpeg:
                            return new FFMpegCameraWindow(serviceProvider, context.UserId, context.CameraId, context.Rectangle);
                        case CameraMode.OpenCvSharp:
                            return new OpenCvSharpCameraWindow(serviceProvider, context.UserId, context.CameraId, context.Rectangle);
                        case CameraMode.OpenCvSharp4:
                            return new OpenCvSharp4CameraWindow(serviceProvider, context.UserId, context.CameraId, context.Rectangle);
                        case CameraMode.Vlc:
                            return new VlcCameraWindow(serviceProvider, context.UserId, context.CameraId, context.Rectangle);
                        default:
                            throw new NotSupportedException($"{context.CameraMode} is not supported.");
                    }
                case StartType.StartVideoSourceInRectangle:
                    switch (context.CameraMode)
                    {
                        case CameraMode.VideoSource:
                            return new VideoSourceCameraWindow(serviceProvider, context);
                            //return new VideoSourceCameraWindow(serviceProvider, context.UserId, context.ServerIp, context.VideoCaptureSource, context.Rectangle.Location, context.Rectangle.Size);
                        default:
                            throw new NotSupportedException($"{context.CameraMode} is not supported.");
                    }
                default:
                    throw new NotSupportedException($"{context.StartType} is not supported.");
            }
        }
    }
}
