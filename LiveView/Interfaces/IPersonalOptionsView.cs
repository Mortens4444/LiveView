using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IPersonalOptionsView : IView
    {
        ComboBox CbLanguages { get; }

        void SetOriginalTexts();
    }
}
