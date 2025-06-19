using AxVIDEOCONTROL4Lib;
using LiveView.Services;
using Mtf.MessageBoxes;
using Mtf.Windows.Forms.Extensions;
using System;
using System.Threading.Tasks;

namespace LiveView.Extensions
{
    public static class AxVideoControlExtensions
    {
        public static AxVideoPicture Recreate(this AxVideoPicture control)
        {
            var newControl = ShallowCopyHelper.ShallowCopy(control);
            if (control != null)
            {
                try
                {
                    Task.Run(() =>
                    {
                        control.InvokeIfRequired(() => control.Disconnect());
                    }).ContinueWith((t) =>
                    {
                        control.InvokeIfRequired(() => control.Dispose());
                    });
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }
            return ShallowCopyHelper.ShallowCopy(newControl);
        }

        public static AxVideoServer RecreateFrom(this AxVideoServer control, AxVideoServer originalControl)
        {
            var newControl = ShallowCopyHelper.ShallowCopy(originalControl);
            if (control != null)
            {
                try
                {
                    Task.Run(() =>
                    {
                        control.InvokeIfRequired(() => control.Disconnect());
                    }).ContinueWith((t) =>
                    {
                        control.InvokeIfRequired(() => control.Dispose());
                    });
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }
            return ShallowCopyHelper.ShallowCopy(newControl);
        }
    }
}
