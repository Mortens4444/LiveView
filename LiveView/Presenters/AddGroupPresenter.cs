using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.MessageBoxes.Enums;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class AddGroupPresenter : BasePresenter
    {
        private const string Cameras = "Cameras";
        private const int CameraIconIndex = 1;
        private const int OperationIconIndex = 0;

        private IAddGroupView view;
        private readonly IGroupRepository groupRepository;
        private readonly IUserEventRepository userEventRepository;
        private readonly IOperationRepository operationRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly IRightRepository rightRepository;
        private readonly ICameraRightRepository cameraRightRepository;
        private readonly ILogger<AddGroup> logger;

        public AddGroupPresenter(AddGroupPresenterDependencies addGroupPresenterDependencies)
            : base(addGroupPresenterDependencies)
        {
            groupRepository = addGroupPresenterDependencies.GroupRepository;
            userEventRepository = addGroupPresenterDependencies.UserEventRepository;
            operationRepository = addGroupPresenterDependencies.OperationRepository;
            cameraRepository = addGroupPresenterDependencies.CameraRepository;
            rightRepository = addGroupPresenterDependencies.RightRepository;
            cameraRightRepository = addGroupPresenterDependencies.CameraRightRepository;
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

                if (group.Id != 0)
                {
                    var existingGroup = groupRepository.Select(group.Id);
                    existingGroup.OtherInformation = group.OtherInformation;
                    existingGroup.Name = group.Name;
                    groupRepository.Update(existingGroup);
                }
                else
                {
                    var id = groupRepository.InsertAndReturnId<long>(group);
                    group.Id = id;
                    view.Group = group;
                }
            }
            catch (Exception ex)
            {
                logger.LogExceptionAndShowErrorBox(ex, "An error occurred while saving the group.");
            }
        }

        public override void Load()
        {
            view.CbEvents.AddItemsAndSelectFirst(userEventRepository.SelectAll());

            LoadAvailableCameras();
            LoadAvailableOperations();

            LoadCurrentCameraPermissions();
            LoadCurrentOperationPermissions();
        }

        private void LoadAvailableOperations()
        {
            var operations = view.ParentGroup != null && view.ParentGroup.ParentGroupId != null ? operationRepository.SelectGroupOperations(view.ParentGroup.Id) : operationRepository.SelectAll();
            AddOperationsToListView(operations, view.LvAvaialableOperationsAndCameras);
        }

        private void LoadCurrentOperationPermissions()
        {
            var operations = view.Group != null ? operationRepository.SelectGroupOperations(view.Group.Id) : new ReadOnlyCollection<Operation>(Array.Empty<Operation>());
            AddOperationsToListView(operations, view.LvOperationsAndCameras);
        }

        private void LoadAvailableCameras()
        {
            view.LvAvaialableOperationsAndCameras.AddItems(cameraRepository.SelectAll(),
                camera => new ListViewItem(camera.CameraName, CameraIconIndex)
                {
                    Tag = camera,
                    ToolTipText = camera.Guid,
                    Group = view.LvAvaialableOperationsAndCameras.Groups[Cameras]
                });
        }

        private void LoadCurrentCameraPermissions()
        {
            var cameras = view.Group != null ? cameraRepository.SelectGroupCameras(view.Group.Id) : new ReadOnlyCollection<Camera>(Array.Empty<Camera>());
            view.LvOperationsAndCameras.AddItems(cameras,
                camera => new ListViewItem(camera.CameraName, CameraIconIndex)
                {
                    Tag = camera,
                    ToolTipText = camera.Guid,
                    Group = view.LvOperationsAndCameras.Groups[Cameras]
                });
        }

        private static void AddOperationsToListView(ReadOnlyCollection<Operation> operations, ListView listView)
        {
            foreach (var operation in operations)
            {
                var groupName = operation.PermissionGroup;
                var formattedGroupName = Lng.Elem(TypeNameFormatter.ToReadableFormat(groupName));
                var permissionGroup = listView.Groups
                    .Cast<ListViewGroup>()
                    .FirstOrDefault(g => g.Name == groupName);

                if (permissionGroup == null)
                {
                    permissionGroup = new ListViewGroup(formattedGroupName, HorizontalAlignment.Left)
                    {
                        Name = groupName
                    };
                    listView.Groups.Add(permissionGroup);
                }
                var listViewItem = new ListViewItem(Lng.Elem(TypeNameFormatter.ToReadableFormat(operation.PermissionValue)), OperationIconIndex)
                {
                    Group = permissionGroup,
                    Tag = operation
                };
                listView.Items.Add(listViewItem);
            }
        }

        public void AddAllOperationsAndCameras()
        {
            AddAllItemsFromListViewToAnother(view.LvAvaialableOperationsAndCameras, view.LvOperationsAndCameras, (item) => view.OperationsAndCamerasHasElementWithId((IHaveId<long>)item.Tag));
        }

        public void AddSelectedOperationsAndCameras()
        {
            AddSelectedItemsFromListViewToAnother(view.LvAvaialableOperationsAndCameras, view.LvOperationsAndCameras, (item) => view.OperationsAndCamerasHasElementWithId((IHaveId<long>)item.Tag));
        }

        public void CreateEvent()
        {
            try
            {
                var userEvent = view.GetUserEvent();
                if (String.IsNullOrWhiteSpace(userEvent.Name))
                {
                    ShowError("The event name cannot be empty.");
                    return;
                }

                var existingUserEvent = userEventRepository.GetByName(userEvent.Name);
                if (existingUserEvent == null)
                {
                    userEventRepository.Insert(userEvent);
                }
            }
            catch (Exception ex)
            {
                logger.LogExceptionAndShowErrorBox(ex, "An error occurred while saving the event.");
            }
        }

        public void DeleteEvent()
        {
            if (!ShowConfirm("Are you sure you want to delete this item?", Decide.No))
            {
                return;
            }

            var userEvent = view.GetUserEvent();
            userEventRepository.DeleteWhere(new { userEvent.Name });
        }

        public void ModifyEvent()
        {
            try
            {
                var userEvent = view.GetUserEvent();
                if (String.IsNullOrWhiteSpace(userEvent.Name))
                {
                    ShowError("The event name cannot be empty.");
                    return;
                }

                var existingUserEvent = userEventRepository.GetByName(userEvent.Name);
                if (existingUserEvent != null)
                {
                    existingUserEvent.Note = userEvent.Note;
                    userEventRepository.Update(existingUserEvent);
                }
            }
            catch (Exception ex)
            {
                logger.LogExceptionAndShowErrorBox(ex, "An error occurred while saving the event.");
            }
        }

        public void RemoveAllOperationsAndCameras()
        {
            view.RemoveAllItem(view.LvOperationsAndCameras);
        }

        public void RemoveSelectedOperationsAndCameras()
        {
            view.RemoveSelectedItems(view.LvOperationsAndCameras);
        }

        public void SavePermissions()
        {
            if (view.ParentGroup == null)
            {
                ShowError("Built-in developer group cannot be modified.");
                return;
            }

            var group = view.GetGroup();
            if (group.Id == 0)
            {
                ShowError("The group not exists.");
                return;
            }

            var existingGroup = groupRepository.Select(group.Id);
            groupRepository.DeleteGroupPermissions(group.Id);
            var userEvent = view.GetUserEvent();
            var existingUserEvent = userEventRepository.GetByName(userEvent.Name);
            if (existingUserEvent == null)
            {
                ShowError("The event not exists.");
                return;
            }

            foreach (ListViewItem item in view.LvOperationsAndCameras.Items)
            {
                if (item.Tag is Operation operation)
                {
                    rightRepository.Insert(new Right
                    {
                        GroupId = existingGroup.Id,
                        OperationId = operation.Id,
                        UserEvent = existingUserEvent.Id
                    });
                }
                else if (item.Tag is Camera camera)
                {
                    cameraRightRepository.Insert(new CameraRight
                    {
                        GroupId = existingGroup.Id,
                        CameraId = camera.Id,
                        UserEvent = existingUserEvent.Id
                    });
                }
            }
        }

        public void SelectAllCameras()
        {
            view.LvAvaialableOperationsAndCameras.Groups[Cameras].SelectAll();
        }

        public void SelectAllOperations()
        {
            var enums = PermissionEnumProviders.Get();
            foreach (var enumType in enums)
            {
                view.LvAvaialableOperationsAndCameras.Groups[enumType.Name].SelectAll();
            }
        }
    }
}
