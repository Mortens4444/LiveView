using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class GeneralOptionsPresenter : BasePresenter
    {
        private IGeneralOptionsView view;
        private readonly ILogger<GeneralOptionsForm> logger;

        public GeneralOptionsPresenter(GeneralOptionsPresenterDependencies generalOptionsPresenterDependencies)
            : base(generalOptionsPresenterDependencies)
        {
            logger = generalOptionsPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IGeneralOptionsView;
        }

        public void LoadDefaultSettings()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public void LoadStandardSettings()
        {
            throw new NotImplementedException();
        }

        public void SelectNoSignalImage()
        {
            throw new NotImplementedException();
        }

        public void SaveSettings()
        {
            throw new NotImplementedException();
        }
    }
}
