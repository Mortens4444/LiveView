using LiveView.Dto;
using Mtf.Database.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LiveView.Services
{
    public class SziltechDeviceChecker
    {
        private static readonly List<SziltechDeviceInfo> devices;

        static SziltechDeviceChecker()
        {
            devices = GetDevices();
        }

        public bool IsSziltechDevice(string dongleSerial, out SziltechDeviceInfo sziltechDeviceInfo)
        {
            sziltechDeviceInfo = devices.FirstOrDefault(device => String.Equals(device.DongleSerial, dongleSerial, StringComparison.OrdinalIgnoreCase));
            return sziltechDeviceInfo != null;
        }

        private static List<SziltechDeviceInfo> GetDevices()
        {
            var result = new List<SziltechDeviceInfo>();

            using (var stream = Mtf.Database.Services.ResourceHelper.GetEmbeddedResourceStream(@"LiveView.Resources.SziltechDevices.txt", typeof(SziltechDeviceChecker).Assembly))
            using (var streamReader = new StreamReader(stream))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var deviceData = line.Split(';');
                    result.Add(new SziltechDeviceInfo
                    {
                        DongleSerial = deviceData[0],
                        Model = deviceData[1]
                    });
                }
            }

            return result;
        }
    }
}
