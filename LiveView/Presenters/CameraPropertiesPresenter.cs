using Database.Enums;
using Database.Interfaces;
using Database.Models;
using Database.Services.PasswordHashers;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.Extensions;
using Mtf.LanguageService;
using Mtf.Permissions.Enums;
using Mtf.Windows.Forms.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class CameraPropertiesPresenter : BasePresenter
    {
        private ICameraPropertiesView view;
        private readonly ICameraRepository cameraRepository;
        private readonly ICameraFunctionRepository cameraFunctionRepository;
        private readonly IAgentRepository agentRepository;
        private readonly IVideoSourceRepository videoSourceRepository;
        private readonly ILogger<CameraProperties> logger;

        public CameraPropertiesPresenter(CameraPropertiesPresenterDependencies dependencies)
            : base(dependencies)
        {
            agentRepository = dependencies.AgentRepository;
            videoSourceRepository = dependencies.VideoSourceRepository;
            cameraRepository = dependencies.CameraRepository;
            cameraFunctionRepository = dependencies.CameraFunctionRepository;
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ICameraPropertiesView;
        }

        public void Save()
        {
            view.Camera.CameraName = view.TbCameraName.Text;
            view.Camera.IpAddress = view.TbCameraIpAddress.Text;
            view.Camera.EncryptedUsername = CameraPasswordCryptor.UsernameEncrypt(view.TbCameraUsername.Text);
            view.Camera.EncryptedPassword = CameraPasswordCryptor.PasswordEncrypt(view.TbCameraPassword.Password);
            view.Camera.HttpStreamUrl = view.TbHttpStream.Text;
            view.Camera.StreamId = (int)view.NudStreamId.Value;
            view.Camera.FullscreenMode = (CameraMode)Enum.Parse(typeof(CameraMode), view.CbFullscreenMode.SelectedItem.ToString());
            view.Camera.VideoSourceId = (view.CbVideoSources.SelectedItem as VideoSource)?.Id;

            cameraRepository.Update(view.Camera);
            logger.LogInfo(CameraManagementPermissions.Update, "Camera '{0}' properties has been changed.", view.Camera.CameraName);
        }

        public override void Load()
        {
            var fullscreenModes = EnumExtensions.GetEnabledValues<CameraMode>()
                .Select(mode => Lng.Elem(mode.GetDescription()));
            view.AddItems(view.CbFullscreenMode, fullscreenModes);
            
            var cameraFunctionTypes = Enum.GetValues(typeof(CameraFunctionType))
                .Cast<CameraFunctionType>()
                .Select(cameraFunctionType => cameraFunctionType.GetDescription());
            view.AddItems(view.CbCameraFunctionType, cameraFunctionTypes);
            view.CbCameraFunctionType.SelectFirst();

            view.CbVideoSources.AddItems(videoSourceRepository.SelectAll());
            view.CbVideoSources.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                if (view.CbVideoSources.SelectedItem is VideoSource videoSource)
                {
                    var agent = agentRepository.Select(videoSource.AgentId);
                    if (agent != null)
                    {
                        view.TbHttpStream.Text = $"{agent.ServerIp}|{videoSource.Name}";
                    }
                }
            };

            view.TbCameraName.Text = view.Camera.CameraName;
            view.TbCameraGuid.Text = view.Camera.Guid;
            view.TbCameraIpAddress.Text = view.Camera.IpAddress;
            view.TbCameraUsername.Text = view.Camera.Username;
            view.TbCameraPassword.Password = CameraPasswordCryptor.PasswordDecrypt(view.Camera.EncryptedPassword);
            view.TbHttpStream.Text = view.Camera.HttpStreamUrl;
            view.NudStreamId.Value = view.Camera.StreamId ?? 0;

            view.CbFullscreenMode.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                view.CbVideoSources.Visible = view.CbFullscreenMode.SelectedItem.ToString() == CameraMode.VideoSource.ToString();
                view.LblVideoSources.Visible = view.CbVideoSources.Visible;
            };

            if (Enum.TryParse(view.Camera.FullscreenMode.ToString(), out CameraMode cameraMode))
            {
                view.CbFullscreenMode.SelectedItem = cameraMode.ToString();
            }
            else
            {
                view.CbFullscreenMode.SelectedIndex = 0;
            }
            if (view.Camera.VideoSourceId.HasValue)
            {
                foreach (VideoSource item in view.CbVideoSources.Items)
                {
                    if (item.Id == view.Camera.VideoSourceId.Value)
                    {
                        view.CbVideoSources.SelectedItem = item;
                        break;
                    }
                }
            }

            view.LvCameraFunctions.AddItems(cameraFunctionRepository.SelectWhere(new { CameraId = view.Camera.Id }),
                cameraFunction =>
                {
                    var result = new ListViewItem(cameraFunction.FunctionId.ToString())
                    {
                        Tag = cameraFunction
                    };
                    result.SubItems.Add(cameraFunction.FunctionCallback);
                    result.SubItems.Add(GetCameraFunctionParametersString(cameraFunction));
                    return result;
                });
        }

        public void ShowSearchCameraUrlForm()
        {
            ShowForm<SearchCameraUrlForm>();
        }

        public void AddNewCameraFunction()
        {
            var cameraFunction = new CameraFunction
            {
                CameraId = view.Camera.Id,
                FunctionId = (CameraFunctionType)view.CbCameraFunctionType.SelectedIndex,
                FunctionCallback = view.TbCameraFunctionCallback.Text
            };
            var parameters = view.TbCameraFunctionCallbackParameters.Text.Split(';');
            for (int i = 0; i < Math.Min(parameters.Length, 40); i++)
            {
                var propertyName = $"Param{i + 1}";
                var property = cameraFunction.GetType().GetProperty(propertyName);
                property?.SetValue(cameraFunction, parameters[i]);
            }
            cameraFunctionRepository.Insert(cameraFunction);
            var listViewItem = new ListViewItem(cameraFunction.FunctionId.GetDescription())
            {
                Tag = cameraFunction
            };
            listViewItem.SubItems.Add(cameraFunction.FunctionCallback);
            listViewItem.SubItems.Add(CameraPropertiesPresenter.GetCameraFunctionParametersString(cameraFunction));
            view.LvCameraFunctions.Items.Add(listViewItem);
        }

        public void DeleteSelectedCameraFunctions()
        {
            foreach (ListViewItem item in view.LvCameraFunctions.SelectedItems)
            {
                cameraFunctionRepository.Delete(((CameraFunction)item.Tag).Id);
            }
            view.RemoveSelectedItems(view.LvCameraFunctions);
        }

        public static string GetCameraFunctionParametersString(CameraFunction cameraFunction)
        {
            var parameters = new List<string>();

            for (int i = 1; i <= 40; i++)
            {
                var propertyName = $"Param{i}";
                var property = cameraFunction.GetType().GetProperty(propertyName);

                if (property != null)
                {
                    var value = property.GetValue(cameraFunction);
                    parameters.Add(value?.ToString() ?? String.Empty);
                }
            }

            return String.Join(";", parameters);
        }

        public void ExportCustomFunctions()
        {
            view.SaveFileDialog.FileName = $"{view.Camera} {Lng.Elem("Custom functions")}.csv";
            if (view.SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                view.LvCameraFunctions.ExportItemsToCsv(view.SaveFileDialog.FileName);
            }
        }

        public void ImportCustomFunctions()
        {
            if (view.OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                var lines = new List<string>();
                using (var fileStream = new FileStream(view.OpenFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (var streamReader = new StreamReader(fileStream))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            lines.Add(streamReader.ReadLine());
                        }
                    }
                }

                foreach (var line in lines.Skip(1))
                {
                    var columns = line.Split(',');
                    var cameraFunction = new CameraFunction
                    {
                        CameraId = view.Camera.Id,
                        FunctionId = EnumExtensions.GetFromDescription<CameraFunctionType>(columns[0]),
                        FunctionCallback = columns[1]
                    };

                    var parameters = columns[2].Split(';');
                    for (int i = 0; i < Math.Min(parameters.Length, 40); i++)
                    {
                        var propertyName = $"Param{i + 1}";
                        var property = cameraFunction.GetType().GetProperty(propertyName);
                        property?.SetValue(cameraFunction, parameters[i]);
                    }

                    cameraFunctionRepository.Insert(cameraFunction);
                }

                view.LvCameraFunctions.ImportItemsFromCsv(view.OpenFileDialog.FileName);
            }
        }
    }
}
