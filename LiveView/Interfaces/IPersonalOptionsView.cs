using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IPersonalOptionsView : IView
    {
        ComboBox CbLanguages { get; }

        CheckBox ChkUseCustomColors { get; }

        void SetOriginalTexts();
    }
}
