using AxVIDEOCONTROL4Lib;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.Controls.x86;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class MotionPopup : BaseView, IMotionPopupView
    {
        private MotionPopupPresenter presenter;

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

        private void MotionPopup_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as MotionPopupPresenter;
            presenter.Load();
        }
    }
}
