using Mtf.Controls;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface ILoginFormView : IView
    {
        TextBox TbUsername { get; }

        PasswordBox TbPassword { get; }
    }
}
