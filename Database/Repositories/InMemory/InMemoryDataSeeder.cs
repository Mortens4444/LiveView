using Database.Enums;
using Database.Models;
using Database.Services.PasswordHashers;
using System;
using System.Linq;

namespace Database.Repositories.InMemory;

/// <summary>
/// Fills the in-memory storage with the rows that InsertInitialData.sql creates in a new database
/// (built-in admin user, groups, the default user event and the barcode scanner defaults), plus an auto-login for admin
/// and a credential-less localhost video server, so the application is usable right after start.
/// </summary>
public static class InMemoryDataSeeder
{
    public static void Seed()
    {
        lock (InMemoryStore.SyncRoot)
        {
            if (InMemoryStore<User>.Items.Any())
            {
                return;
            }

            // The built-in Sziltech user of InsertInitialData.sql is intentionally not created: the vendor account must not be usable
            // in in-memory mode. The password of "admin" is hashed here, because the hash depends on the cipher keys of the environment
            // and in-memory mode must always allow admin/admin.
            var users = new InMemoryUserRepository();
            var adminUserId = users.InsertAndReturnId<int>(new User
            {
                EncryptedUsername = UserPasswordHasher.UsernameEncrypt("admin"),
                EncryptedPassword = UserPasswordHasher.Hash("admin"),
                SecondaryLogonPriority = 100,
                NeededSecondaryLogonPriority = 0
            });

            var groups = new InMemoryGroupRepository();
            groups.Insert(new Group
            {
                Name = "BUILTIN_DEV_GRP",
                OtherInformation = "Be\u00e9p\u00edtett csoport a Sziltech Electronic Kft. munkat\u00e1rsai sz\u00e1m\u00e1ra"
            });
            groups.Insert(new Group
            {
                Name = "BUILTIN_ADMIN_GRP",
                OtherInformation = "Be\u00e9p\u00edtett csoport a rendszer adminisztr\u00e1torainak",
                ParentGroupId = 1
            });

            var groupMembers = new InMemoryGroupMembersRepository();
            groupMembers.Insert(new GroupMember { UserId = adminUserId, GroupId = 2 });

            // admin logs in automatically at startup (see MainPresenter.AutoLogin), so the application is usable without any setup.
            new InMemoryGeneralOptionsRepository().Set(Setting.AutoLoginUser, "admin");

            // A video server on this machine without credentials, so a local video server can be used right away.
            new InMemoryVideoServerRepository().Insert(new VideoServer
            {
                Hostname = "localhost",
                IpAddress = "127.0.0.1",
                MacAddress = String.Empty,
                DongleSn = String.Empty,
                SerialNumber = String.Empty,
                EncryptedUsername = VideoServerPasswordCryptor.UsernameEncrypt(String.Empty),
                EncryptedPassword = VideoServerPasswordCryptor.PasswordEncrypt(String.Empty),
                EncryptedWinUser = WindowsPasswordCryptor.UsernameEncrypt(String.Empty),
                EncryptedWinPass = WindowsPasswordCryptor.PasswordEncrypt(String.Empty)
            });

            new InMemoryUserEventRepository().Insert(new UserEvent
            {
                Name = "Alaphelyzet",
                Note = "Nincs sem pozit\u00edv, sem negat\u00edv elb\u00edr\u00e1l\u00e1s a felhaszn\u00e1l\u00f3kkal szemben."
            });

            new InMemoryBarcodeScanOptionsRepository().Insert(new BarcodeScanOptions
            {
                LcidIn = 1038,
                LcidOut = 1033,
                MaxDelay = 50,
                CustomIn = 0,
                CustomOut = 0,
                SerialScanner = false,
                SelectedComPort = -1
            });

            var barcodeCharChangers = new InMemoryBarcodeCharChangerRepository();
            barcodeCharChangers.Insert(new BarcodeCharChanger { Id = 1033, Chars = "`1234567890-=qwertyuiop[]asdfghjkl;'\\\\\\\\zxcvbnm,./ ~!@#$%&*()_+QWERTYUIOP{}ASDFGHJKL\\\"||ZXCVBNM<>? " });
            barcodeCharChangers.Insert(new BarcodeCharChanger { Id = 1038, Chars = "0123456789\u00f6\u00fc\u00f3qwertzuiop\u0151\u00faasdfghjkl\u00e9\u00e1\u0171\u00edyxcvbnm,.- \u00a7'\\\"+!%/=()\u00d6\u00dc\u00d3QWERTZUIOP\u0150\u00daASDFGHJKL\u00c9\u00c1\u0170\u00cdYXCVBNM?_ " });
        }
    }
}
