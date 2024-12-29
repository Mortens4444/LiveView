using Database.Interfaces;
using Database.Models;
using LiveView.Services;

namespace LiveView.Models.Dependencies
{
    public class BasePresenterDependencies
    {
        public BasePresenterDependencies(
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            FormFactory formFactory = null)
        {
            FormFactory = formFactory;
            GeneralOptionsRepository = generalOptionsRepository;
        }

        public FormFactory FormFactory { get; private set; }

        public IGeneralOptionsRepository<GeneralOption> GeneralOptionsRepository { get; private set; }
    }
}
