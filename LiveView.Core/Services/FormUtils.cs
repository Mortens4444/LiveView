using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LiveView.Core.Services
{
    public static class FormUtils
    {
        private const int SW_SHOW = 5;
        private const int SW_HIDE = 0;

        [DllImport("User32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void ShowMdiChildForms(Form mdiParent, List<Form> forms)
        {
            foreach (var form in forms)
            {
                mdiParent.Invoke((Action)(() =>
                {
                    ShowWindow(form.Handle, SW_SHOW);
                }));
            }
        }

        public static void HideMdiChildForms(Form mdiParent, List<Form> forms)
        {
            foreach (var form in forms)
            {
                mdiParent.Invoke((Action)(() =>
                {
                    ShowWindow(form.Handle, SW_HIDE);
                }));
            }
        }

        public static void DisposeMdiChildForms(Form mdiParent, List<Form> forms)
        {
            foreach (var form in forms)
            {
                try
                {
                    mdiParent.Invoke((Action)(() =>
                    {
                        if (!form.IsDisposed)
                        {
                            form.Close();
                            form.Dispose();
                        }
                    }));
                }
                catch (InvalidOperationException)
                {
                }
            }
        }
    }
}
