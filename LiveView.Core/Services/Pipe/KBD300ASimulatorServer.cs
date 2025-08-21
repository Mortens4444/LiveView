using Mtf.MessageBoxes;
using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

namespace LiveView.Core.Services.Pipe
{
    public class KBD300ASimulatorServer
    {
        private CancellationTokenSource cts = new CancellationTokenSource();
        private Task serverTask;

        public void StartPipeServerAsync(string pipeName)
        {
            cts = new CancellationTokenSource();
            var token = cts.Token;

            serverTask = Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    using (var server = new NamedPipeServerStream(pipeName, PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous))
                    {
                        try
                        {
#if NET452
                            server.WaitForConnection();
#else
                            await server.WaitForConnectionAsync(token).ConfigureAwait(false);
#endif

                            using (var reader = new StreamReader(server))
                            {
                                string message;

                                while (!token.IsCancellationRequested && (message = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
                                {
                                    InfoBox.Show("Information", $"Unknown message arrived: {message}");
                                }
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            break;
                        }
                        catch (IOException)
                        {
                            // Client disconnected, continue listening
                        }
                    }
                }
            }, token);
        }

        public void Stop()
        {
            cts.Cancel();
            serverTask?.Wait();
            cts.Dispose();
            cts = new CancellationTokenSource();
        }
    }
}
