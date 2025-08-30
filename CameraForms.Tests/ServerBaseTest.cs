using Mtf.Network;
using NUnit.Framework;

namespace CameraForms.Tests
{
    public abstract class ServerBaseTest
    {
        protected static Server Server { get; }

        static ServerBaseTest()
        {
            Server = new Server(listenerPort: 4444);
            Server.Start();
        }

        [OneTimeTearDown]
        public void BaseTearDown()
        {
            Server?.Stop();
            Server?.Dispose();
        }
    }
}
