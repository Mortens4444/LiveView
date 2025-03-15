using Database.Interfaces;
using Database.Models;
using LiveView.Dto;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Models.Network;
using LiveView.Services;
using LiveView.Services.Network;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Models;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class SearchCameraUrlPresenter : BasePresenter
    {
        private const string All = "All";
        private readonly SearchCameraUrlService searchCameraUrlService;

        private ISearchCameraUrlView view;
        private readonly IUserRepository userRepository;
        private readonly PermissionManager<User> permissionManager;
        private readonly ILogger<SearchCameraUrlForm> logger;
        private readonly User user;

        public SearchCameraUrlPresenter(SearchCameraUrlDependencies dependencies)
            : base(dependencies)
        {
            userRepository = dependencies.UserRepository;
            permissionManager = dependencies.PermissionManager;
            logger = dependencies.Logger;
            user = userRepository.Select(permissionManager.CurrentUser.Tag.Id);

            searchCameraUrlService = new SearchCameraUrlService();
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ISearchCameraUrlView;
        }

        public override void Load()
        {
            GetAllManufacturers();
            view.CbManufacturer.SelectedIndex = 0;
            _ = SearchForHostsAsync();
        }

        public void GetAllManufacturers()
        {
            view.CbManufacturer.Items.Clear();
            view.CbManufacturer.Items.Add(Lng.Elem(All));
            var manufacturers = searchCameraUrlService.GetManufacturers();
            foreach (var manufacturer in manufacturers)
            {
                AddManufacturer(manufacturer);
            }
        }

        public void AddCameraUrls(List<string> cameraUrls)
        {
            view.CbCameraUrls.Items.Clear();
            foreach (var cameraUrl in cameraUrls)
            {
                view.CbCameraUrls.Items.Add(cameraUrl);
            }
        }

        public void AddManufacturer(string manufacturerName)
        {
            view.CbManufacturer.Items.Add(manufacturerName);
        }

        public void GetCamerasByManufacturer()
        {
            var manufacturer = view.CbManufacturer.SelectedItem.ToString();

            var cameras = manufacturer == Lng.Elem(All) ?
                searchCameraUrlService.GetAllCameraUrls() :
                searchCameraUrlService.GetCameraUrls(manufacturer);

            AddCameraUrls(cameras);
        }

        public void Search()
        {
            var timeoutMs = (int)view.NudTimeout.Value;
            string url = null;

            int startIndex = 0;
            int itemCount = 0;
            view.InvokeAction(() =>
            {
                startIndex = view.CbCameraUrls.SelectedIndex > -1 ? view.CbCameraUrls.SelectedIndex : 0;
                itemCount = view.CbCameraUrls.Items.Count;
            });

            WaitForm.ExecuteAction(progress =>
            {
                try
                {
                    var camera = GetNetCamera();

                    for (int i = startIndex; i < itemCount; i++)
                    {
                        string itemText = string.Empty;
                        view.InvokeAction(() =>
                        {
                            itemText = view.CbCameraUrls.Items[i].ToString();
                        });

                        url = SearchCameraUrlService.ModifyUrl(camera, itemText);
                        if (StreamTester.TestUrl(url, timeoutMs))
                        {
                            progress.Report(new ProgressReport
                            {
                                Percentage = itemCount,
                                StatusMessage = $"{Lng.Elem("URL")}: {url}"
                            });

                            view.InvokeAction(() =>
                            {
                                view.CbCameraUrls.SelectedIndex = i;
                            });
                            break;
                        }
                        else
                        {
                            progress.Report(new ProgressReport
                            {
                                Percentage = i,
                                StatusMessage = $"{Lng.Elem("URL")}: {url}"
                            });
                            url = String.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }, 0, itemCount, Lng.Elem("Please wait…"));

            if (String.IsNullOrEmpty(url))
            {
                ShowError("Camera URL not found");
            }
            else
            {
                ShowInfo($"Camera URL found: {url}");
            }
        }


        private NetCamera GetNetCamera()
        {
            NetCamera netCamera = null;
            view.InvokeAction(() => netCamera = new NetCamera
            {
                IpAddress = view.CbIpAddress.Text,
                Username = view.TbUsername.Text,
                Password = view.TbPassword.Text,
                Channel = (int)view.NudChannel.Value,
                Width = (int)view.NudWidth.Value,
                Height = (int)view.NudHeight.Value,
            });
            return netCamera;
        }

        private string GetUrl(NetCamera camera, int timeoutMs)
        {
            foreach (var cameraUrl in view.CbCameraUrls.Items)
            {
                var url = cameraUrl.ToString();
                url = SearchCameraUrlService.ModifyUrl(camera, url);
                if (StreamTester.TestUrl(url, timeoutMs))
                {
                    return url;
                }
            }

            return String.Empty;
        }

        public void CopyUrlToClipboard()
        {
            var camera = GetNetCamera();
            var url = SearchCameraUrlService.ModifyUrl(camera, view.CbCameraUrls.SelectedItem?.ToString() ?? String.Empty);
            Clipboard.SetText(url);
        }

        public async Task SearchForHostsAsync()
        {
            HostDiscoveryService.HostDiscovered += OnHostDiscovered;
            await Task.Run(HostDiscoveryService.Discovery);
            HostDiscoveryService.HostDiscovered -= OnHostDiscovered;
        }

        private void OnHostDiscovered(HostDiscoveryResult result)
        {
            view.InvokeAction(() =>
            {
                view.CbIpAddress.Items.Add(result);
            });
        }
    }
}
