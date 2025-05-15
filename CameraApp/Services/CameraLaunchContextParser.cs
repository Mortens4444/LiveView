using CameraForms.Dto;
using CameraForms.Enums;
using Database.Enums;
using System;
using System.Drawing;
using System.Globalization;

namespace CameraApp.Services
{
    public static class CameraLaunchContextParser
    {
        public static CameraLaunchContext Parse(string[] args)
        {
            var cameraLaunchContext = new CameraLaunchContext();

            var agentId = ArgToInt64(args[0]);
            cameraLaunchContext.AgentId = agentId == 0 ? (long?)null : agentId;
            cameraLaunchContext.UserId = ArgToInt64(args[1]);

            switch (args.Length)
            {
                case 4:
                    cameraLaunchContext.StartType = StartType.StartCamera;
                    cameraLaunchContext.CameraId = ArgToInt64(args[2]);
                    cameraLaunchContext.CameraMode = ArgToCameraMode(args[3]);
                    break;
                case 5:
                    cameraLaunchContext.CameraMode = ArgToCameraMode(args[4]);
                    if (Int64.TryParse(args[2], out var cameraId))
                    {
                        cameraLaunchContext.StartType = StartType.StartCameraOnDisplay;
                        cameraLaunchContext.CameraId = cameraId;
                        cameraLaunchContext.DisplayId = ArgToInt64(args[3]);
                    }
                    else
                    {
                        cameraLaunchContext.StartType = StartType.StartVideoSource;
                        cameraLaunchContext.ServerIp = args[2];
                        cameraLaunchContext.VideoCaptureSource = args[3];
                    }
                    break;
                case 6:
                    cameraLaunchContext.StartType = StartType.StartVideoSourceOnDisplay;
                    cameraLaunchContext.ServerIp = args[2];
                    cameraLaunchContext.VideoCaptureSource = args[3];
                    cameraLaunchContext.DisplayId = ArgToInt64(args[4]);
                    cameraLaunchContext.CameraMode = ArgToCameraMode(args[5]);
                    break;
                case 8:
                    cameraLaunchContext.StartType = StartType.StartCameraInRectangle;
                    cameraLaunchContext.CameraId = ArgToInt64(args[2]);
                    cameraLaunchContext.Rectangle = new Rectangle
                    {
                        X = ArgToInt32(args[3]),
                        Y = ArgToInt32(args[4]),
                        Width = ArgToInt32(args[5]),
                        Height = ArgToInt32(args[6])
                    };
                    cameraLaunchContext.CameraMode = ArgToCameraMode(args[7]);
                    break;
                case 9:
                    cameraLaunchContext.StartType = StartType.StartVideoSourceInRectangle;
                    cameraLaunchContext.ServerIp = args[2];
                    cameraLaunchContext.VideoCaptureSource = args[3];

                    cameraLaunchContext.Rectangle = new Rectangle
                    {
                        X = ArgToInt32(args[4]),
                        Y = ArgToInt32(args[5]),
                        Width = ArgToInt32(args[6]),
                        Height = ArgToInt32(args[7])
                    };
                    cameraLaunchContext.CameraMode = ArgToCameraMode(args[8]);

                    break;
                default:
                    throw new NotSupportedException("Parameters do not match.");
            }

            return cameraLaunchContext;
        }

        private static CameraMode ArgToCameraMode(string arg)
        {
            return (CameraMode)Convert.ToInt32(arg, CultureInfo.InvariantCulture);
        }

        private static int ArgToInt32(string arg)
        {
            return Convert.ToInt32(arg, CultureInfo.InvariantCulture);
        }

        private static long ArgToInt64(string arg)
        {
            return Convert.ToInt64(arg, CultureInfo.InvariantCulture);
        }
    }
}
