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

        public void CreateOrModifyGroup()
        {
            //try
            //{
            //    var groupName = addGroupView.GroupName;

            //    if (string.IsNullOrWhiteSpace(groupName))
            //    {
            //        addGroupView.ShowError("The group name cannot be empty.");
            //        return;
            //    }

            //    var existingGroup = groupRepository.GetByName(groupName);
            //    if (existingGroup != null)
            //    {
            //        existingGroup.Name = groupName;
            //        groupRepository.Update(existingGroup);
            //    }
            //    else
            //    {
            //        var newGroup = new Group { Name = groupName };
            //        groupRepository.Add(newGroup);
            //    }

            //    addGroupView.CloseForm();
            //}
            //catch (Exception ex)
            //{
            //    logger.LogError(ex, "Failed to create or modify group.");
            //    addGroupView.ShowError("An error occurred while saving the group.");
            //}
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
