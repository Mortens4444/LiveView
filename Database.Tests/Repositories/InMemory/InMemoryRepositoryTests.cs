using Database.Enums;
using Database.Models;
using Database.Repositories.InMemory;
using Database.Services.PasswordHashers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database.Tests.Repositories.InMemory
{
    [TestFixture]
    public class InMemoryRepositoryTests
    {
        // The in-memory tables are process-wide, so every test starts from empty tables.
        [SetUp]
        public void SetUp()
        {
            InMemoryStore.Reset();
        }

        [Test]
        public void Seed_CreatesBuiltInAdminWhoCanLogIn()
        {
            InMemoryDataSeeder.Seed();

            var user = new InMemoryUserRepository().Login(UserPasswordHasher.UsernameEncrypt("admin"), UserPasswordHasher.Hash("admin"));

            Assert.That(user, Is.Not.Null);
            Assert.That(user.Username, Is.EqualTo("admin"));
        }

        [Test]
        public void Seed_CalledTwice_DoesNotDuplicateBuiltInData()
        {
            var users = new InMemoryUserRepository();
            InMemoryDataSeeder.Seed();
            var userCount = users.SelectAll().Count;
            var groupCount = new InMemoryGroupRepository().SelectAll().Count;

            InMemoryDataSeeder.Seed();

            Assert.That(users.SelectAll(), Has.Count.EqualTo(userCount));
            Assert.That(new InMemoryGroupRepository().SelectAll(), Has.Count.EqualTo(groupCount));
        }

        [Test]
        public void Login_WithWrongPassword_ReturnsNull()
        {
            InMemoryDataSeeder.Seed();

            Assert.That(new InMemoryUserRepository().Login(UserPasswordHasher.UsernameEncrypt("admin"), "wrong"), Is.Null);
        }

        [Test]
        public void Insert_GeneratesIdentityAndReturnsCopies()
        {
            var repository = new InMemoryGridRepository();
            var name = Guid.NewGuid().ToString();

            var id = repository.InsertAndReturnId<int>(new Grid { Name = name, Rows = 2, Columns = 3 });
            var selected = repository.Select(id);
            selected.Rows = 99;

            Assert.That(id, Is.GreaterThan(0));
            Assert.That(repository.Select(id).Rows, Is.EqualTo(2), "changing a selected row must not change the stored row");

            repository.Update(selected);
            Assert.That(repository.Select(id).Rows, Is.EqualTo(99));
        }

        [Test]
        public void SelectWhere_MatchesEveryParameterProperty()
        {
            var gridRepository = new InMemoryGridRepository();
            var gridCameraRepository = new InMemoryGridCameraRepository();
            var gridId = gridRepository.InsertAndReturnId<int>(new Grid { Name = Guid.NewGuid().ToString() });
            var otherGridId = gridRepository.InsertAndReturnId<int>(new Grid { Name = Guid.NewGuid().ToString() });
            gridCameraRepository.Insert(new GridCamera { GridId = gridId, InitRow = 0 });
            gridCameraRepository.Insert(new GridCamera { GridId = gridId, InitRow = 1, EndRow = 2 });
            gridCameraRepository.Insert(new GridCamera { GridId = otherGridId });

            Assert.That(gridCameraRepository.SelectWhere(new { GridId = gridId }), Has.Count.EqualTo(2));
            Assert.That(gridCameraRepository.SelectWhere(new { GridId = gridId, InitRow = 1 }), Has.Count.EqualTo(1));
            Assert.That(gridCameraRepository.GetCombinedGridCameras(gridId), Has.Count.EqualTo(1));
        }

        [Test]
        public void DeleteWhere_WithUnknownProperty_DeletesNothing()
        {
            var repository = new InMemoryGridRepository();
            var id = repository.InsertAndReturnId<int>(new Grid { Name = Guid.NewGuid().ToString() });

            repository.DeleteWhere(new { NoSuchColumn = 1 });

            Assert.That(repository.Select(id), Is.Not.Null);
        }

        [Test]
        public void DeleteGrid_RemovesItsGridCamerasAndSequenceLinks()
        {
            var gridRepository = new InMemoryGridRepository();
            var gridCameraRepository = new InMemoryGridCameraRepository();
            var sequenceGridsRepository = new InMemorySequenceGridsRepository();
            var gridId = gridRepository.InsertAndReturnId<int>(new Grid { Name = Guid.NewGuid().ToString() });
            gridCameraRepository.Insert(new GridCamera { GridId = gridId });
            sequenceGridsRepository.Insert(new SequenceGrid { GridId = gridId, SequenceId = 1 });

            gridRepository.Delete(gridId);

            Assert.That(gridCameraRepository.SelectWhere(new { GridId = gridId }), Is.Empty);
            Assert.That(sequenceGridsRepository.SelectWhere(new { GridId = gridId }), Is.Empty);
        }

        [Test]
        public void Camera_GetsServerDataAndFirstFreePermissionNumber_AndIsDeletedWithItsServer()
        {
            var serverRepository = new InMemoryVideoServerRepository();
            var cameraRepository = new InMemoryCameraRepository();
            var hostname = Guid.NewGuid().ToString();
            var serverId = serverRepository.InsertAndReturnId<int>(new VideoServer { Hostname = hostname, EncryptedUsername = "user" });

            var firstCameraId = cameraRepository.InsertAndReturnId<int>(new Camera { VideoServerId = serverId, CameraName = "first" });
            var secondCameraId = cameraRepository.InsertAndReturnId<int>(new Camera { VideoServerId = serverId, CameraName = "second" });

            var first = cameraRepository.Select(firstCameraId);
            var second = cameraRepository.Select(secondCameraId);
            Assert.That(first.ServerDisplayName, Is.EqualTo(hostname));
            Assert.That(first.ServerEncryptedUsername, Is.EqualTo("user"));
            Assert.That(first.PermissionCamera, Is.GreaterThan(0));
            Assert.That(second.PermissionCamera, Is.Not.EqualTo(first.PermissionCamera));
            Assert.That(cameraRepository.SelectWhere(new { VideoServerId = serverId }), Has.Count.EqualTo(2));

            serverRepository.Delete(serverId);

            Assert.That(cameraRepository.SelectWhere(new { VideoServerId = serverId }), Is.Empty);
        }

        [Test]
        public void DeleteCamera_DetachesItFromGridsAndRemovesPermissions()
        {
            var cameraRepository = new InMemoryCameraRepository();
            var gridCameraRepository = new InMemoryGridCameraRepository();
            var cameraPermissionRepository = new InMemoryCameraPermissionRepository();
            var gridId = new InMemoryGridRepository().InsertAndReturnId<int>(new Grid { Name = Guid.NewGuid().ToString() });
            var cameraId = cameraRepository.InsertAndReturnId<int>(new Camera { CameraName = "camera" });
            var gridCameraId = gridCameraRepository.InsertAndReturnId<int>(new GridCamera { GridId = gridId, CameraId = cameraId });
            cameraPermissionRepository.Insert(new CameraPermission { CameraId = cameraId, GroupId = 1, UserEventId = 1 });

            cameraRepository.Delete(cameraId);

            Assert.That(gridCameraRepository.Select(gridCameraId).CameraId, Is.Null);
            Assert.That(cameraPermissionRepository.SelectWhere(new { CameraId = cameraId }), Is.Empty);
        }

        [Test]
        public void Operation_KeepsSuppliedIdAndSupportsIdsQuery()
        {
            var repository = new InMemoryOperationRepository();
            var firstId = 1_000_000 + Math.Abs(Guid.NewGuid().GetHashCode() % 100_000);
            var secondId = firstId + 100_000;
            repository.Insert(new Operation { Id = firstId, PermissionGroup = "group", PermissionValue = "first" });
            repository.Insert(new Operation { Id = secondId, PermissionGroup = "group", PermissionValue = "second" });

            var selected = repository.SelectWhere(new { Ids = new List<int?> { firstId, null } });

            Assert.That(selected.Select(operation => operation.Id), Is.EqualTo(new[] { firstId }));
            Assert.That(repository.HasAnyRow(), Is.True);
            Assert.Throws<InvalidOperationException>(() => repository.Insert(new Operation { Id = firstId }));
        }

        [Test]
        public void DeleteGroup_RemovesSubgroupsMembershipsAndPermissions()
        {
            var groupRepository = new InMemoryGroupRepository();
            var memberRepository = new InMemoryGroupMembersRepository();
            var permissionRepository = new InMemoryPermissionRepository();
            var userRepository = new InMemoryUserRepository();
            var userId = userRepository.InsertAndReturnId<int>(new User { EncryptedUsername = Guid.NewGuid().ToString(), NeededSecondaryLogonPriority = 0 });
            var groupId = groupRepository.InsertAndReturnId<int>(new Group { Name = Guid.NewGuid().ToString() });
            var childId = groupRepository.InsertAndReturnId<int>(new Group { Name = Guid.NewGuid().ToString(), ParentGroupId = groupId });
            memberRepository.Insert(new GroupMember { GroupId = childId, UserId = userId });
            permissionRepository.Insert(new Permission { GroupId = groupId, OperationId = 1, UserEventId = 1 });

            groupRepository.Delete(groupId);

            Assert.That(groupRepository.Select(groupId), Is.Null);
            Assert.That(groupRepository.Select(childId), Is.Null);
            Assert.That(memberRepository.SelectWhere(new { UserId = userId }), Is.Empty);
            Assert.That(permissionRepository.SelectWhere(new { GroupId = groupId }), Is.Empty);
            Assert.That(userRepository.Select(userId).NeededSecondaryLogonPriority, Is.EqualTo(100));
        }

        [Test]
        public void FilterLogs_AppliesFilterOrderAndPaging()
        {
            var repository = new InMemoryLogRepository();
            var marker = Guid.NewGuid().ToString();
            var start = new DateTime(2001, 1, 1);
            for (var i = 0; i < 5; i++)
            {
                repository.Insert(new LogEntry { Date = start.AddMinutes(i), UserId = 1, OperationId = 1, OtherInformation = $"{marker} entry {i}" });
            }

            repository.Insert(new LogEntry { Date = start.AddMinutes(10), UserId = 1, OtherInformation = $"{marker} error" });

            var page = repository.FilterLogs(new LogEntryFilter
            {
                LogType = 1,
                From = start,
                To = start.AddHours(1),
                OtherInformationPart = marker.ToUpperInvariant(),
                MaxRows = 2,
                Offset = 1
            });

            Assert.That(page.Select(entry => entry.OtherInformation), Is.EqualTo(new[] { $"{marker} entry 3", $"{marker} entry 2" }));
            Assert.That(repository.SelectWhere(new LogEntryFilter { LogType = 3, From = start, To = start.AddHours(1), OtherInformationPart = marker, MaxRows = 10 }), Has.Count.EqualTo(1));
        }

        [Test]
        public void GeneralOptions_SetAndGetTypedValues()
        {
            var repository = new InMemoryGeneralOptionsRepository();

            Assert.That(repository.Get(Setting.VerboseDebugLogging, false), Is.False);

            repository.Set(Setting.VerboseDebugLogging, true);

            Assert.That(repository.Get(Setting.VerboseDebugLogging, false), Is.True);
        }

        [Test]
        public void PersonalOptions_AreSeparatedByUser()
        {
            var repository = new InMemoryPersonalOptionsRepository();
            const long firstUser = 7_001;
            const long secondUser = 7_002;

            repository.Set(Setting.VideoServerIdentifierNone, firstUser, true);
            repository.Set(Setting.VideoServerIdentifierNone, secondUser, false);

            Assert.That(repository.Get(Setting.VideoServerIdentifierNone, firstUser, false), Is.True);
            Assert.That(repository.Get(Setting.VideoServerIdentifierNone, secondUser, true), Is.False);
        }

        [Test]
        public void Display_InsertOfKnownDisplayKeepsUserChoices()
        {
            var repository = new InMemoryDisplayRepository();
            var id = 2_000_000 + Math.Abs(Guid.NewGuid().GetHashCode() % 100_000);
            repository.Insert(new Display { Id = id, Width = 800, SziltechId = "a" });
            var stored = repository.Select(id);
            stored.CanShowSequence = false;
            repository.Update(stored);

            repository.Insert(new Display { Id = id, Width = 1024, SziltechId = "b", CanShowSequence = true });

            var result = repository.Select(id);
            Assert.That(result.Width, Is.EqualTo(1024));
            Assert.That(result.SziltechId, Is.EqualTo("b"));
            Assert.That(result.CanShowSequence, Is.False);
        }
    }
}
