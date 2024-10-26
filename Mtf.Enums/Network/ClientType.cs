namespace Mtf.Enums.Network
{
    public enum ClientType : ushort
    {
        /// <summary>Daytime service</summary>
        /// <seealso cref="NIST"/>
        DAYTIME = 13,

        /// <summary>Web client (TCP/IP) (No encrypting).</summary>
        /// <seealso cref="HTTPS"/>
        HTTP = 80,

        /// <summary>Web client (TCP/IP).</summary>
        /// <seealso cref="HTTP"/>
        HTTPS = 443,

        /// <summary>FTP client (TCP/IP) (No encrypting).</summary>
        /// <seealso cref="FTPS_CONTROL"/>
        FTP_CONTROL = 21,

        /// <summary>FTP client (TCP/IP) (No encrypting).</summary>
        /// <seealso cref="FTPS_DATA"/>
        FTP_DATA = 20,

        /// <summary>FTP client (TCP/IP).</summary>
        /// <seealso cref="FTPS_CONTROL"/>
        FTPS_CONTROL = 990,

        /// <summary>FTP client (TCP/IP).</summary>
        /// <seealso cref="FTPS_DATA"/>
        FTPS_DATA = 989,

        /// <summary>IMAP client (TCP/IP).</summary>
        /// <seealso cref="POP3"/>
        IMAP = 143,

        /// <summary>POP3 client (TCP/IP)</summary>
        /// <seealso cref="IMAP"/>
        POP3 = 110,

        /// <summary>RAID_CONTROLLER_3DM Client</summary>
        RAID_CONTROLLER_3DM = 888,

        /// <summary>
        /// Real Time Streaming Protocol
        /// </summary>
        RTSP = 554,

        /// <summary>SNMP client. (UDP)</summary>
        SNMP = 161,

        /// <summary>SMTP client. (TCP/IP)</summary>
        SMTP = 25,

        /// <summary>SSH client.</summary>
        /// <seealso cref="SSH"/>
        SSH = 22,

        /// <summary>Telnet client (No encrypting).</summary>
        /// <seealso cref="SSH"/>
        Telnet = 23,

        /// <summary>Custom protocol for Sziltech.</summary>
        NP = 4525,

        /// <summary>Custom communication protocol for Sziltech.</summary>
        NCP = 4526,

        /// <summary>Camera moving port for Sziltech</summary>
        MCP = 49763,

        /// <summary>Custom protocol for Sziltech.</summary>
        NetworkManagement = 18793,

        /// <summary>Upnp port.</summary>
        UpnpPort = 1900
    }
}
