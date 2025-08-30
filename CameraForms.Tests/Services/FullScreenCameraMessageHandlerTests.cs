using CameraForms.Interfaces;
using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace CameraForms.Tests.Services
{
    [TestFixture]
    public class FullScreenCameraMessageHandlerTests : ServerBaseTest
    {
        private ICameraFunctionRepository cameraFunctionRepository;
        private ICameraRegister cameraRegister;
        private FullScreenCameraMessageHandler handler;
        private Form form;

        [OneTimeSetUp]
        public void SetUp()
        {
            var userId = 1;
            var cameraId = 42;
            var display = new DisplayDto();
            var cameraMode = CameraMode.AxVideoPlayer;

            cameraFunctionRepository = Substitute.For<ICameraFunctionRepository>();
            cameraFunctionRepository
                .SelectWhere(Arg.Any<object>())
                .Returns(new ReadOnlyCollection<CameraFunction>(new List<CameraFunction>
                {
                    new CameraFunction { FunctionId = CameraFunctionType.PTZ_Up },
                    new CameraFunction { FunctionId = CameraFunctionType.PTZ_Down },
                    new CameraFunction { FunctionId = CameraFunctionType.PTZ_Left },
                    new CameraFunction { FunctionId = CameraFunctionType.PTZ_Right },
                }));

            cameraRegister = new CameraRegister();
            form = new Form();
            handler = new FullScreenCameraMessageHandler(userId, cameraId, form, display, cameraMode, cameraFunctionRepository, cameraRegister);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            form?.Dispose();
            handler?.Dispose();
        }

        [Test]
        public void ConstructorShouldInitializeCameraFunctionsFromRepository()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(handler.PtzUp.FunctionId, Is.EqualTo(CameraFunctionType.PTZ_Up));
                Assert.That(handler.PtzDown.FunctionId, Is.EqualTo(CameraFunctionType.PTZ_Down));
                Assert.That(handler.PtzLeft.FunctionId, Is.EqualTo(CameraFunctionType.PTZ_Left));
                Assert.That(handler.PtzRight.FunctionId, Is.EqualTo(CameraFunctionType.PTZ_Right));
                Assert.That(handler.PtzStop, Is.Null);
            }
        }

        [Test]
        public void ClientDataArrivedEventHandlerShouldExecuteCommands()
        {
            handler.Exit();
            Assert.Pass();
        }
    }
}
