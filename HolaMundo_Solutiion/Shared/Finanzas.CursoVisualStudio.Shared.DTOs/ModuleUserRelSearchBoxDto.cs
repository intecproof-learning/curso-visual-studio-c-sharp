using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.CursoVisualStudio.Shared.DTOs
{
    public class ModuleUserRelSearchBoxDto : ModuleUserRelDto, INotifyPropertyChanged
    {
        private Boolean isChecked;

        public bool IsChecked
        {
            get => isChecked;
            set
            {
                isChecked = value;
                this.NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}