using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LiveView.Core.Services
{
    public static class FormUtils
    {
        public static void ShowMdiChildForms(Form mdiParent, List<Form> forms)
        {
            foreach (var form in forms)
            {
                mdiParent.Invoke((Action)(() => form.Show()));
            }
        }

        public static void HideMdiChildForms(Form mdiParent, List<Form> forms)
        {
            foreach (var form in forms)
            {
                mdiParent.Invoke((Action)(() => form.Hide()));
            }
        }

        public static void DisposeMdiChildForms(Form mdiParent, List<Form> forms)
        {
            foreach (var form in forms)
            {
                mdiParent.Invoke((Action)(() => form.Dispose()));
            }
        }
    }
}
