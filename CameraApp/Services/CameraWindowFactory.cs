using CameraApp.Interfaces;
using CameraForms.Dto;
using CameraForms.Forms;
using Database.Enums;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[assembly: InternalsVisibleTo("CameraApp.Tests")]
namespace CameraApp.Services
{
    internal sealed class CameraWindowFactory : ICameraWindowFactory
    {
        public Form Create(CameraLaunchContext context)
        {
            switch (context.CameraMode)
            {
                case CameraMode.AxVideoPlayer:
                    return new AxVideoCameraWindow(context);

                case CameraMode.FFMpeg:
                    return new FFMpegCameraWindow(context);

                case CameraMode.MortoGraphy:
                    return new MortoGraphyCameraWindow(context);

                case CameraMode.OpenCvSharp:
                    return new OpenCvSharpCameraWindow(context);

                case CameraMode.OpenCvSharp4:
                    return new OpenCvSharp4CameraWindow(context);

                case CameraMode.SunellCamera:
                    return new SunellCameraWindow(context);

                case CameraMode.SunellLegacyCamera:
                    return new SunellLegacyCameraWindow(context);

                case CameraMode.VideoSource:
                    return new VideoSourceCameraWindow(context);

                case CameraMode.Vlc:
                    return new VlcCameraWindow(context);

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
