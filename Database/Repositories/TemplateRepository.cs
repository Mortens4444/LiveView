using Database.Interfaces;
using Mtf.Database;

namespace Database.Repositories
{
    public sealed class TemplateRepository <TModel> : BaseRepository<TModel>, ITemplateRepository<TModel>
    {
    }
}
