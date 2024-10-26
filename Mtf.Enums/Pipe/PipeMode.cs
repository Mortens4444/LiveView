using System;

namespace Mtf.Enums.Pipe
{
    [Flags]
    public enum PipeMode : uint
    {
        /// <summary>
        /// Data is written to the pipe as a stream of bytes. This mode cannot be used with PIPE_READMODE_MESSAGE.
        /// </summary>
        PIPE_TYPE_BYTE = 0x00000000,

        /// <summary>
        /// Data is written to the pipe as a stream of messages. This mode can be used with either PIPE_READMODE_MESSAGE or PIPE_READMODE_BYTE.
        /// </summary>
        PIPE_TYPE_MESSAGE = 0x00000004,

        /// <summary>
        /// Data is read from the pipe as a stream of bytes. This mode can be used with either PIPE_TYPE_MESSAGE or PIPE_TYPE_BYTE.
        /// </summary>
        PIPE_READMODE_BYTE = 0x00000000,

        /// <summary>
        /// Data is read from the pipe as a stream of messages. This mode can be only used if PIPE_TYPE_MESSAGE is also specified.
        /// </summary>
        PIPE_READMODE_MESSAGE = 0x00000002,

        /// <summary>
        /// Blocking mode is enabled. When the pipe handle is specified in the ReadFile, WriteFile, or ConnectNamedPipe function, the operations are not completed until there is data to read, all data is written, or a client is connected. Use of this mode can mean waiting indefinitely in some situations for a client process to perform an action.
        /// </summary>
        PIPE_WAIT = 0x00000000,

        /// <summary>
        /// Nonblocking mode is enabled. In this mode, ReadFile, WriteFile, and ConnectNamedPipe always return immediately.
        /// Note that nonblocking mode is supported for compatibility with Microsoft LAN Manager version 2.0 and should not be used to achieve asynchronous I/O with named pipes. For more information on asynchronous pipe I/O, see Synchronous and Overlapped Input and Output.
        /// </summary>
        PIPE_NOWAIT = 0x00000001,

        /// <summary>
        /// Connections from remote clients can be accepted and checked against the security descriptor for the pipe.
        /// Windows Server 2003 and Windows XP/2000/NT:  This flag is not supported.
        /// </summary>
        PIPE_ACCEPT_REMOTE_CLIENTS = 0x00000000,

        /// <summary>
        /// Connections from remote clients are automatically rejected.
        /// Windows Server 2003 and Windows XP/2000/NT:  This flag is not supported. To achieve the same results, deny access to the pipe to the NETWORK ACE.
        /// </summary>
        PIPE_REJECT_REMOTE_CLIENTS = 0x00000008,
    }
}
