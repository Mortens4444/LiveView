using CameraForms.Dto;
using CameraForms.Enums;
using LiveView.Core.Services;
using System;
using System.Drawing;

namespace CameraApp.Services
{
    public static class CameraLaunchContextParser
    {
        public static CameraLaunchContext Parse(string[] args, IServiceProvider serviceProvider)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var cameraLaunchContext = new CameraLaunchContext(serviceProvider);

            var agentId = Parser.ToInt32(args[0]);
            cameraLaunchContext.AgentId = agentId == 0 ? (int?)null : agentId;
            cameraLaunchContext.UserId = Parser.ToInt32(args[1]);

            switch (args.Length)
            {
                case 4:
                    cameraLaunchContext.StartType = StartType.StartCamera;
                    cameraLaunchContext.CameraId = Parser.ToInt32(args[2]);
                    cameraLaunchContext.CameraMode = Parser.ConvertToCameraMode(args[3]);
                    break;
                case 5:
                    cameraLaunchContext.CameraMode = Parser.ConvertToCameraMode(args[4]);
                    if (Int32.TryParse(args[2], out var cameraId))
                    {
                        cameraLaunchContext.StartType = StartType.StartCameraOnDisplay;
                        cameraLaunchContext.CameraId = cameraId;
                        cameraLaunchContext.DisplayId = Parser.ToInt32(args[3]);
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
                    cameraLaunchContext.DisplayId = Parser.ToInt32(args[4]);
                    cameraLaunchContext.CameraMode = Parser.ConvertToCameraMode(args[5]);
                    break;
                case 8:
                    cameraLaunchContext.StartType = StartType.StartCameraInRectangle;
                    cameraLaunchContext.CameraId = Parser.ToInt32(args[2]);
                    cameraLaunchContext.Rectangle = new Rectangle
                    {
                        X = Parser.ToInt32(args[3]),
                        Y = Parser.ToInt32(args[4]),
                        Width = Parser.ToInt32(args[5]),
                        Height = Parser.ToInt32(args[6])
                    };
                    cameraLaunchContext.CameraMode = Parser.ConvertToCameraMode(args[7]);
                    break;
                case 9:
                    cameraLaunchContext.StartType = StartType.StartVideoSourceInRectangle;
                    cameraLaunchContext.ServerIp = args[2];
                    cameraLaunchContext.VideoCaptureSource = args[3];

                    cameraLaunchContext.Rectangle = new Rectangle
                    {
                        X = Parser.ToInt32(args[4]),
                        Y = Parser.ToInt32(args[5]),
                        Width = Parser.ToInt32(args[6]),
                        Height = Parser.ToInt32(args[7])
                    };
                    cameraLaunchContext.CameraMode = Parser.ConvertToCameraMode(args[8]);

                    break;
                default:
                    throw new NotSupportedException("Parameters do not match.");
            }

            return cameraLaunchContext;
        }
    }
}
