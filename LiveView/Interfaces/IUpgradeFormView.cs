using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IUpgradeFormView : IView
    {
        TextBox TbSecretCode { get; }

        RichTextBox RtbUpgradeCode { get; }
    }
}
