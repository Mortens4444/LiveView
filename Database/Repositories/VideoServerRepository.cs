using Database.Interfaces;
using Database.Models;
using Mtf.Database;

namespace Database.Repositories;

public sealed class VideoServerRepository : BaseRepository<VideoServer, int>, IVideoServerRepository
{
    public VideoServerRepository() : base(Database.Services.DatabaseInitializer.ConnectionString) { }
}
