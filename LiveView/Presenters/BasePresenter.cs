using LiveView.Interfaces;
using LiveView.Services;
using Mtf.MessageBoxes.Enums;
using System;
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
            view.Show(form);
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
            return view.ShowDialog(form);
        }

        public void ShowDialogWithReload<TFormType>(params object[] parameters)
            where TFormType : Form
        {
            var form = formFactory.CreateForm<TFormType>(parameters);
            if (view.ShowDialog(form))
            {
                Load();
            }
        }

        public void CloseForm()
        {
            view.Close();
        }

        public bool ShowConfirm(string title, string message, Decide decide = Decide.No)
        {
            return view.ShowConfirm(title, message, decide);
        }

        public void ShowInfo(string title, string message)
        {
            view.ShowInfo(title, message);
        }


        public void ShowError(string title, string message)
        {
            view.ShowError(title, message);
        }

        public void ShowError(Exception exception)
        {
            view.ShowError(exception);
        }

        public virtual void Load()
        {
        }
    }
}
