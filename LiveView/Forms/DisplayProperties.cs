using LiveView.Dto;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class DisplayProperties : BaseView, IDisplayPropertiesView
    {
        private DisplayPropertiesPresenter presenter;
        private DisplayDto display;

        public DisplayProperties(IServiceProvider serviceProvider, DisplayDto display) : base(serviceProvider, typeof(DisplayPropertiesPresenter))
        {
            InitializeComponent();
            this.display = display;

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        public DisplayDto Display => display;

        public TextBox TbDisplayDeviceSziltechID => tbDisplayDeviceSziltechID;

        public TextBox TbDisplayDeviceIdentifier => tbDisplayDeviceIdentifier;

        public TextBox TbDisplayName => tbDisplayName;

        public TextBox TbAdapterName => tbAdapterName;

        public TextBox TbTopLeftCoordinate => tbTopLeftCoordinate;

        public TextBox TbResolution => tbResolution;

        public TextBox TbWorkPlaceArea => tbWorkPlaceArea;

        public CheckBox ChkShowSequences => chkShowSequences;

        public CheckBox ChkRemovable => chkRemovable;

        public CheckBox ChkAttachedToDesktop => chkAttachedToDesktop;

        public CheckBox ChkDefaultFullScreenDevice => chkDefaultFullScreenDevice;

        [RequirePermission(DisplayManagementPermissions.Select)]
        private void DisplayProperties_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as DisplayPropertiesPresenter;
            permissionManager.EnsurePermissions();
            presenter.Load();
        }
    }
}
