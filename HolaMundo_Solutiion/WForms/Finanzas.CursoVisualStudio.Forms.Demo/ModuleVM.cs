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

        public ModuleVM()
        {
            this.isEditingBtnVisible = false;
            this.isOperationBtnVisible = true;
        }

        public void EnableEditingMode
            (bool isEditing)
        {
            this.IsEditingBtnVisible = isEditing;
            this.IsOperationBtnVisible = !isEditing;
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
