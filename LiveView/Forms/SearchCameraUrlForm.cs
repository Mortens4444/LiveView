using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class SearchCameraUrlForm : BaseView, ISearchCameraUrlView
    {
        private SearchCameraUrlPresenter presenter;

        public ComboBox CbCameraUrls => cbCameraUrls;

        public ComboBox CbManufacturer => cbManufacturer;

        public ComboBox CbIpAddress => cbIpAddress;

        public TextBox TbUsername => tbUsername;

        public TextBox TbPassword => tbPassword;

        public NumericUpDown NudChannel => nudChannel;

        public NumericUpDown NudTimeout => nudTimeout;

        public NumericUpDown NudWidth => nudWidth;

        public NumericUpDown NudHeight => nudHeight;

        public SearchCameraUrlForm(IServiceProvider serviceProvider) : base(serviceProvider, typeof(SearchCameraUrlPresenter))
        {
            InitializeComponent();
            Translator.Translate(this);
        }

        private void CbManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.GetCamerasByManufacturer();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            presenter.Search();
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            presenter.CopyUrlToClipboard();
        }

        private void SearchCameraUrlForm_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as SearchCameraUrlPresenter;
            presenter.Load();
        }
    }
}
