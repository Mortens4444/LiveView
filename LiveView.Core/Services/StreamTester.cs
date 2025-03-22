using Mtf.MessageBoxes;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;

namespace LiveView.Core.Services
{
    public static class StreamTester
    {
        public static bool TestUrl(string url, int timeoutMs = 100)
        {
            if (String.IsNullOrWhiteSpace(url))
            {
                return false;
            }

            if (url.StartsWith("rtsp:"))
            {
                return TestRtspUrl(url, timeoutMs);
            }
            else if (url.StartsWith("mms:"))
            {
                return TestMmsUrl(url, timeoutMs);
            }
            return TestHttpUrl(url, timeoutMs);
        }

        private static bool TestHttpUrl(string url, int timeoutMs)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMilliseconds(timeoutMs);
                    var request = new HttpRequestMessage(HttpMethod.Head, url);
                    var response = client.SendAsync(request).Result;
                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception _)
            {
                try
                {
                    var uri = new Uri(url);

                    HttpClient client;
                    string cleanedUrl;
                    if (!String.IsNullOrEmpty(uri.UserInfo))
                    {
                        var user = uri.UserInfo.Split(':')[0];
                        var pass = uri.UserInfo.Split(':')[1];
                        cleanedUrl = $"{uri.Scheme}://{uri.Host}{uri.PathAndQuery}";
                        client = new HttpClient(new HttpClientHandler
                        {
                            Credentials = new NetworkCredential(user, pass)
                        })
                        {
                            Timeout = TimeSpan.FromMilliseconds(timeoutMs)
                        };

                        var byteArray = Encoding.ASCII.GetBytes($"{user}:{pass}");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    }
                    else
                    {
                        client = new HttpClient
                        {
                            Timeout = TimeSpan.FromMilliseconds(timeoutMs)
                        };
                        cleanedUrl = url;
                    }

                    using (client)
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, cleanedUrl);
                        var response = client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
                        return response.IsSuccessStatusCode;
                    }
                }
                catch (Exception __)
                {
                    return false;
                }
            }
        }

        private static bool TestRtspUrl(string url, int timeoutMs)
        {
            try
            {
                var uri = new Uri(url);
                var host = uri.Host;
                var port = uri.Port > 0 ? uri.Port : 554;

                using (var client = new TcpClient())
                {
                    var result = client.BeginConnect(host, port, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(timeoutMs));

                    if (!success)
                    {
                        return false;
                    }

                    using (var stream = client.GetStream())
                    using (var writer = new StreamWriter(stream))
                    using (var reader = new StreamReader(stream))
                    {
                        writer.WriteLine($"DESCRIBE {url} RTSP/1.0");
                        writer.WriteLine($"CSeq: 1");
                        writer.WriteLine($"User-Agent: TestRTSPClient");
                        writer.WriteLine($"Accept: application/sdp");
                        writer.WriteLine();
                        writer.Flush();

                        var response = new StringBuilder();
                        var buffer = new char[1024];
                        int bytesRead;

                        while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            response.Append(buffer, 0, bytesRead);
                            if (response.ToString().Contains("\r\n\r\n"))
                            {
                                break;
                            }
                        }

                        var responseString = response.ToString();
                        return responseString.Contains("RTSP/1.0 200 OK");
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private static bool TestMmsUrl(string url, int timeoutMs)
        {
            try
            {
                var uri = new Uri(url);
                var host = uri.Host;
                var port = uri.Port > 0 ? uri.Port : 1755;

                using (var client = new TcpClient())
                {
                    var result = client.BeginConnect(host, port, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(timeoutMs));
                    if (success)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
            return false;
        }
    }
}
