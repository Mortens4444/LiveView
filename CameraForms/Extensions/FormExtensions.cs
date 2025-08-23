using System.Windows.Forms;

namespace CameraForms.Extensions
{
    public static class FormExtensions
    {
        public static void Exit(this Form form)
        {
            try
            {
                form?.Close();
            }
            catch { }
            Application.Exit();
        }
    }
}
