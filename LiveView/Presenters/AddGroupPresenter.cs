using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class AddGroupPresenter
    {
        private readonly IAddGroupView addGroupView;
        private readonly IGroupRepository groupRepository;

        public AddGroupPresenter(IAddGroupView addGroupView, IGroupRepository groupRepository)
        {
            this.addGroupView = addGroupView;
            this.groupRepository = groupRepository;
        }
    }
}
