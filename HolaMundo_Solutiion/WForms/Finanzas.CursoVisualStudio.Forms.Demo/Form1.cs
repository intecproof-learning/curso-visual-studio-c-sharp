using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Implementations;
using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces;

namespace Finanzas.CursoVisualStudio.Forms.Demo
{
    public partial class DemoForm : Form
    {
        int counter = 0;
        public DemoForm()
        {
            InitializeComponent();
        }

        private void btnSaveModule_Click(object sender, EventArgs e)
        {
            IModuleManagementBusiness business =
                new ModuleManagementBusiness();

            business.CreateOrUpdateModule(
                new Shared.DTOs.Module()
                {
                    Description = txtDescription.Text,
                    Name = txtName.Text
                });
        }
    }
}