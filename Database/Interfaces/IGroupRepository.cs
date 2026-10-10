using Database.Models;
using Mtf.Database.Interfaces;

namespace Database.Interfaces;

public interface IGroupRepository : IRepository<Group, int>
{
    void DeleteGroupPermissions(int groupId);

    void DeleteGroupPermissions(int groupId, int userEventId);
}
