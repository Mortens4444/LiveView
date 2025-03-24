using Mtf.MessageBoxes;
using Mtf.Network.EventArg;
using Mtf.Network;
using System;
using System.Windows.Forms;
using LiveView.Core.Services;
using LiveView.Core.Enums.Network;
using Database.Models;
using Database.Enums;
using LiveView.Core.Dto;
using Database.Interfaces;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace CameraForms.Services
{
    public class FullScreenCameraMessageHandler
    {
        private readonly Client client;
        private readonly Form form;

        private readonly CameraFunction ptzStop;
        private readonly CameraFunction ptzUp;
        private readonly CameraFunction ptzDown;
        private readonly CameraFunction ptzLeft;
        private readonly CameraFunction ptzRight;
        private readonly CameraFunction ptzUpLeft;
        private readonly CameraFunction ptzUpRight;
        private readonly CameraFunction ptzDownLeft;
        private readonly CameraFunction ptzDownRight;
        private readonly CameraFunction ptzMoveToPresetZero;
        private readonly CameraFunction ptzZoomIn;
        private readonly CameraFunction ptzZoomOut;

        public FullScreenCameraMessageHandler(long userId, long cameraId, Form form, DisplayDto display, CameraMode cameraMode, ICameraFunctionRepository cameraFunctionRepository)
        {
            this.form = form;
            client = CameraRegister.RegisterCamera(userId, cameraId, display, ClientDataArrivedEventHandler, cameraMode);

            var cameraFunctions = (cameraFunctionRepository?.SelectWhere(new { CameraId = cameraId }) ?? new ReadOnlyCollection<CameraFunction>(new List<CameraFunction>())).ToList();
            ptzStop = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Stop);
            ptzUp = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Up);
            ptzDown = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Down);
            ptzLeft = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Left);
            ptzRight = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Right);
            ptzUpLeft = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Up_And_Left);
            ptzUpRight = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Up_And_Right);
            ptzDownLeft = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Down_And_Left);
            ptzDownRight = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Down_And_Right);
            ptzMoveToPresetZero = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Load_Preset_0);
            ptzZoomIn = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Zoom_In);
            ptzZoomOut = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Zoom_Out);
        }

        public FullScreenCameraMessageHandler(long userId, string serverIp, string videoCaptureSource, Form form, DisplayDto display, CameraMode cameraMode, ICameraFunctionRepository cameraFunctionRepository)
        {
            this.form = form;
            client = CameraRegister.RegisterVideoSource(userId, serverIp, videoCaptureSource, display, ClientDataArrivedEventHandler);
        }

        public void Exit()
        {
            client.Send($"{NetworkCommand.UnregisterCamera}", true);
        }

        public void ExitVideoSource()
        {
            client.Send($"{NetworkCommand.UnregisterVideoSource}", true);
        }

        private void ClientDataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            try
            {
                var messages = $"{client.Encoding.GetString(e.Data)}";
                var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var message in allMessages)
                {
                    var messageParts = message.Split('|');
                    if (message.StartsWith(NetworkCommand.Close.ToString(), StringComparison.InvariantCulture))
                    {
                        form.Close();
                    }
                    else if (message.StartsWith(NetworkCommand.Kill.ToString(), StringComparison.InvariantCulture))
                    {
                        form.Close();
                    }
                    else if (message.StartsWith(NetworkCommand.PanToEast.ToString(), StringComparison.InvariantCulture))
                    {
                        UriCaller.CallUrl(ptzRight?.FunctionCallback);
                    }
                    else if (message.StartsWith(NetworkCommand.TiltToNorth.ToString(), StringComparison.InvariantCulture))
                    {
                        UriCaller.CallUrl(ptzUp?.FunctionCallback);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                    {
                        UriCaller.CallUrl(ptzUpRight?.FunctionCallback);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                    {
                        UriCaller.CallUrl(ptzUpLeft?.FunctionCallback);
                    }
                    else if (message.StartsWith(NetworkCommand.MoveToPresetZero.ToString(), StringComparison.InvariantCulture))
                    {
                        UriCaller.CallUrl(ptzMoveToPresetZero?.FunctionCallback);
                    }
                    else if (message.StartsWith(NetworkCommand.TiltToSouth.ToString(), StringComparison.InvariantCulture))
                    {
                        UriCaller.CallUrl(ptzDown?.FunctionCallback);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                    {
                        UriCaller.CallUrl(ptzDownRight?.FunctionCallback);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                    {
                        UriCaller.CallUrl(ptzDownLeft?.FunctionCallback);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToWest.ToString(), StringComparison.InvariantCulture))
                    {
                        UriCaller.CallUrl(ptzLeft?.FunctionCallback);
                    }
                    else if (message.StartsWith(NetworkCommand.StopPanAndTilt.ToString(), StringComparison.InvariantCulture))
                    {
                        UriCaller.CallUrl(ptzStop?.FunctionCallback);
                    }
                    else if (message.StartsWith(NetworkCommand.StopZoom.ToString(), StringComparison.InvariantCulture))
                    {
                        UriCaller.CallUrl(ptzStop?.FunctionCallback);
                    }
                    else if (message.StartsWith(NetworkCommand.ZoomIn.ToString(), StringComparison.InvariantCulture))
                    {
                        UriCaller.CallUrl(ptzZoomIn?.FunctionCallback);
                    }
                    else if (message.StartsWith(NetworkCommand.ZoomOut.ToString(), StringComparison.InvariantCulture))
                    {
                        UriCaller.CallUrl(ptzZoomOut?.FunctionCallback);
                    }
                    else
                    {
                        ErrorBox.Show("General error", $"Unexpected message arrived: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }
    }
}
