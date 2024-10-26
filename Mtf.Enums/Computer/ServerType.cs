namespace Mtf.Enums.Computer
{
    public enum ServerType : uint
    {
        /// <summary>
        /// All workstations.
        /// </summary>
        SV_TYPE_WORKSTATION = 0x00000001,
        /// <summary>
        /// All computers that run the Server service.
        /// </summary>
        SV_TYPE_SERVER = 0x00000002,
        /// <summary>
        /// Any server that runs an instance of Microsoft SQL Server.
        /// </summary>
        SV_TYPE_SQLSERVER = 0x00000004,
        /// <summary>
        /// A server that is primary domain controller.
        /// </summary>
        SV_TYPE_DOMAIN_CTRL = 0x00000008,
        /// <summary>
        /// Any server that is a backup domain controller.
        /// </summary>
        SV_TYPE_DOMAIN_BAKCTRL = 0x00000010,
        /// <summary>
        /// Any server that runs the Timesource service.
        /// </summary>
        SV_TYPE_TIME_SOURCE = 0x00000020,
        /// <summary>
        /// Any server that runs the Apple Filing Protocol (AFP) file service.
        /// </summary>
        SV_TYPE_AFP = 0x00000040,
        /// <summary>
        /// Any server that is a Novell server.
        /// </summary>
        SV_TYPE_NOVELL = 0x00000080,
        /// <summary>
        /// Any computer that is LAN Manager 2.x domain member.
        /// </summary>
        SV_TYPE_DOMAIN_MEMBER = 0x00000100,
        /// <summary>
        /// Any computer that shares a print queue.
        /// </summary>
        SV_TYPE_PRINTQ_SERVER = 0x00000200,
        /// <summary>
        /// Any server that runs a dial-in service.
        /// </summary>
        SV_TYPE_DIALIN_SERVER = 0x00000400,
        /// <summary>
        /// Any server that is a Xenix server.
        /// </summary>
        SV_TYPE_XENIX_SERVER = 0x00000800,
        /// <summary>
        /// Any server that is a UNIX server. This is the same as the SV_TYPE_XENIX_SERVER.
        /// </summary>
        SV_TYPE_SERVER_UNIX = 0x00000800,
        /// <summary>
        /// A workstation or server.
        /// </summary>
        SV_TYPE_NT = 0x00001000,
        /// <summary>
        /// Any computer that runs Windows for Workgroups.
        /// </summary>
        SV_TYPE_WFW = 0x00002000,
        /// <summary>
        /// Any server that runs the Microsoft File and Print for NetWare service.
        /// </summary>
        SV_TYPE_SERVER_MFPN = 0x00004000,
        /// <summary>
        /// Any server that is not a domain controller.
        /// </summary>
        SV_TYPE_SERVER_NT = 0x00008000,
        /// <summary>
        /// Any computer that can run the browser service.
        /// </summary>
        SV_TYPE_POTENTIAL_BROWSER = 0x00010000,
        /// <summary>
        /// A computer that runs a browser service as backup.
        /// </summary>
        SV_TYPE_BACKUP_BROWSER = 0x00020000,
        /// <summary>
        /// A computer that runs the master browser service.
        /// </summary>
        SV_TYPE_MASTER_BROWSER = 0x00040000,
        /// <summary>
        /// A computer that runs the domain master browser.
        /// </summary>
        SV_TYPE_DOMAIN_MASTER = 0x00080000,
        /// <summary>
        /// A computer that runs OSF/1.
        /// </summary>
        SV_TYPE_SERVER_OSF = 0x00100000,
        /// <summary>
        /// A computer that runs Open Virtual Memory System (VMS).
        /// </summary>
        SV_TYPE_SERVER_VMS = 0x00200000,
        /// <summary>
        /// A computer that runs Windows.
        /// </summary>
        SV_TYPE_WINDOWS = 0x00400000,
        /// <summary>
        /// A computer that is the root of Distributed File System (DFS) tree.
        /// </summary>
        SV_TYPE_DFS = 0x00800000,
        /// <summary>
        /// Server clusters available in the domain.
        /// </summary>
        SV_TYPE_CLUSTER_NT = 0x01000000,
        /// <summary>
        /// A server running the Terminal Server service.
        /// </summary>
        SV_TYPE_TERMINALSERVER = 0x02000000,
        /// <summary>
        /// Cluster virtual servers available in the domain. Windows 2000: This value is not supported.
        /// </summary>
        SV_TYPE_CLUSTER_VS_NT = 0x04000000,
        /// <summary>
        /// A computer that runs IBM Directory and Security Services (DSS) or equivalent.
        /// </summary>
        SV_TYPE_DCE = 0x10000000,
        /// <summary>
        /// A computer that over an alternate transport.
        /// </summary>
        SV_TYPE_ALTERNATE_XPORT = 0x20000000,
        /// <summary>
        /// Any computer maintained in a list by the browser. See the following Remarks section.
        /// </summary>
        SV_TYPE_LOCAL_LIST_ONLY = 0x40000000,
        /// <summary>
        /// The primary domain.
        /// </summary>
        SV_TYPE_DOMAIN_ENUM = 0x80000000,
        /// <summary>
        /// All servers. This is a convenience that will return all possible servers.
        /// </summary>
        SV_TYPE_ALL = 0xFFFFFFFF
    }

}
