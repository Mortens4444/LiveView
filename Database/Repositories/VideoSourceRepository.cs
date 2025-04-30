using Database.Interfaces;
using Database.Models;
using Mtf.Database;
using System;

namespace Database.Repositories
{
    public sealed class VideoSourceRepository : BaseRepository<VideoSource>, IVideoSourceRepository
    {
        public Tuple<string, string> SelectVideoSourceInfo(long? videoSourceId)
        {
            if (!videoSourceId.HasValue)
            {
                return null;
            }
            dynamic info = QuerySingleOrDefaultWithDynamic("SelectVideoSourceAndAgentInfo", new { Id = videoSourceId.Value } );
            return new Tuple<string, string>(info.ServerIp, info.Name);
        }

        public Tuple<Agent, VideoSource> SelectVideoSourceAndAgentInfoByName(string serverIp, string videoSourceName)
        {
            dynamic info = QuerySingleOrDefaultWithDynamic("SelectVideoSourceAndAgentInfoByName", new { ServerIp = serverIp, VideoSourceName = videoSourceName });
            if (info == null)
            {
                return new Tuple<Agent, VideoSource>(null, null);
            }
            return new Tuple<Agent, VideoSource>(
                new Agent
                {
                    Id = info.AgentId,
                    ServerIp = info.ServerIp,
                    AgentPort = info.AgentPort,
                    VncServerPort = info.VncServerPort
                },
                new VideoSource
                {
                    Id = info.VideoSourceId,
                    AgentId = info.AgentId,
                    Name = info.VideoSourceName,
                    Port = info.VideoSourcePort
                });
        }
    }
}
