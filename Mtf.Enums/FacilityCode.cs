using System.ComponentModel;

namespace Mtf.Enums
{
    public enum FacilityCode : short
    {
        [Description("The default facility code.")]
        FACILITY_NULL = 0,
        [Description("The source of the error code is an RPC subsystem.")]
        FACILITY_RPC = 1,
        [Description("The source of the error code is a COM Dispatch.")]
        FACILITY_DISPATCH = 2,
        [Description("The source of the error code is OLE Storage.")]
        FACILITY_STORAGE = 3,
        [Description("The source of the error code is COM/OLE Interface management.")]
        FACILITY_ITF = 4,
        [Description("This region is reserved to map undecorated error codes into HRESULTs.")]
        FACILITY_WIN32 = 7,
        [Description("The source of the error code is the Windows subsystem.")]
        FACILITY_WINDOWS = 8,
        [Description("The source of the error code is the Security API layer.")]
        FACILITY_SECURITY = 9,
        [Description("The source of the error code is the Security API layer.")]
        FACILITY_SSPI = 9,
        [Description("The source of the error code is the control mechanism.")]
        FACILITY_CONTROL = 10,
        [Description("The source of the error code is a certificate client or server?")]
        FACILITY_CERT = 11,
        [Description("The source of the error code is Wininet related.")]
        FACILITY_INTERNET = 12,
        [Description("The source of the error code is the Windows Media Server.")]
        FACILITY_MEDIASERVER = 13,
        [Description("The source of the error code is the Microsoft Message Queue.")]
        FACILITY_MSMQ = 14,
        [Description("The source of the error code is the Setup API.")]
        FACILITY_SETUPAPI = 15,
        [Description("The source of the error code is the Smart-card subsystem.")]
        FACILITY_SCARD = 16,
        [Description("The source of the error code is COM+.")]
        FACILITY_COMPLUS = 17,
        [Description("The source of the error code is the Microsoft agent.")]
        FACILITY_AAF = 18,
        [Description("The source of the error code is .NET CLR.")]
        FACILITY_URT = 19,
        [Description("The source of the error code is the audit collection service.")]
        FACILITY_ACS = 20,
        [Description("The source of the error code is Direct Play.")]
        FACILITY_DPLAY = 21,
        [Description("The source of the error code is the ubiquitous memoryintrospection service.")]
        FACILITY_UMI = 22,
        [Description("The source of the error code is Side-by-side servicing.")]
        FACILITY_SXS = 23,
        [Description("The error code is specific to Windows CE.")]
        FACILITY_WINDOWS_CE = 24,
        [Description("The source of the error code is HTTP support.")]
        FACILITY_HTTP = 25,
        [Description("The source of the error code is common Logging support.")]
        FACILITY_USERMODE_COMMONLOG = 26,
        [Description("The source of the error code is the user mode filter manager.")]
        FACILITY_USERMODE_FILTER_MANAGER = 31,
        [Description("The source of the error code is background copy control")]
        FACILITY_BACKGROUNDCOPY = 32,
        [Description("The source of the error code is configuration services.")]
        FACILITY_CONFIGURATION = 33,
        [Description("The source of the error code is state management services.")]
        FACILITY_STATE_MANAGEMENT = 34,
        [Description("The source of the error code is the Microsoft Identity Server.")]
        FACILITY_METADIRECTORY = 35,
        [Description("The source of the error code is a Windows update.")]
        FACILITY_WINDOWSUPDATE = 36,
        [Description("The source of the error code is Active Directory.")]
        FACILITY_DIRECTORYSERVICE = 37,
        [Description("The source of the error code is the graphics drivers.")]
        FACILITY_GRAPHICS = 38,
        [Description("The source of the error code is the user Shell.")]
        FACILITY_SHELL = 39,
        [Description("The source of the error code is the Trusted Platform Module services.")]
        FACILITY_TPM_SERVICES = 40,
        [Description("The source of the error code is the Trusted Platform Module applications.")]
        FACILITY_TPM_SOFTWARE = 41,
        [Description("The source of the error code is Performance Logs and Alerts")]
        FACILITY_PLA = 48,
        [Description("The source of the error code is Full volume encryption.")]
        FACILITY_FVE = 49,
        [Description("The source of the error code is the Firewall Platform.")]
        FACILITY_FWP = 50,
        [Description("The source of the error code is the Windows Resource Manager.")]
        FACILITY_WINRM = 51,
        [Description("The source of the error code is the Network Driver Interface.")]
        FACILITY_NDIS = 52,
        [Description("The source of the error code is the Usermode Hypervisor components.")]
        FACILITY_USERMODE_HYPERVISOR = 53,
        [Description("The source of the error code is the Configuration Management Infrastructure.")]
        FACILITY_CMI = 54,
        [Description("The source of the error code is the user mode virtualization subsystem.")]
        FACILITY_USERMODE_VIRTUALIZATION = 55,
        [Description("The source of the error code is the user mode volume manager")]
        FACILITY_USERMODE_VOLMGR = 56,
        [Description("The source of the error code is the Boot Configuration Database.")]
        FACILITY_BCD = 57,
        [Description("The source of the error code is user mode virtual hard disk support.")]
        FACILITY_USERMODE_VHD = 58,
        [Description("The source of the error code is System Diagnostics.")]
        FACILITY_SDIAG = 60,
        [Description("The source of the error code is the Web Services.")]
        FACILITY_WEBSERVICES = 61,
        [Description("The source of the error code is a Windows Defender component.")]
        FACILITY_WINDOWS_DEFENDER = 80,
        [Description("The source of the error code is the open connectivity service.")]
        FACILITY_OPC = 81
    }
}
