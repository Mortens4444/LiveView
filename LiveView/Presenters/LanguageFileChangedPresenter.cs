using Database.Enums;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Enums;
using System.IO;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class LanguageFileChangedPresenter : BasePresenter
    {
        public static string LanguageFilePath = Path.Combine(Application.StartupPath, "Languages.ods");
        public static string OriginalLanguageFileHash = "dea9f83785a0e27ce34fe1f0a54f93e7d2bb8aadaf8ee2c72e22ef6cb22213b5";

        private ILanguageFileChangedView view;
        private readonly ILogger<LanguageFileChangedForm> logger;

        public LanguageFileChangedPresenter(LanguageFileChangedPresenterDependencies dependencies)
            : base(dependencies)
        {
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ILanguageFileChangedView;
        }

        public void AcknowledgeLanguageFileModification()
        {
            if (view.ChkDoNotShowAgain.Checked)
            {
                var hash = Hasher.GetFileSha256Hash(LanguageFilePath);
                generalOptionsRepository.Set(Setting.LanguageFileHash, hash);
                logger.LogInfo(LanguageManagementPermissions.Update, "Language file modification has been accepted.");
            }
            CloseForm();
        }

        public static bool IsModified(string actualHash)
        {
            var hash = Hasher.GetFileSha256Hash(LanguageFilePath);
            return hash != actualHash;
        }

        public void RestoreOriginalLanguageFile()
        {
            var csvStream = Mtf.Database.Services.ResourceHelper.GetEmbeddedResourceStream("LiveView.Resources.Languages.ods", typeof(LanguageFileChangedPresenter).Assembly);
            using (var fileStream = File.Create(LanguageFilePath))
            {
                csvStream.CopyTo(fileStream);
            }
            generalOptionsRepository.Set(Setting.LanguageFileHash, OriginalLanguageFileHash);
            logger.LogInfo(LanguageManagementPermissions.Update, "Language file has been restored.");
            CloseForm();
        }
    }
}
