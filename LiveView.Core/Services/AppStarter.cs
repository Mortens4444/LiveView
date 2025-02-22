using Microsoft.Extensions.Logging;
using Mtf.MessageBoxes;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LiveView.Core.Services
{
    public static class AppStarter
    {
        public static Process Start(string path, string arguments = "", ILogger logger = null)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(path))
                {
                    throw new ArgumentException("The path cannot be null or empty.", nameof(path));
                }

                if (!File.Exists(path))
                {
                    path = Path.Combine(Application.StartupPath, path);
                }
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"The file '{path}' does not exist.");
                }

                var processStartInfo = new ProcessStartInfo
                {
                    FileName = path,
                    Arguments = arguments,
                    UseShellExecute = true
                };

                return Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Application start failed.");
                ErrorBox.Show(ex);
                return null;
            }
        }
    }
}
