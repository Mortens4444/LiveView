using AxVIDEOCONTROL4Lib;
using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Controls.Video.ActiveX;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class SynchronViewPresenter : BasePresenter
    {
        private ISynchronViewView view;
        private readonly IVideoServerRepository serverRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly ILogger<SynchronView> logger;
        private readonly ReadOnlyCollection<VideoServer> servers;

        public SynchronViewPresenter(SynchronViewPresenterDependencies dependencies)
            : base(dependencies)
        {
            serverRepository = dependencies.VideoServerRepository;
            cameraRepository = dependencies.CameraRepository;
            logger = dependencies.Logger;
            servers = serverRepository.SelectAll();
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ISynchronViewView;
        }

        public void Goto()
        {
            GotoDate(view.AxVideoPicture1);
            GotoDate(view.AxVideoPicture2);
            GotoDate(view.AxVideoPicture3);
            GotoDate(view.AxVideoPicture4);
        }

        public void Pause()
        {
            Stop(view.AxVideoPicture1);
            Stop(view.AxVideoPicture2);
            Stop(view.AxVideoPicture3);
            Stop(view.AxVideoPicture4);
        }

        public void Play()
        {
            Play(view.AxVideoPicture1);
            Play(view.AxVideoPicture2);
            Play(view.AxVideoPicture3);
            Play(view.AxVideoPicture4);
        }

        public void StepBack()
        {
            Prev(view.AxVideoPicture1);
            Prev(view.AxVideoPicture2);
            Prev(view.AxVideoPicture3);
            Prev(view.AxVideoPicture4);
        }

        public void StepNext()
        {
            Next(view.AxVideoPicture1);
            Next(view.AxVideoPicture2);
            Next(view.AxVideoPicture3);
            Next(view.AxVideoPicture4);
        }

        public override void Load()
        {
            var cameras = cameraRepository.SelectAll();
            CameraListProvider.PopulateMenuItems(
                view.TsmiChangeCameraTo,
                servers,
                server => server.ToString(),
                server => cameras.Where(c => c.ServerId == server.Id),
                camera => camera.ToString(),
                CameraMenuItem_Click
            );
        }

        private void CameraMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem && menuItem.Tag is Camera camera)
            {
                var dropDownMenu = menuItem.GetCurrentParent() as ToolStripDropDownMenu;
                var contextMenu = dropDownMenu?.OwnerItem?.OwnerItem?.Owner as ContextMenuStrip;
                var sourceControl = contextMenu?.SourceControl;

                if (sourceControl is AxVideoPlayerWindow axVideoPlayerWindow)
                {
                    var videoPicture = axVideoPlayerWindow.AxVideoPicture;
                    if (videoPicture.IsConnected())
                    {
                        videoPicture.Disconnect();
                    }
                    var server = servers.FirstOrDefault(s => s.Id == camera.ServerId);
                    videoPicture.Connect(server?.IpAddress ?? camera.IpAddress, camera.Guid, camera.ServerEncryptedUsername, camera.ServerEncryptedPassword);
                }
            }
        }

        public void SetSpeed()
        {
            SetSpeed(view.AxVideoPicture1, (short)view.TbSpeed.Value);
            SetSpeed(view.AxVideoPicture2, (short)view.TbSpeed.Value);
            SetSpeed(view.AxVideoPicture3, (short)view.TbSpeed.Value);
            SetSpeed(view.AxVideoPicture4, (short)view.TbSpeed.Value);
        }

        public void ChangeOsdState()
        {
            SetOsd(view.AxVideoPicture1, view.ChkOsd.Checked);
            SetOsd(view.AxVideoPicture2, view.ChkOsd.Checked);
            SetOsd(view.AxVideoPicture3, view.ChkOsd.Checked);
            SetOsd(view.AxVideoPicture4, view.ChkOsd.Checked);
        }

        private void SetOsd(AxVideoPicture videoPicture, bool enable)
        {
            if (videoPicture.IsConnected())
            {
                videoPicture.OSD = enable;
                videoPicture.ShowDateTime = enable;
            }
        }

        private void Play(AxVideoPicture videoPicture)
        {
            if (videoPicture.IsConnected())
            {
                videoPicture.Play();
            }
        }

        private void Stop(AxVideoPicture videoPicture)
        {
            if (videoPicture.IsConnected())
            {
                videoPicture.Stop();
            }
        }

        private void GotoDate(AxVideoPicture videoPicture)
        {
            if (videoPicture.IsConnected())
            {
                var dateTime = view.DtpImageDate.Value;
                dateTime.AddHours((int)view.NudHour.Value);
                dateTime.AddMinutes((int)view.NudMinute.Value);
                dateTime.AddSeconds((int)view.NudSecond.Value);
                videoPicture.Time = dateTime;
            }
        }

        private void Prev(AxVideoPicture videoPicture)
        {
            if (videoPicture.IsConnected())
            {
                videoPicture.Prev();
            }
        }

        private void Next(AxVideoPicture videoPicture)
        {
            if (videoPicture.IsConnected())
            {
                videoPicture.Next();
            }
        }

        private void SetSpeed(AxVideoPicture videoPicture, short speed)
        {
            if (videoPicture.IsConnected())
            {
                videoPicture.Speed = speed;
            }
        }
    }
}
