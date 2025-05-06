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

            var agentId = Convert.ToInt64(args[0], CultureInfo.InvariantCulture);
            cameraLaunchContext.AgentId = agentId == 0 ? (long?)null : agentId;
            cameraLaunchContext.UserId = Convert.ToInt64(args[1], CultureInfo.InvariantCulture);

            switch (args.Length)
            {
                case 4:
                    cameraLaunchContext.StartType = StartType.StartCamera;
                    cameraLaunchContext.CameraId = Convert.ToInt64(args[2], CultureInfo.InvariantCulture);
                    cameraLaunchContext.CameraMode = (CameraMode)Convert.ToInt32(args[3], CultureInfo.InvariantCulture);
                    break;
                case 5:
                    cameraLaunchContext.CameraMode = (CameraMode)Convert.ToInt32(args[4], CultureInfo.InvariantCulture);
                    if (Int64.TryParse(args[2], out var cameraId))
                    {
                        cameraLaunchContext.StartType = StartType.StartCameraOnDisplay;
                        cameraLaunchContext.CameraId = cameraId;
                        cameraLaunchContext.DisplayId = Convert.ToInt64(args[3], CultureInfo.InvariantCulture);
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
                    cameraLaunchContext.DisplayId = Convert.ToInt64(args[4], CultureInfo.InvariantCulture);
                    cameraLaunchContext.CameraMode = (CameraMode)Convert.ToInt32(args[5], CultureInfo.InvariantCulture);
                    break;
                case 8:
                    cameraLaunchContext.StartType = StartType.StartCameraInRectangle;
                    cameraLaunchContext.CameraId = Convert.ToInt64(args[2], CultureInfo.InvariantCulture);
                    cameraLaunchContext.Rectangle = new Rectangle
                    {
                        X = Convert.ToInt32(args[3], CultureInfo.InvariantCulture),
                        Y = Convert.ToInt32(args[4], CultureInfo.InvariantCulture),
                        Width = Convert.ToInt32(args[5], CultureInfo.InvariantCulture),
                        Height = Convert.ToInt32(args[6], CultureInfo.InvariantCulture)
                    };
                    cameraLaunchContext.CameraMode = (CameraMode)Convert.ToInt32(args[7], CultureInfo.InvariantCulture);
                    break;
                case 9:
                    cameraLaunchContext.StartType = StartType.StartVideoSourceInRectangle;
                    cameraLaunchContext.ServerIp = args[2];
                    cameraLaunchContext.VideoCaptureSource = args[3];

                    cameraLaunchContext.Rectangle = new Rectangle
                    {
                        X = Convert.ToInt32(args[4], CultureInfo.InvariantCulture),
                        Y = Convert.ToInt32(args[5], CultureInfo.InvariantCulture),
                        Width = Convert.ToInt32(args[6], CultureInfo.InvariantCulture),
                        Height = Convert.ToInt32(args[7], CultureInfo.InvariantCulture)
                    };
                    cameraLaunchContext.CameraMode = (CameraMode)Convert.ToInt32(args[8], CultureInfo.InvariantCulture);

                    break;
                default:
                    throw new NotSupportedException("Parameters do not match.");
            }

            return cameraLaunchContext;
        }
    }
}
