using LiveView.Interfaces;
using LiveView.Services;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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

        /// <summary>
        /// Displays a form of the specified type as a modal dialog and returns a value 
        /// indicating whether the dialog result was successful (OK or Yes).
        /// </summary>
        /// <typeparam name="TFormType">
        /// The type of the form to be displayed. It must inherit from <see cref="Form"/>.
        /// </typeparam>
        /// <param name="parameters">
        /// An array of parameters to pass to the form's constructor. These are used to initialize 
        /// the form when it is created by the <see cref="formFactory"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the dialog result is <see cref="DialogResult.OK"/> or <see cref="DialogResult.Yes"/>; 
        /// otherwise, <c>false</c>.
        /// </returns>
        public bool ShowDialog<TFormType>(params object[] parameters)
            where TFormType : Form
        {
            var form = formFactory.CreateForm<TFormType>(parameters);
            var dialogResult = form.ShowDialog();
            return dialogResult == DialogResult.OK || dialogResult == DialogResult.Yes;
        }

        public void CloseForm()
        {
            view.Close();
        }
    }
}
