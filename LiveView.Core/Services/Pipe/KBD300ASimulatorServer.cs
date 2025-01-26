using System.IO.Pipes;
using System.IO;
using Mtf.MessageBoxes;

namespace LiveView.Core.Services.Pipe
{
    public class KBD300ASimulatorServer
    {
        public async void StartPipeServerAsync(string pipeName)
        {
            while (true)
            {
                using (var server = new NamedPipeServerStream(pipeName, PipeDirection.In))
                {
                    await server.WaitForConnectionAsync().ConfigureAwait(false);
                    using (var reader = new StreamReader(server))
                    {
                        string message;
                        while ((message = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
                        {
                            InfoBox.Show("Information", $"Unknown message arrived: {message}");
                        }
                    }
                }
            }
        }
    }
}
