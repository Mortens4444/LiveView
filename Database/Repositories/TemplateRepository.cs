using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class TemplateRepository : BaseRepository<Template, int>, ITemplateRepository
{
    public TemplateRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
}
