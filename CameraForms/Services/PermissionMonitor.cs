using Mtf.MessageBoxes;
using System;
using System.Windows.Forms;

namespace CameraForms.Services
{
    public class PermissionMonitor : IDisposable
    {
        private readonly Func<bool> checkPermission;
        private readonly Action onPermissionGranted;
        private readonly Timer timer;
        private bool disposed;

        public PermissionMonitor(Func<bool> checkPermission, Action onPermissionGranted, int intervalMs = 3000)
        {
            this.checkPermission = checkPermission ?? throw new ArgumentNullException(nameof(checkPermission));
            this.onPermissionGranted = onPermissionGranted ?? throw new ArgumentNullException(nameof(onPermissionGranted));

            timer = new Timer
            {
                Interval = intervalMs
            };
            timer.Tick += Timer_Tick;
        }

        public void Start()
        {
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (checkPermission())
            {
                timer.Stop();
                onPermissionGranted();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    timer.Stop();
                    timer.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
