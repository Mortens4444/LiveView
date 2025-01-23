using CameraApp.Forms;
using Database.Repositories;
using Mtf.Database;
using Mtf.MessageBoxes;
using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CameraApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

//#if NETFRAMEWORK
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //#else
            //            ApplicationConfiguration.Initialize();
            //#endif

            BaseRepository.CommandTimeout = 240;
            BaseRepository.DatabaseScriptsAssembly = typeof(CameraRepository).Assembly;
            BaseRepository.DatabaseScriptsLocation = "Database.Scripts";

            BaseRepository.ConnectionString = ConfigurationManager.ConnectionStrings["LiveViewConnectionString"]?.ConnectionString;
            //InfoBox.Show("Camera app started", $"{String.Join(" ", args)}");

            try
            {
                if (args.Length == 2)
                {
                    long userId = Convert.ToInt64(args[0], CultureInfo.InvariantCulture);
                    long cameraId = Convert.ToInt64(args[1], CultureInfo.InvariantCulture);
                    using (var form = new AxVideoCameraWindow(userId, cameraId, null))
                    {
                        Application.Run(form);
                    }
                }
                if (args.Length == 3)
                {
                    long userId = Convert.ToInt64(args[0], CultureInfo.InvariantCulture);
                    if (Int64.TryParse(args[1], out var cameraId))
                    {
                        long? displayId = Convert.ToInt64(args[2], CultureInfo.InvariantCulture);
                        using (var form = new AxVideoCameraWindow(userId, cameraId, displayId))
                        {
                            Application.Run(form);
                        }
                    }
                    else
                    {
                        var serverIp = args[1];
                        var videoCaptureSource = args[2];
                        using (var form = new VideoSourceCameraWindow(userId, serverIp, videoCaptureSource, null))
                        {
                            Application.Run(form);
                        }
                    }
                }
                else if (args.Length == 4)
                {
                    long userId = Convert.ToInt64(args[0], CultureInfo.InvariantCulture);
                    var serverIp = args[1];
                    var videoCaptureSource = args[2];
                    long? displayId = Convert.ToInt64(args[3], CultureInfo.InvariantCulture);
                    using (var form = new VideoSourceCameraWindow(userId, serverIp, videoCaptureSource, displayId))
                    {
                        Application.Run(form);
                    }
                }
                else if (args.Length == 6)
                {
                    long userId = Convert.ToInt64(args[0], CultureInfo.InvariantCulture);
                    long cameraId = Convert.ToInt64(args[1], CultureInfo.InvariantCulture);
                    int x = Convert.ToInt32(args[2], CultureInfo.InvariantCulture);
                    int y = Convert.ToInt32(args[3], CultureInfo.InvariantCulture);
                    int width = Convert.ToInt32(args[4], CultureInfo.InvariantCulture);
                    int height = Convert.ToInt32(args[5], CultureInfo.InvariantCulture);
                    using (var form = new AxVideoCameraWindow(userId, cameraId, new Point(x, y), new Size(width, height)))
                    {
                        Application.Run(form);
                    }
                }
                else if (args.Length == 7)
                {
                    long userId = Convert.ToInt64(args[0], CultureInfo.InvariantCulture);
                    var serverIp = args[1];
                    var videoCaptureSource = args[2];
                    int x = Convert.ToInt32(args[3], CultureInfo.InvariantCulture);
                    int y = Convert.ToInt32(args[4], CultureInfo.InvariantCulture);
                    int width = Convert.ToInt32(args[5], CultureInfo.InvariantCulture);
                    int height = Convert.ToInt32(args[6], CultureInfo.InvariantCulture);
                    using (var form = new VideoSourceCameraWindow(userId, serverIp, videoCaptureSource, new Point(x, y), new Size(width, height)))
                    {
                        Application.Run(form);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorBox.Show(ex);
            }
        }
    }
}