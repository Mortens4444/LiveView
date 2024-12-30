using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Database;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class GeneralOptionsPresenter : BasePresenter
    {
        private IGeneralOptionsView view;
        private readonly ILogger<GeneralOptionsForm> logger;

        public GeneralOptionsPresenter(GeneralOptionsPresenterDependencies generalOptionsPresenterDependencies)
            : base(generalOptionsPresenterDependencies)
        {
            logger = generalOptionsPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IGeneralOptionsView;
        }

        public override void Load()
        {
            var options = generalOptionsRepository.SelectAll();
            var usage = BaseRepository.GetDatabaseUsagePercentageWithLimit();
            view.TbDatabaseUsage.Text = usage == -1 ? "N/A" : $"{usage}%";
        }

        public void LoadDefaultSettings()
        {
            view.NudFPS.Value = 25;
            view.NudRestartTemplate.Value = 0;
            view.NudDatabasePort.Value = 2242;
            view.NudMaximumTimeToWaitForNewPicture.Value = 300;
            view.NudMaximumDeflectionBetweenLiveViewAndRecorder.Value = 5000;
            view.NudStatisticMessageAfterEveryMinutes.Value = 1440;
            view.NudTimeBetweenCheckVideoServers.Value = 3000;
            view.NudMaximumTimeToWaitForAVideoServerIs.Value = 5000;

            view.ChkReduceSequenceUsageOfNetworkAndCPU.Checked = false;
            view.ChkDeblock.Checked = false;
            view.ChkCloseSequenceApplicationOnFullScreenDisplayDevice.Checked = false;
            view.ChkLiveView.Checked = false;
            view.ChkThreading.Checked = true;
            view.ChkOpenMotionPopupWhenProgramStarts.Checked = false;
            view.ChkUseCustomNoSignalImage.Checked = false;
            view.ChkVerboseDebugLogging.Checked = false;
            view.ChkUseWatchDog.Checked = false;

            if (view.CbKBD300ACOMPort.Items.Count > 0)
            {
                view.CbKBD300ACOMPort.SelectedIndex = 0;
            }
            if (view.CbUsers.Items.Count > 0)
            {
                view.CbUsers.SelectedIndex = 0;
            }

            view.TbDatabaseFolder.Text = @"C:\Database";
            view.TbDatabaseServerIp.Text = "127.0.0.1";
            view.TbPassword.Text = "password";
            view.TbUsername.Text = "admin";
            view.TbDatabaseName.Text = "MyDatabase";

            view.RbVerboseLogEveryEvents.Checked = false;
            view.RbVerboseLogOnlyErrors.Checked = true;
        }

        public void LoadStandardSettings()
        {
            view.NudFPS.Value = 25;
            view.NudRestartTemplate.Value = 0;
            view.NudDatabasePort.Value = 2242;
            view.NudMaximumTimeToWaitForNewPicture.Value = 300;
            view.NudMaximumDeflectionBetweenLiveViewAndRecorder.Value = 1000;
            view.NudStatisticMessageAfterEveryMinutes.Value = 1440;
            view.NudTimeBetweenCheckVideoServers.Value = 3000;
            view.NudMaximumTimeToWaitForAVideoServerIs.Value = 500;

            view.ChkReduceSequenceUsageOfNetworkAndCPU.Checked = false;
            view.ChkDeblock.Checked = false;
            view.ChkCloseSequenceApplicationOnFullScreenDisplayDevice.Checked = false;
            view.ChkLiveView.Checked = false;
            view.ChkThreading.Checked = true;
            view.ChkOpenMotionPopupWhenProgramStarts.Checked = false;
            view.ChkUseCustomNoSignalImage.Checked = false;
            view.ChkVerboseDebugLogging.Checked = false;
            view.ChkUseWatchDog.Checked = false;

            if (view.CbKBD300ACOMPort.Items.Count > 0)
            {
                view.CbKBD300ACOMPort.SelectedIndex = 0;
            }
            if (view.CbUsers.Items.Count > 0)
            {
                view.CbUsers.SelectedIndex = 0;
            }

            view.TbDatabaseFolder.Text = @"C:\Database";
            view.TbDatabaseServerIp.Text = "127.0.0.1";
            view.TbPassword.Text = "password";
            view.TbUsername.Text = "admin";
            view.TbDatabaseName.Text = "MyDatabase";

            view.RbVerboseLogEveryEvents.Checked = false;
            view.RbVerboseLogOnlyErrors.Checked = true;
        }

        public void SelectNoSignalImage()
        {
            if (view.FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                view.PbNoSignalImage.Image = Image.FromFile(view.FolderBrowserDialog.SelectedPath);
            }
        }

        public void SaveSettings()
        {
            throw new NotImplementedException();
        }
    }
}
