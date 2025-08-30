using System;
using System.Reflection;
using System.Windows.Forms;
using CameraForms.Services;
using NUnit.Framework;

namespace CameraForms.Tests.Services
{
    [TestFixture]
    public class PermissionMonitorTests
    {
        private static MethodInfo GetTimerTickMethod() =>
            typeof(PermissionMonitor).GetMethod("Timer_Tick", BindingFlags.Instance | BindingFlags.NonPublic);

        private static FieldInfo GetTimerField() =>
            typeof(PermissionMonitor).GetField("timer", BindingFlags.Instance | BindingFlags.NonPublic);

        private static FieldInfo GetDisposedField() =>
            typeof(PermissionMonitor).GetField("disposed", BindingFlags.Instance | BindingFlags.NonPublic);

        [Test]
        public void ThrowsWhenCheckPermissionIsNull()
        {
            void act() => _ = new PermissionMonitor(null, () => { });

            Assert.That((Action)act, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowsWhenOnPermissionGrantedIsNull()
        {
            void act() => _ = new PermissionMonitor(() => true, null);

            Assert.That((Action)act, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void TickWhenPermissionTrueInvokesActionAndStopsTimer()
        {
            var called = false;
            var monitor = new PermissionMonitor(() => true, () => called = true, intervalMs: 10);

            try
            {
                monitor.Start();

                var timerField = GetTimerField();
                var timer = (Timer)timerField.GetValue(monitor);
                Assert.That(timer.Enabled, Is.True, "Timer should be started.");

                var tickMethod = GetTimerTickMethod();
                tickMethod.Invoke(monitor, new object[] { null, EventArgs.Empty });

                using (Assert.EnterMultipleScope())
                {
                    Assert.That(called, Is.True, "onPermissionGranted should have been called.");
                    Assert.That(timer.Enabled, Is.False, "Timer should be stopped after permission granted.");
                }
            }
            finally
            {
                monitor.Dispose();
            }
        }

        [Test]
        public void TickWhenPermissionFalseDoesNotInvokeActionAndTimerRemainsEnabled()
        {
            var called = false;
            var monitor = new PermissionMonitor(() => false, () => called = true, intervalMs: 10);

            try
            {
                monitor.Start();

                var timerField = GetTimerField();
                var timer = (Timer)timerField.GetValue(monitor);
                Assert.That(timer.Enabled, Is.True, "Timer should be started.");

                var tickMethod = GetTimerTickMethod();
                tickMethod.Invoke(monitor, new object[] { null, EventArgs.Empty });

                using (Assert.EnterMultipleScope())
                {
                    Assert.That(called, Is.False, "onPermissionGranted should NOT have been called.");
                    Assert.That(timer.Enabled, Is.True, "Timer should remain enabled when permission not granted.");
                }
            }
            finally
            {
                monitor.Dispose();
            }
        }

        [Test]
        public void DisposeStopsTimerAndSetsDisposedFlag()
        {
            var monitor = new PermissionMonitor(() => false, () => { }, intervalMs: 10);

            monitor.Start();

            var timerField = GetTimerField();
            var tickMethod = GetTimerTickMethod();
            var disposedField = GetDisposedField();

            var timer = (Timer)timerField.GetValue(monitor);
            Assert.That(timer.Enabled, Is.True, "Timer should be started.");

            monitor.Dispose();

            var disposedFlag = (bool)disposedField.GetValue(monitor);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(disposedFlag, Is.True, "Disposed flag should be set.");
                Assert.That(timer.Enabled, Is.False, "Timer should be stopped after Dispose.");
                Assert.That(() => monitor.Dispose(), Throws.Nothing);
            }
        }
    }
}
