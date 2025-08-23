using CameraForms.Extensions;
using Database.Models;
using Mtf.Controls.Interfaces;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CameraForms.Tests.Extensions
{
    [TestFixture]
    public class PermissionManagerExtensionsTests
    {
        [Test]
        public void ThrowWhenPermissionManagerIsNull()
        {
            var camera = new Camera();

            Assert.That(
                () => ((PermissionManager<User>)null).HasCamera(camera),
                Throws.TypeOf<ArgumentNullException>()
            );
        }

        [Test]
        public void ThrowWhenPermissionManagerIsNullWithVideoWindow()
        {
            var camera = new Camera();
            var vw = Substitute.For<IVideoWindow>();

            Assert.That(
                () => ((PermissionManager<User>)null).HasCameraPermission(camera, vw),
                Throws.TypeOf<ArgumentNullException>()
            );
        }

        [Test]
        public void ThrowWhenCameraIsNull()
        {
            var pm = new PermissionManager<User>();

            Assert.That(
                () => pm.HasCamera(null),
                Throws.TypeOf<ArgumentNullException>()
            );
        }

        [Test]
        public void ThrowWhenCameraIsNullWithVideoWindow()
        {
            var pm = new PermissionManager<User>();
            var vw = Substitute.For<IVideoWindow>();

            Assert.That(
                () => pm.HasCameraPermission(null, vw),
                Throws.TypeOf<ArgumentNullException>()
            );
        }

        [Test]
        public void ThrowWhenVideoWindowIsNull()
        {
            var pm = new PermissionManager<User>();
            var cam = new Camera();

            Assert.That(
                () => pm.HasCameraPermission(cam, null),
                Throws.TypeOf<ArgumentNullException>()
            );
        }

        [Test]
        public void ReturnTrueWhenInputsAreValid()
        {
            var pm = new PermissionManager<User>();
            var camera = new Camera();

            var result = pm.HasCamera(camera);

            Assert.That(result, Is.True);
        }

        [Test]
        public void ReturnTrueWhenAccessAllowed()
        {
            var cam = new Camera { PermissionCamera = 1 };
            var vw = Substitute.For<IVideoWindow>();

            var pm = CreatePermissionManager();

            var result = pm.HasCameraPermission(cam, vw);

            Assert.That(result, Is.True);
        }

        [Test]
        public void ReturnFalseAndSetOverlayWhenAccessDenied()
        {
            var cam = new Camera { PermissionCamera = 2 };
            var vw = Substitute.For<IVideoWindow>();

            var pm = CreatePermissionManager();

            var result = pm.HasCameraPermission(cam, vw);

            Assert.That(result, Is.False);
            Assert.That(vw.OverlayText, Does.Contain("No permission"));
        }

        private static PermissionManager<User> CreatePermissionManager()
        {
            var pm = new PermissionManager<User>();
            pm.Login(new Mtf.Permissions.Models.User<User>
            {
                Groups = new List<Mtf.Permissions.Models.Group>
                {
                    new Mtf.Permissions.Models.Group
                    {
                        Id = 2,
                        Permissions = new List<Mtf.Permissions.Models.Permission>
                        {
                            new Mtf.Permissions.Models.Permission
                            {
                                PermissionGroup = typeof(CameraGroupPermissions_001_060),
                                PermissionValue = (long)CameraGroupPermissions_001_060.Camera_001
                            }
                        }
                    }
                }
            });
            return pm;
        }
    }
}
