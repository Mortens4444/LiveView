using Database.Models;
using Mtf.Database.Interfaces;
using System;

namespace Database.Interfaces
{
    public interface IVideoSourceRepository : IRepository<VideoSource>
    {
        Tuple<string, string> SelectVideoSourceInfo(long? videoSourceId);

        Tuple<Agent, VideoSource> SelectVideoSourceAndAgentInfoByName(string serverIp, string videoSourceName);
    }
}
