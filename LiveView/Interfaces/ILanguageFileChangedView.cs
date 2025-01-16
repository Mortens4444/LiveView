using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface ILanguageFileChangedView : IView
    {
        CheckBox ChkDoNotShowAgain {  get; }
    }
}
