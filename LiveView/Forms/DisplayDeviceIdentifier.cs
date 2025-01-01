using LiveView.Core.Dto;
using LiveView.Presenters;
using Mtf.LanguageService;
using System;
using System.Drawing;

namespace LiveView.Forms
{
    public partial class DisplayDeviceIdentifier : BaseView
    {
        private const int secondsToShow = 5;

        public DisplayDeviceIdentifier(IServiceProvider serviceProvider, DisplayDto display) : base(serviceProvider, typeof(BasePresenter))
        {
            InitializeComponent();

            lblDeviceId.Text = Lng.Elem(lblDeviceId.Text);
            lblDeviceName.Text = display.DeviceName;
            lblAdapter.Text = display.AdapterName;
            lblId.Text = display.SziltechId;

            lblDeviceName2.Text = display.SziltechId;

            Location = new Point(((2 * display.X) + display.Width - Width) / 2, ((2 * display.Y) + display.Height - Height) / 2);

            tCloser.Interval = secondsToShow * 1000;
            tCloser.Start();
        }

        private void TCloser_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
