using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class LanguageRepository <TModel> : BaseRepository<TModel>, ILanguageRepository<TModel>
    {
    }
}
