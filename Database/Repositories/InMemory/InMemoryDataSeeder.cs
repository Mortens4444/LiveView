using Database.Models;
using Database.Services.PasswordHashers;
using System.Linq;

namespace Database.Repositories.InMemory;

/// <summary>
/// Fills the in-memory storage with the rows that InsertInitialData.sql creates in a new database
/// (built-in users, groups, the default user event and the barcode scanner defaults).
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

            // The hash of the Sziltech user is the same constant as in InsertInitialData.sql. The password of "admin" is hashed here instead,
            // because the hash depends on the cipher keys of the environment and in-memory mode must always allow admin/admin.
            var users = new InMemoryUserRepository();
            users.Insert(new User
            {
                EncryptedUsername = UserPasswordHasher.UsernameEncrypt("Sziltech"),
                EncryptedPassword = "81d2c3b1ad3f54ad6d0f5792282c9eaf2784352ec3f6f2144c061768235ae64e",
                FullName = "Sziltech Electronic Kft",
                Address = "4029 Debrecen, F\u00e9nyes udvar 3. 8. em. 48.",
                Email = "info@sziltech.hu",
                Phone = "+36 52 452 172",
                SecondaryLogonPriority = 100,
                NeededSecondaryLogonPriority = 0
            });
            users.Insert(new User
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
            groupMembers.Insert(new GroupMember { UserId = 1, GroupId = 1 });
            groupMembers.Insert(new GroupMember { UserId = 2, GroupId = 2 });

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
