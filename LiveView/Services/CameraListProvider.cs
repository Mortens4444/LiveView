using Database.Models;
using LiveView.Core.CustomEventArgs;
using LiveView.Dto;
using LiveView.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Sockets;
using System.Windows.Forms;

namespace LiveView.Services
{
    public static class CameraListProvider
    {
        public static void AddCameras(ListView listView, ReadOnlyCollection<Camera> cameras, int cameraIconIndex = -1)
        {
            listView.AddItems(cameras, camera => new ListViewItem(camera.CameraName, cameraIconIndex) { Tag = camera });
            AddVideoSources(listView);
            Globals.VideoCaptureSources.Changed += (object sender, DictionaryChangedEventArgs<Socket, Dictionary<string, string>> e) =>
            {
                listView.Invoke((Action)(() =>
                {
                    for (int i = listView.Items.Count - 1; i >= 0; i--)
                    {
                        if (listView.Items[i].Tag is VideoSourceDto)
                        {
                            listView.Items.RemoveAt(i);
                        }
                    }
                    AddVideoSources(listView);
                }));
            };
        }

        private static void AddVideoSources(ListView listView)
        {
            foreach (var videoCaptureSource in Globals.VideoCaptureSources)
            {
                AddVideoSource(listView, videoCaptureSource);
            }
        }

        private static void AddVideoSource(ListView listView, KeyValuePair<Socket, Dictionary<string, string>> videoCaptureSource)
        {
            foreach (var camera in videoCaptureSource.Value)
            {
                var videoSource = new VideoSourceDto
                {
                    Socket = videoCaptureSource.Key,
                    Name = camera.Key,
                    //EndPoint = camera.Value,
                    EndPoint = $"{videoCaptureSource.Key.RemoteEndPoint.ToString().Split(':')[0]}:{camera.Value.Split(':')[1]}"
                };
                listView.Items.Add(new ListViewItem($"{videoSource.ServerIp} - {videoSource.Name}") { Tag = videoSource });
            }
        }

        public static void PopulateMenuItems<TParent, TChild>(
            ToolStripMenuItem rootItem,
            IEnumerable<TParent> parents,
            Func<TParent, string> parentTextSelector,
            Func<TParent, IEnumerable<TChild>> childSelector,
            Func<TChild, string> childTextSelector,
            EventHandler leafItemClickHandler)
        {
            rootItem.DropDownItems.Clear();
            foreach (var parent in parents)
            {
                var parentItem = new ToolStripMenuItem(parentTextSelector(parent))
                {
                    Tag = parent
                };

                var children = childSelector(parent);
                foreach (var child in children)
                {
                    var childItem = new ToolStripMenuItem(childTextSelector(child))
                    {
                        Tag = child
                    };
                    childItem.Click += leafItemClickHandler;
                    parentItem.DropDownItems.Add(childItem);
                }

                rootItem.DropDownItems.Add(parentItem);
            }
            foreach (var videoCaptureSource in Globals.VideoCaptureSources)
            {
                var parentItem = new ToolStripMenuItem()
                {
                    Tag = videoCaptureSource
                };
                foreach (var camera in videoCaptureSource.Value)
                {
                    var videoSource = new VideoSourceDto
                    {
                        Socket = videoCaptureSource.Key,
                        Name = camera.Key,
                        EndPoint = camera.Value
                    };
                    var childItem = new ToolStripMenuItem(videoSource.Name)
                    {
                        Tag = videoSource
                    };
                    childItem.Click += leafItemClickHandler;
                    parentItem.Text = videoSource.ServerIp;
                    parentItem.DropDownItems.Add(childItem);
                }
                rootItem.DropDownItems.Add(parentItem);
            }
        }
    }
}
