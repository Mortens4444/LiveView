using System.Collections.ObjectModel;

namespace Database.Interfaces
{
    public interface IRepository<TModel>
    {
        TModel Get(int id);

        ReadOnlyCollection<TModel> GetAll();

        ReadOnlyCollection<TModel> GetWhere(object param);

        void Insert(TModel model);
        
        void Update(TModel model);

        void Delete(int id);

        void DeleteWhere(object param);
    }
}