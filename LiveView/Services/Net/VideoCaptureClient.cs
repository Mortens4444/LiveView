using Mtf.Controls.CustomEventArgs;
using Mtf.Network;
using Mtf.Network.EventArg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace LiveView.Services.Net
{
    public class VideoCaptureClient
    {
        private readonly Client client;
        private readonly List<byte> imageDataChunks = new List<byte>();

        public event EventHandler<FrameArrivedEventArgs> FrameArrived;

        public VideoCaptureClient(string serverIp, ushort serverPort)
        {
            if (serverIp == "0.0.0.0")
            {
                serverIp = "localhost";
            }
            client = new Client(serverIp, serverPort);
            client.DataArrived += ClientDataArrivedEventHandler;
            client.Connect();
            client.SetBufferSize(409600);
        }

        public static bool IsPngStart(byte[] bytes)
        {
            byte[] pngSignature = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };

            if (bytes == null || bytes.Length < pngSignature.Length)
            {
                return false;
            }

            for (int i = 0; i < pngSignature.Length; i++)
            {
                if (bytes[i] != pngSignature[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void ClientDataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            if (IsPngStart(e.Data))
            {
                imageDataChunks.Clear();
                imageDataChunks.AddRange(e.Data);
            }
            else
            {
                imageDataChunks.AddRange(e.Data);
            }
            if (IsCompleteImage(imageDataChunks))
            {
                var fullImageData = imageDataChunks.ToArray();
                OnFrameArrived(fullImageData);
                imageDataChunks.Clear();
            }
        }
        private bool IsCompleteImage(List<byte> imageData)
        {
            var pngEndMarker = new byte[] { 0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82 }; // IEND marker
            return imageData.Count >= pngEndMarker.Length &&
                imageData.Skip(imageData.Count - pngEndMarker.Length).SequenceEqual(pngEndMarker);
        }
        private void OnFrameArrived(byte[] fullImageData)
        {
            var image = Image.FromStream(new MemoryStream(fullImageData));
            FrameArrived?.Invoke(this, new FrameArrivedEventArgs(image));
        }

        //private void ClientDataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        //{
        //    if (ByteArrayStartsWith(e.Data, $"", client?.Encoding))
        //    {
        //        var delimiterCount = 0;
        //        var prefixLength = 0;

        //        for (var i = 0; i < e.Data.Length; i++)
        //        {
        //            if (e.Data[i] == (byte)'|')
        //            {
        //                delimiterCount++;
        //            }

        //            if (delimiterCount == 4)
        //            {
        //                prefixLength = i + 1;
        //                break;
        //            }
        //        }

        //        if (delimiterCount < 4)
        //        {
        //            throw new InvalidOperationException("The byte array does not contain 4 '|' characters.");
        //        }

        //        var prefix = client?.Encoding.GetString(e.Data, 0, prefixLength - 1);
        //        var remainingBytes = new ReadOnlySpan<byte>(e.Data, prefixLength, e.Data.Length - prefixLength);

        //        var messageParts = prefix.Split('|');
        //    }
        //}

        //public static bool ByteArrayStartsWith(byte[] byteArray, string prefix, Encoding encoding)
        //{
        //    if (byteArray == null || prefix == null || encoding == null)
        //    {
        //        throw new ArgumentNullException();
        //    }

        //    var prefixBytes = encoding.GetBytes(prefix);

        //    if (prefixBytes.Length > byteArray.Length)
        //    {
        //        return false;
        //    }

        //    for (var i = 0; i < prefixBytes.Length; i++)
        //    {
        //        if (byteArray[i] != prefixBytes[i])
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}
    }
}
