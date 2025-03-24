using LiveView.Core.Services;
using LiveView.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LiveView.Services
{
    public class SearchCameraUrlService
    {
        private readonly Dictionary<string, List<string>> cameraUrls = new Dictionary<string, List<string>>();
        private const string TargetNamespace = "LiveView.Resources.CameraUrls.";

        public SearchCameraUrlService()
        {
            InitializeCameraUrls();
        }

        public List<string> GetManufacturers()
        {
            return cameraUrls.Keys.ToList();
        }

        public List<string> GetCameraUrls(string manufacturer)
        {
            return cameraUrls[manufacturer].ToList();
        }

        public List<string> GetAllCameraUrls()
        {
            return cameraUrls
                .SelectMany(c => c.Value)
                .Distinct()
                .OrderBy(url => url)
                .ToList();
        }

        public string FindCameraUrl(NetCamera camera, int timeoutMs)
        {
            var cameraUrls = GetAllCameraUrls();
            foreach (var cameraUrl in cameraUrls)
            {
                var url = cameraUrl.ToString();
                url = ModifyUrl(camera, url);

                if (UriCaller.CallUrl(url, timeoutMs))
                {
                    return url;
                }
            }
            return String.Empty;
        }

        public static string ModifyUrl(NetCamera camera, string url)
        {
            if (!String.IsNullOrEmpty(camera.Username) || !String.IsNullOrEmpty(camera.Password))
            {
                url = url.Replace("[USERNAME]", camera.Username);
                url = url.Replace("[PASSWORD]", camera.Password);
            }
            else
            {
                url = url.Replace("[USERNAME]:[PASSWORD]@", String.Empty);
            }
            url = url.Replace("[IP_ADDRESS]", camera.IpAddress);
            url = url.Replace("[CHANNEL]", camera.Channel.ToString());

            if (url.Contains("[WIDTH]"))
            {
                url = url.Replace("[WIDTH]", camera.Width.ToString());
                url = url.Replace("[HEIGHT]", camera.Height.ToString());
            }

            return url;
        }

        private void InitializeCameraUrls()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resources = assembly.GetManifestResourceNames()
                .Where(name => name.StartsWith(TargetNamespace))
                .OrderBy(name => name)
                .ToList();

            foreach (var resource in resources)
            {
                var lines = ResourceHelper.ReadEmbeddedResourceByLines(resource);
                var name = Path.GetFileNameWithoutExtension(resource).Replace(TargetNamespace, String.Empty);
                cameraUrls[name] = lines.ToList();
            }
        }
    }

}
