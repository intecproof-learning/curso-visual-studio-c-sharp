using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Implementations;
using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces;
using Finanzas.CursoVisualStudio.Shared.DTOs;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Finanzas.CursoVisualStudio.Forms.Demo.User
{
    public class UserVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool isEditingBtnVisible;
        private bool isOperationBtnVisible;
        private Shared.DTOs.User userDto;
        private IUserManagementBusiness business;
        private List<Shared.DTOs.User> users;
        private BindingList<UserModuleRelDto> relatedModules;
        private List<ModuleUserRelSearchBoxDto> allModulesSearchBox;
        private String searchDialogBoxFilter;

        public bool IsEditingBtnVisible
        {
            get => isEditingBtnVisible;
            set
            {
                isEditingBtnVisible = value;
                this.NotifyPropertyChanged();
            }
        }
        public bool IsOperationBtnVisible
        {
            get => isOperationBtnVisible;
            set
            {
                isOperationBtnVisible = value;
                this.NotifyPropertyChanged();
            }
        }

        public Shared.DTOs.User UserDto
        {
            get => userDto;
            set
            {
                userDto = value;
                this.NotifyPropertyChanged();
            }
        }

        public List<Shared.DTOs.User> Users
        {
            get => users;
            private set
            {
                users = value;
                this.NotifyPropertyChanged();
            }
        }

        public BindingList<UserModuleRelDto> RelatedModules
        {
            get => relatedModules;
            set
            {
                relatedModules = value;
                this.NotifyPropertyChanged();
            }
        }

        public string SearchDialogBoxFilter
        {
            get => searchDialogBoxFilter;
            set
            {
                searchDialogBoxFilter = value;
                this.NotifyPropertyChanged();
            }
        }

        public List<ModuleUserRelSearchBoxDto> AllModulesSearchBox
        {
            get => allModulesSearchBox;
            set
            {
                allModulesSearchBox = value;
                this.NotifyPropertyChanged();
            }
        }

        public UserVM()
        {
            this.isEditingBtnVisible = false;
            this.isOperationBtnVisible = true;
            this.userDto = new Shared.DTOs.User();
            this.business = new UserManagementBusiness();
            this.GetUsers();
        }

        public void EnableEditingMode(bool isEditing)
        {
            this.IsEditingBtnVisible = isEditing;
            this.IsOperationBtnVisible = !isEditing;
        }

        public void Clean()
        {
            this.EnableEditingMode(false);
            this.UserDto = new Shared.DTOs.User();
            this.GetUsers();
        }

        public ObjectResponse<Shared.DTOs.User> SaveModule()
        {
            //userDto.RelatedModules =
            //    this.RelatedModules.ToList();
            return this.business.CreateOrUpdateUser(this.userDto);
        }

        public void GetUsers()
        {
            var result = this.business.GetUser("");
            if (result.IsSucess == true)
            {
                this.Users = result.ObjectResult;
            }
            else
            {
                this.Users = new List<Shared.DTOs.User>();
            }
        }

        public void GetRelatedModules()
        {
            UserManagementBusiness userBusiness = new UserManagementBusiness();
            var result = userBusiness.GetUser(this.SearchDialogBoxFilter);
            if (result.IsSucess == true)
            {
                var findUsers = result.ObjectResult.Select(or => new ModuleUserRelSearchBoxDto()
                {
                    Email = or.Email,
                    ID = or.ID,
                    IsActive = true,
                    NickName = or.NickName,
                    Password = or.Password,
                    IsChecked = false,
                    RelatedModules = null
                }).ToList();

                foreach (var item in findUsers)
                {
                    if (this.relatedModules.Any(ru => ru.ID == item.ID) == true)
                    {
                        item.IsChecked = true;
                    }
                }

                this.AllModulesSearchBox = new List<ModuleUserRelSearchBoxDto>(findUsers);
            }
            else
            {
                this.AllModulesSearchBox = new List<ModuleUserRelSearchBoxDto>();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
