using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.Database;
using Mtf.LanguageService;
using Mtf.Permissions.Services;
using System;
using System.Configuration;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace LiveView.Presenters
{
    public class GeneralOptionsPresenter : BasePresenter
    {
        private IGeneralOptionsView view;
        private readonly ILogger<GeneralOptionsForm> logger;
        private readonly ITemplateRepository templateRepository;
        private readonly IUserRepository userRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IUsersInGroupsRepository userGroupRepository;
        private readonly PermissionManager<User> permissionManager;
        public const string AutoDetect = "Auto detect";

        public GeneralOptionsPresenter(GeneralOptionsPresenterDependencies dependencies)
            : base(dependencies)
        {
            templateRepository = dependencies.TemplateRepository;
            userRepository = dependencies.UserRepository;
            groupRepository = dependencies.GroupRepository;
            userGroupRepository = dependencies.UserGroupRepository;
            permissionManager = dependencies.PermissionManager;
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IGeneralOptionsView;
        }

        public override void Load()
        {
            var groups = groupRepository.SelectAll();
            var users = userRepository.SelectAll();
            var usersInGroups = userGroupRepository.SelectAll();
            var templates = templateRepository.SelectAll();

            var userInGroupIds = usersInGroups
                .Where(ug => ug.UserId == permissionManager.CurrentUser.Tag.Id)
                .Select(ug => ug.GroupId)
                .ToList();

            var userGroups = groups
                .Where(g => userInGroupIds.Contains(g.Id))
                .ToList();

            userGroups.AddRange(groups.Where(g => g.ParentGroupId.HasValue && userInGroupIds.Contains(g.ParentGroupId.Value)));

            var filteredUsers = users
                .Where(u => usersInGroups.Any(ug => ug.UserId == u.Id && userGroups.Any(g => g.Id == ug.GroupId)))
                .ToList();

            view.CbUsers.AddItems(filteredUsers);
            view.CbUsers.Items.Insert(0, String.Empty);
            view.CbAutoLoadedTemplate.AddItems(templates);
            
            var templateToLoadAutomatically = generalOptionsRepository.Get(Setting.AutoLoadedTemplate, String.Empty);
            if (!String.IsNullOrEmpty(templateToLoadAutomatically))
            {
                for (int i = 0; i < view.CbAutoLoadedTemplate.Items.Count; i++)
                {
                    if (view.CbAutoLoadedTemplate.Items[i] is Template template && template.TemplateName == templateToLoadAutomatically)
                    {
                        view.CbAutoLoadedTemplate.SelectedIndex = i;
                        break;
                    }
                }
            }

            var userToLogInAutomatically = generalOptionsRepository.Get(Setting.AutoLoginUser, String.Empty);
            if (!String.IsNullOrEmpty(userToLogInAutomatically))
            {
                for (int i = 0; i < view.CbUsers.Items.Count; i++)
                {
                    if (view.CbUsers.Items[i] is User user && user.Username == userToLogInAutomatically)
                    {
                        view.CbUsers.SelectedIndex = i;
                        break;
                    }
                }                
            }

            view.NudFPS.Value = generalOptionsRepository.Get(Setting.FPS, 25);
            view.NudRestartTemplate.Value = generalOptionsRepository.Get(Setting.RestartTemplate, 0);
            view.NudMaximumTimeToWaitForNewPicture.Value = generalOptionsRepository.Get(Setting.MaximumTimeToWaitForNewPicture, 300);
            view.NudMaximumDeflectionBetweenLiveViewAndRecorder.Value = generalOptionsRepository.Get(Setting.MaximumDeflectionBetweenLiveViewAndRecorder, 1000);
            view.NudStatisticMessageAfterEveryMinutes.Value = generalOptionsRepository.Get(Setting.StatisticMessageAfterEveryMinutes, 1440);
            view.NudTimeBetweenCheckVideoServers.Value = generalOptionsRepository.Get(Setting.TimeBetweenCheckVideoServers, 3000);
            view.NudMaximumTimeToWaitForAVideoServerIs.Value = generalOptionsRepository.Get(Setting.MaximumTimeToWaitForAVideoServerIs, 500);

            view.ChkReduceSequenceUsageOfNetworkAndCPU.Checked = generalOptionsRepository.Get(Setting.ReduceSequenceUsageOfNetworkAndCPU, false);
            view.ChkDeblock.Checked = generalOptionsRepository.Get(Setting.Deblock, false);
            view.ChkCloseSequenceApplicationOnFullScreenDisplayDevice.Checked = generalOptionsRepository.Get(Setting.CloseSequenceApplicationOnFullScreenDisplayDevice, false);
            view.ChkLiveView.Checked = generalOptionsRepository.Get(Setting.LiveView, false);
            view.ChkThreading.Checked = generalOptionsRepository.Get(Setting.Threading, true);
            view.ChkOpenMotionPopupWhenProgramStarts.Checked = generalOptionsRepository.Get(Setting.OpenMotionPopupWhenProgramStarts, false);
            view.ChkOpenControlCenterWhenProgramStarts.Checked = generalOptionsRepository.Get(Setting.OpenControlCenterWhenProgramStarts, true);
            view.ChkUseCustomNoSignalImage.Checked = generalOptionsRepository.Get(Setting.UseCustomNoSignalImage, false);
            view.ChkVerboseDebugLogging.Checked = generalOptionsRepository.Get(Setting.VerboseDebugLogging, false);

            var portNames = SerialPort.GetPortNames();
            view.CbKBD300ACOMPort.AddItems(portNames);
            view.CbKBD300ACOMPort.Items.Insert(0, String.Empty);
            view.CbWatchdogPort.AddItems(portNames);
            view.CbWatchdogPort.Items.Insert(0, String.Empty);
            view.CbWatchdogPort.Items.Insert(1, Lng.Elem(AutoDetect));

            view.CbKBD300ACOMPort.SelectedItem = generalOptionsRepository.Get(Setting.KBD300ACOMPort, String.Empty);
            view.CbWatchdogPort.SelectedItem = generalOptionsRepository.Get(Setting.WatchdogPort, String.Empty);

            var usage = BaseRepository.GetDatabaseUsagePercentageWithLimit();
            view.TbDatabaseUsage.Text = usage == -1 ? "N/A" : $"{usage}%";
            var builder = new DbConnectionStringBuilder
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["LiveViewConnectionString"]?.ConnectionString
            };
            
            view.TbDataSource.Text = (builder["Data Source"] ?? builder["Server"]).ToString();
            view.TbDatabaseName.Text = (builder["Initial Catalog"] ?? builder["Database"]).ToString();
            view.NudConnectionTimeout.Value = BaseRepository.CommandTimeout.HasValue ? BaseRepository.CommandTimeout.Value : 30;

            var integratedSecurityObject = builder["Integrated Security"] ?? builder["Trusted_Connection"];
            
            if (Boolean.TryParse(integratedSecurityObject.ToString(), out var integratedSecurity) || String.Equals(integratedSecurityObject.ToString(), "SSPI", StringComparison.OrdinalIgnoreCase))
            {
                view.ChkIntegratedSecurity.Checked = integratedSecurity;
                view.TbUsername.Text = BaseRepository.ExecuteQuery("SELECT SYSTEM_USER").Rows[0][0].ToString();
                view.LblPassword.Visible = false;
                view.TbPassword.Visible = false;
            }
            else
            {
                view.ChkIntegratedSecurity.Checked = false;
                view.TbUsername.Text = builder["User ID"].ToString();
                view.TbPassword.Text = builder["Password"].ToString();
            }

            try
            {
                if (Boolean.TryParse(builder["Encrypt"].ToString(), out var encrypt))
                {
                    view.ChkEncrypt.Checked = integratedSecurity;
                }
                else
                {
                    view.ChkEncrypt.Checked = false;
                }
            }
            catch
            {
                view.ChkEncrypt.Checked = false;
            }

            try
            {
                if (Boolean.TryParse(builder["Pooling"].ToString(), out var pooling))
                {
                    view.ChkPooling.Checked = integratedSecurity;
                }
                else
                {
                    view.ChkPooling.Checked = false;
                }
            }
            catch
            {
                view.ChkPooling.Checked = false;
            }
        }

        public void LoadDefaultSettings()
        {
            view.NudFPS.Value = 25;
            view.NudRestartTemplate.Value = 0;
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
            view.ChkOpenMotionPopupWhenProgramStarts.Checked = true;
            view.ChkOpenControlCenterWhenProgramStarts.Checked = false;
            view.ChkUseCustomNoSignalImage.Checked = false;
            view.ChkVerboseDebugLogging.Checked = false;

            if (view.CbUsers.Items.Count > 0)
            {
                view.CbUsers.SelectedIndex = 0;
            }

            //view.TbDatabaseFolder.Text = @"C:\Database";
            //view.TbDataSource.Text = "127.0.0.1";
            //view.TbPassword.Text = "password";
            //view.TbUsername.Text = "admin";
            //view.TbDatabaseName.Text = "MyDatabase";

            view.RbVerboseLogEveryEvents.Checked = false;
            view.RbVerboseLogOnlyErrors.Checked = true;
        }

        public void LoadStandardSettings()
        {
            view.NudFPS.Value = 25;
            view.NudRestartTemplate.Value = 0;
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
            view.ChkOpenControlCenterWhenProgramStarts.Checked = false;
            view.ChkUseCustomNoSignalImage.Checked = false;
            view.ChkVerboseDebugLogging.Checked = false;

            if (view.CbUsers.Items.Count > 0)
            {
                view.CbUsers.SelectedIndex = 0;
            }

            //view.TbDatabaseFolder.Text = @"C:\Database";
            //view.TbDataSource.Text = "127.0.0.1";
            //view.TbPassword.Text = "password";
            //view.TbUsername.Text = "admin";
            //view.TbDatabaseName.Text = "MyDatabase";

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
            if (view.CbAutoLoadedTemplate.SelectedItem is Template template)
            {
                generalOptionsRepository.Set(Setting.AutoLoadedTemplate, template.TemplateName);
            }
            if (view.CbUsers.SelectedItem is User user)
            {
                generalOptionsRepository.Set(Setting.AutoLoginUser, user.Username);
            }
            else
            {
                generalOptionsRepository.Set(Setting.AutoLoginUser, String.Empty);
            }

            generalOptionsRepository.Set(Setting.ReduceSequenceUsageOfNetworkAndCPU, view.ChkReduceSequenceUsageOfNetworkAndCPU.Checked);
            generalOptionsRepository.Set(Setting.Deblock, view.ChkDeblock.Checked);
            generalOptionsRepository.Set(Setting.CloseSequenceApplicationOnFullScreenDisplayDevice, view.ChkCloseSequenceApplicationOnFullScreenDisplayDevice.Checked);
            generalOptionsRepository.Set(Setting.LiveView, view.ChkLiveView.Checked);
            generalOptionsRepository.Set(Setting.Threading, view.ChkThreading.Checked);
            generalOptionsRepository.Set(Setting.OpenMotionPopupWhenProgramStarts, view.ChkOpenMotionPopupWhenProgramStarts.Checked);
            generalOptionsRepository.Set(Setting.OpenControlCenterWhenProgramStarts, view.ChkOpenControlCenterWhenProgramStarts.Checked);
            generalOptionsRepository.Set(Setting.UseCustomNoSignalImage, view.ChkUseCustomNoSignalImage.Checked);
            generalOptionsRepository.Set(Setting.VerboseDebugLogging, view.ChkVerboseDebugLogging.Checked);

            generalOptionsRepository.Set(Setting.FPS, (int)view.NudFPS.Value);
            generalOptionsRepository.Set(Setting.RestartTemplate, (int)view.NudRestartTemplate.Value);
            generalOptionsRepository.Set(Setting.MaximumTimeToWaitForNewPicture, (int)view.NudMaximumTimeToWaitForNewPicture.Value);
            generalOptionsRepository.Set(Setting.MaximumDeflectionBetweenLiveViewAndRecorder, (int)view.NudMaximumDeflectionBetweenLiveViewAndRecorder.Value);
            generalOptionsRepository.Set(Setting.StatisticMessageAfterEveryMinutes, (int)view.NudStatisticMessageAfterEveryMinutes.Value);
            generalOptionsRepository.Set(Setting.TimeBetweenCheckVideoServers, (int)view.NudTimeBetweenCheckVideoServers.Value);
            generalOptionsRepository.Set(Setting.MaximumTimeToWaitForAVideoServerIs, (int)view.NudMaximumTimeToWaitForAVideoServerIs.Value);

            generalOptionsRepository.Set(Setting.KBD300ACOMPort, view.CbKBD300ACOMPort.SelectedItem);
            generalOptionsRepository.Set(Setting.WatchdogPort, view.CbWatchdogPort.SelectedIndex == 1 ? AutoDetect : view.CbWatchdogPort.SelectedItem);
        }

        public void GenerateConfigFile()
        {
            if (view.SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var loginDetails = view.ChkIntegratedSecurity.Checked ? "Integrated Security=True" :
                    $"User ID={view.TbUsername.Text};Password={view.TbPassword.Text}";

                var configuration = new XElement("configuration",
                    new XElement("connectionStrings",
                        new XElement("add",
                            new XAttribute("name", "MasterConnectionString"),
                            new XAttribute("connectionString", $"Data Source={view.TbDataSource.Text};Initial Catalog=master;{loginDetails};"),
                            new XAttribute("providerName", "Microsoft.Data.SqlClient")
                        ),
                        new XElement("add",
                            new XAttribute("name", "LiveViewConnectionString"),
                            new XAttribute("connectionString", $"Data Source={view.TbDataSource.Text};Initial Catalog={view.TbDatabaseName.Text};{loginDetails};Encrypt={view.ChkEncrypt.Checked};Pooling={view.ChkPooling.Checked}"),
                            new XAttribute("providerName", "Microsoft.Data.SqlClient")
                        )
                    )
                );

                configuration.Save(view.SaveFileDialog.FileName);

                var path = Path.GetDirectoryName(view.SaveFileDialog.FileName);
                var webConfigFilePath = Path.Combine(Application.StartupPath, "web.config");
                var appConfigPath = Path.Combine(Application.StartupPath, "App.config");
                var aspnetRegiisPath = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe";

                // Step 1: Copy connection strings to web.config
                //if (File.Exists(view.SaveFileDialog.FileName))
                //{
                //    var webConfigContent = File.ReadAllText(view.SaveFileDialog.FileName);
                //    File.WriteAllText(webConfigFilePath, webConfigContent);
                //    Console.WriteLine("web.config updated with connection strings.");
                //}
                //else
                //{
                //    Console.WriteLine("ConnectionStrings.xml file not found.");
                //    return;
                //}

                // Step 2: Encrypt connection strings in web.config
                if (File.Exists(aspnetRegiisPath))
                {
                    var encryptionCmd = $"\"{aspnetRegiisPath}\" -pef \"connectionStrings\" \"{path}\" -prov DataProtectionConfigurationProvider";
                    var process = Process.Start("cmd.exe", $"/c {encryptionCmd}");
                    process.WaitForExit();
                    ShowInfo("Connection strings in web.config have been encrypted.");
                }
                else
                {
                    ShowError("aspnet_regiis.exe not found.");
                    return;
                }

                // Step 3: Update App.config with encrypted connection strings
                //if (File.Exists(webConfigFilePath) && File.Exists(appConfigPath))
                //{
                //    var webConfig = new XmlDocument();
                //    webConfig.Load(webConfigFilePath);

                //    var encryptedConnectionStrings = webConfig.SelectSingleNode("//connectionStrings");
                //    if (encryptedConnectionStrings != null)
                //    {
                //        var appConfig = new XmlDocument();
                //        appConfig.Load(appConfigPath);

                //        var configurationNode = appConfig.SelectSingleNode("/configuration");
                //        if (configurationNode == null)
                //        {
                //            ShowError("Error: Unable to locate the configuration node in App.config.");
                //            return;
                //        }

                //        // Remove old connectionStrings section
                //        var oldConnectionStrings = configurationNode.SelectSingleNode("connectionStrings");
                //        if (oldConnectionStrings != null)
                //        {
                //            configurationNode.RemoveChild(oldConnectionStrings);
                //        }

                //        // Add encrypted connectionStrings section
                //        var importedConnectionStrings = appConfig.ImportNode(encryptedConnectionStrings, true);
                //        if (importedConnectionStrings.Attributes != null)
                //        {
                //            var configProtectionProviderAttr = appConfig.CreateAttribute("configProtectionProvider");
                //            configProtectionProviderAttr.Value = "DataProtectionConfigurationProvider";
                //            importedConnectionStrings.Attributes.Append(configProtectionProviderAttr);
                //        }
                //        configurationNode.AppendChild(importedConnectionStrings);

                //        // Save updated App.config
                //        appConfig.Save(appConfigPath);
                //        ShowInfo("App.config updated with encrypted connection strings.");
                //    }
                //    else
                //    {
                //        ShowError("No connectionStrings section found in web.config.");
                //    }
                //}
                //else
                //{
                //    ShowError("Required files not found (web.config or App.config).");
                //}
            }
        }

        public void ChangeIntegratedSecurity()
        {
            if (view.ChkIntegratedSecurity.Checked)
            {
                view.LblPassword.Visible = false;
                view.TbPassword.Visible = false;
            }
            else
            {
                view.LblPassword.Visible = true;
                view.TbPassword.Visible = true;
            }
        }
    }
}
