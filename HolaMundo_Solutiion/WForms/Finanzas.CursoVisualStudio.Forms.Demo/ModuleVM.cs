using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Implementations;
using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces;
using Finanzas.CursoVisualStudio.Shared.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public ModuleVM()
        {
            this.isEditingBtnVisible = false;
            this.isOperationBtnVisible = true;
            this.moduleDto = new Module();
            this.business = new ModuleManagementBusiness();
            this.GetModules();
        }

        public void EnableEditingMode
            (bool isEditing)
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
            return this.business.CreateOrUpdateModule(this.moduleDto);
        }

        public void GetModules()
        {
            var result = this.business
                .GetModule("");
            if (result.IsSucess == true)
            {
                this.Modules = result
                    .ObjectResult;
            }
            else
            {
                this.Modules =
                    new List<Module>();
            }
        }

        private void NotifyPropertyChanged
            ([CallerMemberName]
        String propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this,
                    new PropertyChangedEventArgs
                    (propertyName));
            }
        }
    }
}
