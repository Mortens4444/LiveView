using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class AddGroupPresenter : BasePresenter
    {
        private readonly IAddGroupView addGroupView;
        private readonly IGroupRepository<Group> groupRepository;
        private readonly ILogger<AddGroup> logger;

        public AddGroupPresenter(IAddGroupView addGroupView, IGroupRepository<Group> groupRepository, ILogger<AddGroup> logger)
            : base(addGroupView)
        {
            this.addGroupView = addGroupView;
            this.groupRepository = groupRepository;
            this.logger = logger;
        }

        internal void CreateOrModifyGroup()
        {
            throw new NotImplementedException();
        }
    }
}
