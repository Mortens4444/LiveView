using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Dto;
using LiveView.Interfaces;
using LiveView.Services;
using Mtf.MessageBoxes.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class BasePresenter
    {
        private readonly IView view;
        private readonly FormFactory formFactory;
        private static IEnumerable<GeneralOptionDto> generalOptions;

        protected readonly IGeneralOptionsRepository<GeneralOption> generalOptionsRepository;

        public BasePresenter(IView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, FormFactory formFactory = null)
        {
            this.formFactory = formFactory;
            this.generalOptionsRepository = generalOptionsRepository;
            this.view = view;
            generalOptions = generalOptionsRepository.GetAll().Select(x => GeneralOptionDto.FromGeneralOption(x));
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

        public void OnResizeOrMoveEnd()
        {
            var viewName = view.GetType().Name;
            var x = $"{viewName}_X";
            var y = $"{viewName}_Y";
            var width = $"{viewName}_Width";
            var height = $"{viewName}_Height";

            generalOptionsRepository.Update(new GeneralOption
            {
                Name = x,
                Value = view.Location.X.ToString(),
                Type = OptionType.Int32
            });
            generalOptionsRepository.Update(new GeneralOption
            {
                Name = y,
                Value = view.Location.Y.ToString(),
                Type = OptionType.Int32
            });
            generalOptionsRepository.Update(new GeneralOption
            {
                Name = width,
                Value = view.Size.Width.ToString(),
                Type = OptionType.Int32
            });
            generalOptionsRepository.Update(new GeneralOption
            {
                Name = height,
                Value = view.Size.Height.ToString(),
                Type = OptionType.Int32
            });

        }

        public void InsertFormLocationAndSize()
        {
            var viewName = view.GetType().Name;
            var x = $"{viewName}_X";
            var y = $"{viewName}_Y";
            var width = $"{viewName}_Width";
            var height = $"{viewName}_Height";

            generalOptionsRepository.Insert(new GeneralOption
            {
                Name = x,
                Value = view.Location.X.ToString(),
                Type = OptionType.Int32
            });
            generalOptionsRepository.Insert(new GeneralOption
            {
                Name = y,
                Value = view.Location.Y.ToString(),
                Type = OptionType.Int32
            });
            generalOptionsRepository.Insert(new GeneralOption
            {
                Name = width,
                Value = view.Size.Width.ToString(),
                Type = OptionType.Int32
            });
            generalOptionsRepository.Insert(new GeneralOption
            {
                Name = height,
                Value = view.Size.Height.ToString(),
                Type = OptionType.Int32
            });
        }

        public void SetLocationAndSize()
        {
            var viewName = view.GetType().Name;
            var x = $"{viewName}_X";
            var y = $"{viewName}_Y";
            var width = $"{viewName}_Width";
            var height = $"{viewName}_Height";

            var filtered = generalOptions.Where(generalOption => generalOption.Name.StartsWith($"{viewName}_"));
            var xLocation = filtered.FirstOrDefault(generalOption => generalOption.Name == x);
            var yLocation = filtered.FirstOrDefault(generalOption => generalOption.Name == y);
            var viewWidth = filtered.FirstOrDefault(generalOption => generalOption.Name == width);
            var viewHeight = filtered.FirstOrDefault(generalOption => generalOption.Name == height);

            if (xLocation != null)
            {
                view.Location = new Point(xLocation.GetValue<int>(), yLocation.GetValue<int>());
                view.Size = new Size(viewWidth.GetValue<int>(), viewHeight.GetValue<int>());
            }
            else
            {
                InsertFormLocationAndSize();
            }
        }
    }
}
