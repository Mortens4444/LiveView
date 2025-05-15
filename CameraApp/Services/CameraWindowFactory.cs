using CameraApp.Interfaces;
using CameraForms.Dto;
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
            switch (context.CameraMode)
            {
                case CameraMode.AxVideoPlayer:
                    return new AxVideoCameraWindow(serviceProvider, context);

                case CameraMode.FFMpeg:
                    return new FFMpegCameraWindow(serviceProvider, context);

                case CameraMode.MortoGraphy:
                    return new MortoGraphyCameraWindow(serviceProvider, context);

                case CameraMode.OpenCvSharp:
                    return new OpenCvSharpCameraWindow(serviceProvider, context);

                case CameraMode.OpenCvSharp4:
                    return new OpenCvSharp4CameraWindow(serviceProvider, context);

                case CameraMode.SunellCamera:
                    return new SunellCameraWindow(serviceProvider, context);

                case CameraMode.SunellLegacyCamera:
                    return new SunellLegacyCameraWindow(serviceProvider, context);

                case CameraMode.VideoSource:
                    return new VideoSourceCameraWindow(serviceProvider, context);

                case CameraMode.Vlc:
                    return new VlcCameraWindow(serviceProvider, context);

                case CameraMode.Chromium:
                    return null;

#if NETFRAMEWORK

                case CameraMode.AccordJpeg:
                    return null;

                case CameraMode.AccordMjpeg:
                    return null;

                case CameraMode.AccordScreenCapture:
                    return null;

                case CameraMode.AForgeJpeg:
                    return null;

                case CameraMode.AForgeMjpeg:
                    return null;

                case CameraMode.AForgeScreenCapture:
                    return null;

                case CameraMode.AForgeVideoSource:
                    return null;

#endif

                default:
                    throw new NotSupportedException($"{context.CameraMode} is not supported.");
            }
        }
    }
}
