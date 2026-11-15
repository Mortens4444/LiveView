using Database.Interfaces;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database.Repositories.InMemory;

public sealed class InMemoryVideoServerRepository : InMemoryRepository<VideoServer, int>, IVideoServerRepository
{
    protected override IEnumerable<VideoServer> Order(IEnumerable<VideoServer> items)
    {
        return items.OrderBy(videoServer => videoServer.Hostname, StringComparer.CurrentCultureIgnoreCase);
    }

    protected override void OnDeleted(VideoServer videoServer)
    {
        new InMemoryCameraRepository().DeleteWhere(new { VideoServerId = videoServer.Id });
    }
}

public sealed class InMemoryAgentRepository : InMemoryRepository<Agent, int>, IAgentRepository
{
    protected override void OnDeleted(Agent agent)
    {
        new InMemoryVideoSourceRepository().DeleteWhere(new { AgentId = agent.Id });
        foreach (var templateProcess in InMemoryStore<TemplateProcess>.Items.Where(templateProcess => templateProcess.AgentId == agent.Id))
        {
            templateProcess.AgentId = null;
        }
    }
}

public sealed class InMemoryVideoSourceRepository : InMemoryRepository<VideoSource, int>, IVideoSourceRepository
{
    public Tuple<string, string> SelectVideoSourceInfo(long? videoSourceId)
    {
        if (!videoSourceId.HasValue)
        {
            return null;
        }

        lock (SyncRoot)
        {
            var videoSource = Items.FirstOrDefault(existing => existing.Id == videoSourceId.Value);
            var agent = videoSource == null ? null : InMemoryStore<Agent>.Items.FirstOrDefault(existing => existing.Id == videoSource.AgentId);
            return agent == null ? null : new Tuple<string, string>(agent.ServerIp, videoSource.Name);
        }
    }

    public Tuple<Agent, VideoSource> SelectVideoSourceAndAgentInfoByName(string serverIp, string videoSourceName)
    {
        lock (SyncRoot)
        {
            foreach (var agent in InMemoryStore<Agent>.Items.Where(existing => String.Equals(existing.ServerIp, serverIp, StringComparison.OrdinalIgnoreCase)))
            {
                var videoSource = Items.FirstOrDefault(existing => existing.AgentId == agent.Id && String.Equals(existing.Name, videoSourceName, StringComparison.OrdinalIgnoreCase));
                if (videoSource != null)
                {
                    return new Tuple<Agent, VideoSource>(
                        InMemoryStore<Agent>.Clone(agent),
                        InMemoryStore<VideoSource>.Clone(videoSource));
                }
            }
        }

        return new Tuple<Agent, VideoSource>(null, null);
    }

    protected override void OnDeleted(VideoSource videoSource)
    {
        foreach (var camera in InMemoryStore<Camera>.Items.Where(camera => camera.VideoSourceId == videoSource.Id))
        {
            camera.VideoSourceId = null;
        }
    }
}
