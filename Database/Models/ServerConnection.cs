using System;
using System.Collections.Generic;

namespace Database.Models
{
    public class ServerConnection
    {
        public ServerConnection() { }

        public ServerConnection(IList<string> args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            if (args.Count != 11)
            {
                throw new ArgumentException($"Args array length sould be 11, but it is {args.Count}. Check the encryption...");
            }

            IpOrHost = args[0];
            CameraName = args[1];
            CameraGuid = args[2];
            VideoServerUsername = args[3];
            VideoServerEncryptedPassword = args[9];
        }

        public string IpOrHost { get; set; }

        public string CameraName { get; set; }

        public string CameraGuid { get; set; }

        public string VideoServerUsername { get; set; }

        public string VideoServerEncryptedPassword { get; set; }
    }
}
