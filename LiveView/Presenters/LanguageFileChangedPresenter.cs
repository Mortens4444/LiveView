using Database.Enums;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Database.Services;
using System.IO;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class LanguageFileChangedPresenter : BasePresenter
    {
        public static string LanguageFilePath = Path.Combine(Application.StartupPath, "Languages.ods");
        public static string OriginalLanguageFileHash = "13e6d30899fde5de23b95146b865ddd54a421e760dcad4916e5620c8a71f8404";

        private ILanguageFileChangedView view;
        private readonly ILogger<LanguageFileChangedForm> logger;

        public LanguageFileChangedPresenter(LanguageFileChangedPresenterDependencies languageFileChangedPresenterDependencies)
            : base(languageFileChangedPresenterDependencies)
        {
            logger = languageFileChangedPresenterDependencies.Logger;
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
            var csvStream = ResourceHelper.GetEmbeddedResourceStream("LiveView.Resources.Languages.ods", typeof(LanguageFileChangedPresenter).Assembly);
            using (var fileStream = File.Create(LanguageFilePath))
            {
                csvStream.CopyTo(fileStream);
            }
            generalOptionsRepository.Set(Setting.LanguageFileHash, OriginalLanguageFileHash);
            CloseForm();
        }
    }
}
