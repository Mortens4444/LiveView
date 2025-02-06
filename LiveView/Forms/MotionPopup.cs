using AxVIDEOCONTROL4Lib;
using Database.Models;
using LiveView.Interfaces;
using Mtf.Controls.x86;
using System.ComponentModel;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class MotionPopup : BaseView, IMotionPopupView
    {
        public AxVideoPlayerWindow AxVideoPlayerWindow => axVideoPlayerWindow;

        public AxVideoPlayerWindow AxVideoPlayerWindow2 => axVideoPlayerWindow2;

        public AxVideoMotion AxVideoMotion => axVideoMotion;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Camera Camera { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Camera PartnerCamera { get; private set; }

        public Panel PRight => pRight;

        public MotionPopup(Camera camera, Camera partnerCamera)
        {
            InitializeComponent();
            Camera = camera;
            PartnerCamera = partnerCamera;
        }
    }
}
