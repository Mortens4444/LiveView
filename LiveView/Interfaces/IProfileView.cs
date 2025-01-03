using Mtf.Controls;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface IProfileView : IView
    {
        TextBox TbFullName { get; }

        TextBox TbAddress { get; }

        TextBox TbEmailAddress { get; }

        TextBox TbTelephoneNumber { get; }

        TextBox TbLicensePlate { get; }

        TextBox TbOtherInformation { get; }

        TextBox TbUsername { get; }

        PasswordBox TbCurrentPassword { get; }

        PasswordBox TbNewPassword { get; }

        PictureBox PbPicture { get; }

        OpenFileDialog OpenFileDialog { get; }
    }
}
