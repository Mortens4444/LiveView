using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using System;

namespace LiveView.Presenters
{
    public class AddGroupPresenter : BasePresenter
    {
        private IAddGroupView view;
        private readonly IGroupRepository<Group> groupRepository;
        private readonly IUserEventRepository<UserEvent> userEventRepository;
        private readonly IOperationRepository<Operation> operationRepository;
        private readonly ILogger<AddGroup> logger;

        public AddGroupPresenter(AddGroupPresenterDependencies addGroupPresenterDependencies)
            : base(addGroupPresenterDependencies)
        {
            groupRepository = addGroupPresenterDependencies.GroupRepository;
            userEventRepository = addGroupPresenterDependencies.UserEventRepository;
            operationRepository = addGroupPresenterDependencies.OperationRepository;
            logger = addGroupPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IAddGroupView;
        }

        public void CreateOrModifyGroup()
        {
            try
            {
                var group = view.GetGroup();
                if (String.IsNullOrWhiteSpace(group.Name))
                {
                    ShowError("The group name cannot be empty.");
                    return;
                }

                var existingGroup = groupRepository.GetByName(group.Name);
                if (existingGroup != null)
                {
                    existingGroup.OtherInformation = group.OtherInformation;
                    groupRepository.Update(existingGroup);
                }
                else
                {
                    groupRepository.Insert(group);
                }

                view.Close();
            }
            catch (Exception ex)
            {
                logger.LogExceptionAndShowErrorBox(ex, "An error occurred while saving the group.");
            }
        }

        public override void Load()
        {
            view.AddItems(view.CbEvents, userEventRepository.GetAll());
            view.SelectByIndex(view.CbEvents);
        }

        public void AddAllOperationsAndCameras()
        {
            throw new NotImplementedException();
        }

        public void AddSelectedOperationsAndCameras()
        {
            throw new NotImplementedException();
        }

        public void CreateEvent()
        {
            throw new NotImplementedException();
        }

        public void DeleteEvent()
        {
            throw new NotImplementedException();
        }

        public void ModifyEvent()
        {
            throw new NotImplementedException();
        }

        public void RemoveAllOperationsAndCameras()
        {
            throw new NotImplementedException();
        }

        public void RemoveSelectedOperationsAndCameras()
        {
            throw new NotImplementedException();
        }

        public void SavePermissions()
        {
            throw new NotImplementedException();
        }

        public void SelectAllCameras()
        {
            throw new NotImplementedException();
        }

        public void SelectAllOperations()
        {
            throw new NotImplementedException();
        }
    }
}
