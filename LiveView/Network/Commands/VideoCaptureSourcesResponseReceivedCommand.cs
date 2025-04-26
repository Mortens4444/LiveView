using LiveView.Core.Extensions;
using LiveView.Core.Interfaces;
using LiveView.Models.Dependencies;
using Mtf.Network.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace LiveView.Network.Commands
{
    public class VideoCaptureSourcesResponseReceivedCommand : ICommand
    {
        private readonly string cameraServers;
        private readonly Socket agentSocket;
        private readonly MainPresenterDependencies mainPresenterDependencies;

        public VideoCaptureSourcesResponseReceivedCommand(string cameraServers, Socket agentSocket, MainPresenterDependencies mainPresenterDependencies)
        {
            this.cameraServers = cameraServers;
            this.agentSocket = agentSocket;
            this.mainPresenterDependencies = mainPresenterDependencies;
        }

        public void Execute()
        {
            var videoCaptureSources = cameraServers.Split(';')
                        .Select(vcs => vcs.Split('='))
                        .ToDictionary(vcs => vcs[0], vcs => vcs[1]);
            Globals.VideoCaptureSources.Add(agentSocket, videoCaptureSources);

            var localEndPointInfo = agentSocket.RemoteEndPoint?.GetEndPointInfo();
            UpdateVideoCaptureSources(videoCaptureSources, localEndPointInfo);
        }

        private void UpdateVideoCaptureSources(Dictionary<string, string> videoCaptureSources, string localEndPointInfo)
        {
            if (videoCaptureSources.Count > 0)
            {
                var videoSources = mainPresenterDependencies.VideoSourceRepository.SelectAll();
                var agent = mainPresenterDependencies.AgentRepository.SelectWhere(new { ServerIp = localEndPointInfo.GetIpAddessFromEndPoint() }).FirstOrDefault();
                var relevantVideoSources = videoSources.Where(videoSource => videoSource.AgentId == agent.Id).ToList();

                foreach (var videoCaptureSource in videoCaptureSources)
                {
                    long videoSourceId;
                    var foundVideoSource = relevantVideoSources.FirstOrDefault(vs => vs.Name == videoCaptureSource.Key);
                    var videoSource = new Database.Models.VideoSource
                    {
                        AgentId = agent.Id,
                        Name = videoCaptureSource.Key,
                        Port = Convert.ToInt32(videoCaptureSource.Value.GetPortFromEndPoint())
                    };
                    if (foundVideoSource != null)
                    {
                        videoSource.Id = foundVideoSource.Id;
                        videoSourceId = foundVideoSource.Id;
                        mainPresenterDependencies.VideoSourceRepository.Update(videoSource);
                    }
                    else
                    {
                        mainPresenterDependencies.VideoSourceRepository.Insert(videoSource);
                    }
                }
            }
        }
    }
}
