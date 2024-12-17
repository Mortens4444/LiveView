using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface ILicenseFormView : IView
    {
        Label LblLicenseStatusResult {  get; }

        Label LblId {  get; }

        Label LblUsersMaxPerAct {  get; }

        Label LblValidatedServersMaxPerAct {  get; }

        Label LblValidatedCamerasMaxPerAct {  get; }

        Label LblNotValidatedServersMaxPerAct {  get; }

        Label LblNotValidatedCamerasMaxPerAct {  get; }
    }
}
