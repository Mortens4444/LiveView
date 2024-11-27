using LiveView.Interfaces;
using LiveView.Services;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class BasePresenter
    {
        private readonly IView view;
        private readonly FormFactory formFactory;

        public BasePresenter(IView view, FormFactory formFactory = null)
        {
            this.formFactory = formFactory;
            this.view = view;
        }

        public TFormType ShowForm<TFormType>(params object[] parameters)
            where TFormType : Form
        {
            var form = formFactory.CreateForm<TFormType>(parameters);
            form.Show();
            return form;
        }

        public void CloseForm()
        {
            view.Close();
        }
    }
}
