using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Implementations;
using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces;
using Finanzas.CursoVisualStudio.Shared.DTOs;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Finanzas.CursoVisualStudio.Forms.Demo
{
    public class ModuleVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool isEditingBtnVisible;
        private bool isOperationBtnVisible;
        private Module moduleDto;
        private IModuleManagementBusiness business;
        private List<Module> modules;
        private BindingList<ModuleUserRelDto> relatedUsers;
        private List<ModuleUserRelSearchBoxDto> allUsersSearchBox;
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

        public Module ModuleDto
        {
            get => moduleDto;
            set
            {
                moduleDto = value;
                this.NotifyPropertyChanged();
            }
        }

        public List<Module> Modules
        {
            get => modules;
            private set
            {
                modules = value;
                this.NotifyPropertyChanged();
            }
        }

        public BindingList<ModuleUserRelDto> RelatedUsers
        {
            get => relatedUsers;
            set
            {
                relatedUsers = value;
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

        public List<ModuleUserRelSearchBoxDto> AllUsersSearchBox
        {
            get => allUsersSearchBox;
            set
            {
                allUsersSearchBox = value;
                this.NotifyPropertyChanged();
            }
        }

        public ModuleVM()
        {
            this.isEditingBtnVisible = false;
            this.isOperationBtnVisible = true;
            this.moduleDto = new Module();
            this.business = new ModuleManagementBusiness();
            this.GetModules();
        }

        public void EnableEditingMode(bool isEditing)
        {
            this.IsEditingBtnVisible = isEditing;
            this.IsOperationBtnVisible = !isEditing;
        }

        public void Clean()
        {
            this.EnableEditingMode(false);
            this.ModuleDto = new Module();
            this.GetModules();
        }

        public ObjectResponse<Module> SaveModule()
        {
            moduleDto.RelatedUsers =
                this.RelatedUsers.ToList();
            return this.business.CreateOrUpdateModule(this.moduleDto);
        }

        public void GetModules()
        {
            var result = this.business.GetModule("");
            if (result.IsSucess == true)
            {
                this.Modules = result.ObjectResult;
            }
            else
            {
                this.Modules = new List<Module>();
            }
        }

        public void GetUsers()
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
                    if (this.relatedUsers.Any(ru => ru.ID == item.ID) == true)
                    {
                        item.IsChecked = true;
                    }
                }

                this.AllUsersSearchBox = new List<ModuleUserRelSearchBoxDto>(findUsers);
            }
            else
            {
                this.AllUsersSearchBox = new List<ModuleUserRelSearchBoxDto>();
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
