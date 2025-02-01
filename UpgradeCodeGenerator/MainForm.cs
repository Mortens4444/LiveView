namespace UpgradeCodeGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            cbLiveViewEdition.Items.Add(LiveViewEdition.Standard.ToString());
            cbLiveViewEdition.Items.Add(LiveViewEdition.Premium.ToString());
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            var liveViewEdition = (LiveViewEdition)Enum.Parse(typeof(LiveViewEdition), cbLiveViewEdition.SelectedItem.ToString());
            rtbResult.Text = UpgradeCodeManager.GenerateUpgradeCode(tbSecretCode.Text, liveViewEdition, (int)nudExpiryMinutes.Value);
        }
    }
}
