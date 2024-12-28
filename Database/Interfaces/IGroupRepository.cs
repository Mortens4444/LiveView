using Mtf.Database.Interfaces;

namespace Database.Interfaces
{
    public interface IGroupRepository<TModel> : IRepository<TModel>
    {
        TModel GetByName(string name);
    }
}
