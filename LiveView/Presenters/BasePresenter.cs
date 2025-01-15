using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LibVLCSharp.Shared;
using LiveView.Dto;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using Mtf.LanguageService;
using Mtf.MessageBoxes.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class BasePresenter
    {
        private IView view;
        private readonly FormFactory formFactory;
        private static IEnumerable<GeneralOptionDto> generalOptions;

        protected readonly IGeneralOptionsRepository generalOptionsRepository;

        public BasePresenter(BasePresenterDependencies basePresenterDependencies) :
            this (basePresenterDependencies.GeneralOptionsRepository, basePresenterDependencies.FormFactory)
        { }

        public BasePresenter(IGeneralOptionsRepository generalOptionsRepository, FormFactory formFactory = null)
        {
            this.formFactory = formFactory;
            this.generalOptionsRepository = generalOptionsRepository;
            LoadOptions();
        }

        public void SetView(IView view)
        {
            this.view = view;
        }

        public TFormType ShowForm<TFormType>(params object[] parameters)
            where TFormType : Form
        {
            var form = formFactory.CreateForm<TFormType>(parameters);
            form.FormClosed += (s, e) => form.Dispose();
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
            form.FormClosed += (s, e) => form.Dispose();
            return view.ShowDialog(form);
        }

        public void ShowDialogWithReload<TFormType>(params object[] parameters)
            where TFormType : Form
        {
            var form = formFactory.CreateForm<TFormType>(parameters);
            form.FormClosed += (s, e) => form.Dispose();
            view.ShowDialog(form);
            Load();
        }

        public void CloseForm()
        {
            view.Close();
        }

        public bool ShowConfirm(string message, Decide decide = Decide.No)
        {
            return view.ShowConfirm(Lng.Elem("Confirmation"), Lng.Elem(message), decide);
        }

        public bool ShowConfirm(string title, string message, Decide decide = Decide.No)
        {
            return view.ShowConfirm(Lng.Elem(title), Lng.Elem(message), decide);
        }

        public void ShowInfo(string message)
        {
            ShowInfo(Lng.Elem("Information"), message);
        }

        public void ShowInfo(string title, string message)
        {
            view.ShowInfo(Lng.Elem(title), Lng.Elem(message));
        }

        public void ShowError(string title, string message)
        {
            view.ShowError(Lng.Elem(title), Lng.Elem(message));
        }

        public void ShowError(string message)
        {
            view.ShowError(Lng.Elem("General error"), Lng.Elem(message));
        }

        public void ShowError(Exception exception)
        {
#if DEBUG
            view.ShowDebugError(exception);
#else
            view.ShowError(exception);
#endif
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
                TypeId = OptionType.Int32
            });
            generalOptionsRepository.Update(new GeneralOption
            {
                Name = y,
                Value = view.Location.Y.ToString(),
                TypeId = OptionType.Int32
            });
            generalOptionsRepository.Update(new GeneralOption
            {
                Name = width,
                Value = view.Size.Width.ToString(),
                TypeId = OptionType.Int32
            });
            generalOptionsRepository.Update(new GeneralOption
            {
                Name = height,
                Value = view.Size.Height.ToString(),
                TypeId = OptionType.Int32
            });
            LoadOptions();
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
                TypeId = OptionType.Int32
            });
            generalOptionsRepository.Insert(new GeneralOption
            {
                Name = y,
                Value = view.Location.Y.ToString(),
                TypeId = OptionType.Int32
            });
            generalOptionsRepository.Insert(new GeneralOption
            {
                Name = width,
                Value = view.Size.Width.ToString(),
                TypeId = OptionType.Int32
            });
            generalOptionsRepository.Insert(new GeneralOption
            {
                Name = height,
                Value = view.Size.Height.ToString(),
                TypeId = OptionType.Int32
            });
            LoadOptions();
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

        protected void AddSelectedItemsFromListViewToAnother(ListView sourceListView, ListView destinationListView, Func<ListViewItem, bool> isItemInDestinationListView)
        {
            var itemsToView = new List<ListViewItem>();
            var items = view.GetSelectedItems(sourceListView);
            for (int i = 0; i < items.Count; i++)
            {
                if (!isItemInDestinationListView(items[i]))
                {
                    var item = (ListViewItem)items[i].Clone();
                    itemsToView.Add(item);
                }
            }
            view.AddToItems(destinationListView, itemsToView.ToArray());
        }

        protected void AddAllItemsFromListViewToAnother(ListView sourceListView, ListView destinationListView, Func<ListViewItem, bool> isItemInDestinationListView)
        {
            var itemsToView = new List<ListViewItem>();
            var items = view.GetItems(sourceListView);
            for (int i = 0; i < items.Count; i++)
            {
                if (!isItemInDestinationListView(items[i]))
                {
                    var item = (ListViewItem)items[i].Clone();
                    itemsToView.Add(item);
                }
            }
            view.AddToItems(destinationListView, itemsToView.ToArray());
        }

        private void LoadOptions()
        {
            generalOptions = generalOptionsRepository.SelectAll().Select(x => GeneralOptionDto.FromGeneralOption(x));
        }
    }
}
