using System.ComponentModel;

namespace Mtf.Enums.Software
{
    public enum ProductType : uint
    {
        [Description("Business Edition")]
        PRODUCT_BUSINESS = 0x00000006,
        [Description("Business N Edition")]
        PRODUCT_BUSINESS_N = 0x00000010,
        [Description("Cluster Server Edition")]
        PRODUCT_CLUSTER_SERVER = 0x00000012,
        [Description("Server Datacenter Edition (full installation)")]
        PRODUCT_DATACENTER_SERVER = 0x00000008,
        [Description("Server Datacenter Edition (core installation)")]
        PRODUCT_DATACENTER_SERVER_CORE = 0x0000000C,
        [Description("Server Datacenter without Hyper-V (full installation)")]
        PRODUCT_DATACENTER_SERVER_NO_HYPER_V = 0x00000025,
        [Description("Server Datacenter without Hyper-V (core installation)")]
        PRODUCT_DATACENTER_SERVER_CORE_NO_HYPER_V = 0x00000027,
        [Description("Enterprise Edition")]
        PRODUCT_ENTERPRISE = 0x00000004,
        [Description("Enterprise N Edition")]
        PRODUCT_ENTERPRISE_N = 0x0000001B,
        [Description("Enterprise E Edition")]
        PRODUCT_ENTERPRISE_E = 0x00000046,
        [Description("Essential Business Server Management Server")]
        PRODUCT_ESSENTIAL_SMALLBUSINESS_SERVER = 0x0000001E,
        [Description("Essential Business Server Messaging Server")]
        PRODUCT_ESSENTIAL_SMALLBUSINESS_MESSAGING_SERVER = 0x00000020,
        [Description("Essential Business Server Security Server")]
        PRODUCT_ESSENTIAL_SMALLBUSINESS_SECURITY_SERVER = 0x0000001F,
        [Description("Server Enterprise Edition (full installation)")]
        PRODUCT_ENTERPRISE_SERVER = 0x0000000A,
        [Description("Server Enterprise Edition (core installation)")]
        PRODUCT_ENTERPRISE_SERVER_CORE = 0x0000000E,
        [Description("Server Enterprise Edition for Itanium-based Systems")]
        PRODUCT_ENTERPRISE_SERVER_IA64 = 0x0000000F,
        [Description("Server Enterprise Edition without Hyper-V (full installation)")]
        PRODUCT_ENTERPRISE_SERVER_NO_HYPER_V = 0x00000026,
        [Description("Server Enterprise Edition without Hyper-V (core installation)")]
        PRODUCT_ENTERPRISE_SERVER_CORE_NO_HYPER_V = 0x00000029,
        [Description("Home Basic Edition")]
        PRODUCT_HOME_BASIC = 0x00000002,
        [Description("Home Basic E Edition")]
        PRODUCT_HOME_BASIC_E = 0x00000043,
        [Description("Home Basic N Edition")]
        PRODUCT_HOME_BASIC_N = 0x00000005,
        [Description("Home Premium Edition")]
        PRODUCT_HOME_PREMIUM = 0x00000003,
        [Description("Home Premium E Edition")]
        PRODUCT_HOME_PREMIUM_E = 0x00000044,
        [Description("Home Premium N Edition")]
        PRODUCT_HOME_PREMIUM_N = 0x0000001A,
        [Description("Home Server Edition")]
        PRODUCT_HOME_SERVER = 0x00000013,
        [Description("Microsoft Hyper-V Server")]
        MICROSOFT_HYPER_V_SERVER = 0x0000002A,
        [Description("Product unlicensed")]
        PRODUCT_UNLICENSED = 0xABCDABCD,
        [Description("Professional")]
        PROFFESIONAL = 0x00000030,
        [Description("Professional E")]
        PROFFESIONAL_E = 0x00000045,
        [Description("Professional N")]
        PROFFESIONAL_N = 0x00000031,
        [Description("Server for Small Business Edition")]
        PRODUCT_SERVER_FOR_SMALLBUSINESS = 0x00000018,
        [Description("Server for Small Business Edition without Hyper-V")]
        PRODUCT_SERVER_FOR_SMALLBUSINESS_NO_HYPER_V = 0x00000023,
        [Description("Server Foundation")]
        SERVER_FOUNDATION = 0x00000021,
        [Description("Small Business Server")]
        PRODUCT_SMALLBUSINESS_SERVER = 0x00000009,
        [Description("Small Business Server Premium Edition")]
        PRODUCT_SMALLBUSINESS_SERVER_PREMIUM = 0x00000019,
        [Description("Server Standard Edition (full installation)")]
        PRODUCT_STANDARD_SERVER = 0x00000007,
        [Description("Server Standard Edition (core installation)")]
        PRODUCT_STANDARD_SERVER_CORE = 0x0000000D,
        [Description("Server Standard Edition without Hyper-V (full installation)")]
        PRODUCT_STANDARD_SERVER_NO_HYPER_V = 0x00000024,
        [Description("Server Standard Edition without Hyper-V (core installation)")]
        PRODUCT_STANDARD_SERVER_CORE_NO_HYPER_V = 0x00000028,
        [Description("Starter Edition")]
        PRODUCT_STARTER = 0x0000000B,
        [Description("Starter E Edition")]
        PRODUCT_STARTER_E = 0x00000042,
        [Description("Starter N Edition")]
        PRODUCT_STARTER_N = 0x0000002F,
        [Description("Storage Server Enterprise Edition")]
        PRODUCT_STORAGE_ENTERPRISE_SERVER = 0x00000017,
        [Description("Storage Server Express Edition")]
        PRODUCT_STORAGE_EXPRESS_SERVER = 0x00000014,
        [Description("Storage Server Standard Edition")]
        PRODUCT_STORAGE_STANDARD_SERVER = 0x00000015,
        [Description("Storage Server Workgroup Edition")]
        PRODUCT_STORAGE_WORKGROUP_SERVER = 0x00000016,
        [Description("An unknown product")]
        PRODUCT_UNDEFINED = 0x00000000,
        [Description("Ultimate Edition")]
        PRODUCT_ULTIMATE = 0x00000001,
        [Description("Ultimate E Edition")]
        PRODUCT_ULTIMATE_E = 0x00000047,
        [Description("Ultimate N Edition")]
        PRODUCT_ULTIMATE_N = 0x0000001C,
        [Description("Web Server Edition (full installation)")]
        PRODUCT_WEB_SERVER = 0x00000011,
        [Description("Web Server Edition (core installation)")]
        PRODUCT_WEB_SERVER_CORE = 0x0000001D,
    }

}
