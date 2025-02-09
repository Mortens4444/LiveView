using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class UpgradeFormPresenter : BasePresenter
    {
        private IUpgradeFormView view;
        private readonly ILogger<UpgradeForm> logger;

        public UpgradeFormPresenter(UpgradeFormPresenterDependencies dependencies)
            : base(dependencies)
        {
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IUpgradeFormView;
        }

        public void Upgrade()
        {
            if (UpgradeCodeManager.ValidateUpgradeCode(view.RtbUpgradeCode.Text, view.TbSecretCode.Text, out var edition))
            {
                Globals.HardwareKey.LiveViewEdition = edition;
                ShowInfo("LiveView Edition has been upgraded successfully.");
            }
            else
            {
                ShowError("LiveView Edition upgrade failed.");
            }
        }
    }
}
