using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class MotionPopupPresenter : BasePresenter
    {
        private readonly ILogger<MotionPopup> logger;
        private IMotionPopupView view;

        public MotionPopupPresenter(MotionPopupPresenterDependencies dependencies)
            : base(dependencies)
        {
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IMotionPopupView;
        }

        public override void Load()
        {
            view.AxVideoPlayerWindow.AxVideoPlayer.Start(view.Camera.IpAddress, view.Camera.Guid, view.Camera.ServerEncryptedUsername, view.Camera.ServerEncryptedPassword);
            if (view.PartnerCamera != null)
            {
                view.AxVideoPlayerWindow2.AxVideoPlayer.Start(view.PartnerCamera.IpAddress, view.PartnerCamera.Guid, view.PartnerCamera.ServerEncryptedUsername, view.PartnerCamera.ServerEncryptedPassword);
            }
            else
            {
                view.PRight.Visible = false;
            }
        }
    }
}
