using LiveView.Core.Dto;
using Mtf.LanguageService;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class DisplayDeviceIdentifier : Form
    {
        private const int secondsToShow = 5;
        private DisplayDto display;

        public DisplayDeviceIdentifier(DisplayDto display)
        {
            InitializeComponent();
            this.display = display;

            lblDeviceId.Text = Lng.Elem(lblDeviceId.Text);

            lblDeviceName.Text = display.DeviceName;
            lblAdapter.Text = display.AdapterName;
            lblId.Text = display.SziltechId;

            lblDeviceName2.Text = display.SziltechId;

            tCloser.Interval = secondsToShow * 1000;
            tCloser.Start();
        }

        private void DisplayDeviceIdentifier_Load(object sender, EventArgs e)
        {
            Location = new Point(((2 * display.X) + display.Width - Width) / 2, ((2 * display.Y) + display.Height - Height) / 2);
        }

        private void TCloser_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
