using Database.Interfaces;
using LiveView.Core.Services;

namespace LiveView.Models.Dependencies
{
    public class BasePresenterDependencies
    {
        public BasePresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            FormFactory formFactory = null)
        {
            FormFactory = formFactory;
            GeneralOptionsRepository = generalOptionsRepository;
        }

        public FormFactory FormFactory { get; private set; }

        public IGeneralOptionsRepository GeneralOptionsRepository { get; private set; }
    }
}
