using CameraForms.Dto;
using Database.Enums;
using Database.Models;
using Mtf.Extensions;
using Sequence.Dto;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace Sequence.Services
{
    public static class CameraInfoBuilder
    {
        public static CameraInfo GetCameraInfo(ReadOnlyCollection<Server> servers, GridCamera gridCamera, Camera camera, Tuple<string, string> videoSourceInfo)
        {
            if (gridCamera == null || camera == null)
            {
                return null;
            }

            switch (gridCamera.CameraMode)
            {
                case CameraMode.AxVideoPlayer:
                    return new AxVideoPictureCameraInfo
                    {
                        GridCamera = gridCamera,
                        Camera = camera,
                        Server = servers.First(s => s.Id == camera.ServerId)
                    };

                case CameraMode.VideoSource:
                    if (camera.VideoSourceId.HasValue)
                    {
                        return new VideoCaptureSourceCameraInfo
                        {
                            GridCamera = gridCamera,
                            ServerIp = videoSourceInfo?.Item1,
                            VideoSourceName = videoSourceInfo?.Item2
                        };
                    }
                    else
                    {
                        try
                        {
                            var streamUrlVideoSourceInfo = camera.HttpStreamUrl?.GetVideoSourceInfo();
                            return new VideoCaptureSourceCameraInfo
                            {
                                GridCamera = gridCamera,
                                ServerIp = streamUrlVideoSourceInfo?.Item1,
                                VideoSourceName = streamUrlVideoSourceInfo?.Item2
                            };
                        }
                        catch (ArgumentException)
                        {
                            return new VideoCaptureSourceCameraInfo
                            {
                                GridCamera = gridCamera
                            };
                        }
                    }

                case CameraMode.Vlc:
                    return new VlcCameraInfo
                    {
                        GridCamera = gridCamera,
                        Url = camera.HttpStreamUrl
                    };

                case CameraMode.MortoGraphy:
                    return new MortoGraphyCameraInfo
                    {
                        GridCamera = gridCamera,
                        Url = camera.HttpStreamUrl
                    };

                case CameraMode.FFMpeg:
                    return new FFMpegCameraInfo
                    {
                        GridCamera = gridCamera,
                        Url = camera.HttpStreamUrl
                    };

                case CameraMode.OpenCvSharp:
                    return new OpenCvSharpCameraInfo
                    {
                        GridCamera = gridCamera,
                        Url = camera.HttpStreamUrl
                    };

                case CameraMode.OpenCvSharp4:
                    return new OpenCvSharp4CameraInfo
                    {
                        GridCamera = gridCamera,
                        Url = camera.HttpStreamUrl
                    };

                case CameraMode.SunellLegacyCamera:
                    return new SunellLegacyCameraInfo
                    {
                        GridCamera = gridCamera,
                        CameraIp = camera.IpAddress,
                        CameraPort = SunellLegacyCameraInfo.PagoPort,
                        Username = camera.Username,
                        Password = camera.Password,
                        CameraId = camera.CameraId ?? 1,
                        StreamId = camera.StreamId ?? 1
                    };

                case CameraMode.SunellCamera:
                    return new SunellCameraInfo
                    {
                        GridCamera = gridCamera,
                        CameraIp = camera.IpAddress,
                        CameraPort = SunellLegacyCameraInfo.PagoPort,
                        Username = camera.Username,
                        Password = camera.Password,
                        CameraId = camera.CameraId ?? 1,
                        StreamId = camera.StreamId ?? 1
                    };

                case CameraMode.Chromium:
                    return new ChromiumCameraInfo
                    {
                        GridCamera = gridCamera,
                        Url = camera.HttpStreamUrl
                    };

#if NETFRAMEWORK

                case CameraMode.AccordJpeg:
                    return new AccordJpegCameraInfo
                    {
                        GridCamera = gridCamera,
                        Url = camera.HttpStreamUrl
                    };

                case CameraMode.AccordMjpeg:
                    return new AccordMjpegCameraInfo
                    {
                        GridCamera = gridCamera,
                        Url = camera.HttpStreamUrl
                    };

                case CameraMode.AccordScreenCapture:
                    return new AccordScreenCaptureCameraInfo
                    {
                        GridCamera = gridCamera,
                        RecordingArea = Screen.PrimaryScreen.Bounds
                    };

                case CameraMode.AForgeJpeg:
                    return new AForgeJpegCameraInfo
                    {
                        GridCamera = gridCamera,
                        Url = camera.HttpStreamUrl
                    };

                case CameraMode.AForgeMjpeg:
                    return new AForgeMjpegCameraInfo
                    {
                        GridCamera = gridCamera,
                        Url = camera.HttpStreamUrl
                    };

                case CameraMode.AForgeScreenCapture:
                    return new AForgeScreenCaptureCameraInfo
                    {
                        GridCamera = gridCamera,
                        RecordingArea = Screen.PrimaryScreen.Bounds
                    };

                case CameraMode.AForgeVideoSource:
                    return new AForgeVideoSourceCameraInfo
                    {
                        GridCamera = gridCamera,
                        Url = camera.HttpStreamUrl
                    };

#endif

                default:
                    throw new NotSupportedException($"CameraMode is not supported: {gridCamera.CameraMode}");
            }
        }
    }
}
