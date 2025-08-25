using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using Mtf.Controls.Video.ActiveX;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CameraForms.Services
{
    public class FullScreenCameraMessageHandler : IDisposable
    {
        private readonly Client client;
        private readonly Form form;
        private readonly FullScreenCameraCommandFactory fullScreenCameraCommandFactory;
        private volatile int disposed;

        public CameraFunction PtzStop { get; }

        public CameraFunction PtzUp { get; }

        public CameraFunction PtzDown { get; }

        public CameraFunction PtzLeft { get; }

        public CameraFunction PtzRight { get; }

        public CameraFunction PtzUpLeft { get; }

        public CameraFunction PtzUpRight { get; }

        public CameraFunction PtzDownLeft { get; }

        public CameraFunction PtzDownRight { get; }

        public CameraFunction PtzMoveToPresetZero { get; }

        public CameraFunction PtzZoomIn { get; }

        public CameraFunction PtzZoomOut { get; }

        public FullScreenCameraMessageHandler(long userId, long cameraId, Form form, DisplayDto display, CameraMode cameraMode, ICameraFunctionRepository cameraFunctionRepository)
        {
            this.form = form;
            client = CameraRegister.RegisterCamera(userId, cameraId, display, ClientDataArrivedEventHandler, cameraMode);

            var cameraFunctions = (cameraFunctionRepository?.SelectWhere(new { CameraId = cameraId }) ?? new ReadOnlyCollection<CameraFunction>(new List<CameraFunction>())).ToList();
            PtzStop = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Stop);
            PtzUp = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Up);
            PtzDown = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Down);
            PtzLeft = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Left);
            PtzRight = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Right);
            PtzUpLeft = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Up_And_Left);
            PtzUpRight = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Up_And_Right);
            PtzDownLeft = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Down_And_Left);
            PtzDownRight = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Down_And_Right);
            PtzMoveToPresetZero = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Load_Preset_0);
            PtzZoomIn = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Zoom_In);
            PtzZoomOut = cameraFunctions.FirstOrDefault(cameraFunction => cameraFunction.FunctionId == CameraFunctionType.PTZ_Zoom_Out);

            fullScreenCameraCommandFactory = new FullScreenCameraCommandFactory(form, this);
        }

        public FullScreenCameraMessageHandler(long userId, string serverIp, string videoCaptureSource, Form form, DisplayDto display, CameraMode cameraMode, ICameraFunctionRepository cameraFunctionRepository)
        {
            this.form = form;
            client = CameraRegister.RegisterVideoSource(userId, serverIp, videoCaptureSource, display, ClientDataArrivedEventHandler);

            fullScreenCameraCommandFactory = new FullScreenCameraCommandFactory(form, this);
        }

        ~FullScreenCameraMessageHandler()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref disposed, 1) != 0)
            {
                return;
            }

            if (disposing)
            {
                client?.Dispose();
            }
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
                var commands = fullScreenCameraCommandFactory.CreateCommands(messages);
                foreach (var command in commands)
                {
                    command.Execute();
                    Console.WriteLine($"{command.GetType().Name} executed in full screen camera.");
                }
            }
            catch (Exception ex)
            {
                var message = $"Message parse or execution failed in full screen camera: {ex}.";
                Console.Error.WriteLine(message);
                DebugErrorBox.Show(ex);
            }
        }
    }
}
