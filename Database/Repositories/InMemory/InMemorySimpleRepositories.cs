using Database.Interfaces;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database.Repositories.InMemory;

// In-memory repositories without special behaviour (or with only a sort order / cascading delete).

public sealed class InMemoryBarcodeCharChangerRepository : InMemoryRepository<BarcodeCharChanger, int>, IBarcodeCharChangerRepository
{
    /// <summary>The id is the LCID of the keyboard layout.</summary>
    protected override bool UsesIdentity => false;
}

public sealed class InMemoryBarcodeScanOptionsRepository : InMemoryRepository<BarcodeScanOptions, int>, IBarcodeScanOptionsRepository
{
}

public sealed class InMemoryBarcodeScanReadingRepository : InMemoryRepository<BarcodeScanReading, int>, IBarcodeScanReadingRepository
{
}

public sealed class InMemoryCameraFunctionRepository : InMemoryRepository<CameraFunction, int>, ICameraFunctionRepository
{
    protected override IEnumerable<CameraFunction> Order(IEnumerable<CameraFunction> items)
    {
        return items.OrderBy(cameraFunction => cameraFunction.FunctionId);
    }
}

public sealed class InMemoryCameraPermissionRepository : InMemoryRepository<CameraPermission, int>, ICameraPermissionRepository
{
}

public sealed class InMemoryDatabaseServerRepository : InMemoryRepository<DatabaseServer, int>, IDatabaseServerRepository
{
}

public sealed class InMemoryGroupMembersRepository : InMemoryRepository<GroupMember, int>, IGroupMembersRepository
{
}

public sealed class InMemoryInputOutputPortRepository : InMemoryRepository<InputOutputPort, int>, IInputOutputPortRepository
{
}

public sealed class InMemoryInputOutputPortLogRepository : InMemoryRepository<InputOutputPortLogEntry, int>, IInputOutputPortLogRepository
{
}

public sealed class InMemoryInputOutputPortRuleRepository : InMemoryRepository<InputOutputPortRule, int>, IInputOutputPortRuleRepository
{
}

public sealed class InMemoryLanguageRepository : InMemoryRepository<Language, int>, ILanguageRepository
{
    protected override IEnumerable<Language> Order(IEnumerable<Language> items)
    {
        return items.OrderBy(language => language.Name, StringComparer.CurrentCultureIgnoreCase);
    }
}

public sealed class InMemoryMigrationRepository : InMemoryRepository<Migration, int>, IMigrationRepository
{
}

public sealed class InMemoryPermissionRepository : InMemoryRepository<Permission, int>, IPermissionRepository
{
}

public sealed class InMemoryTemplateRepository : InMemoryRepository<Template, int>, ITemplateRepository
{
    protected override void OnDeleted(Template template)
    {
        new InMemoryTemplateProcessRepository().DeleteWhere(new { TemplateId = template.Id });
    }
}

public sealed class InMemoryTemplateProcessRepository : InMemoryRepository<TemplateProcess, int>, ITemplateProcessRepository
{
}
