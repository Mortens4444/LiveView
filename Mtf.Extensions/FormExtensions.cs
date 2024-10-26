using Mtf.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Extensions
{
    public static class FormExtensions
    {
        public static void SetLocationAndSize(this Form form, FormPosition formPosition)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            if (formPosition != null)
            {
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(formPosition.X, formPosition.Y);
                form.Size = new Size(formPosition.Width, formPosition.Height);
            }
        }
    }
}
