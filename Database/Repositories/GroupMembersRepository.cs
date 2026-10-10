using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class GroupMembersRepository : BaseRepository<GroupMember, int>, IGroupMembersRepository
{
    public GroupMembersRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
}
