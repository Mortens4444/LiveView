using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using System;

namespace LiveView.Forms
{
    public partial class KBD300ASimulator : BaseView, IKBD300ASimulatorView
    {
        private KBD300ASimulatorPresenter presenter;

        public KBD300ASimulator(IServiceProvider serviceProvider) : base(serviceProvider, typeof(KBD300ASimulatorPresenter))
        {
            InitializeComponent();
            colorize = false;

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }
    }
}
