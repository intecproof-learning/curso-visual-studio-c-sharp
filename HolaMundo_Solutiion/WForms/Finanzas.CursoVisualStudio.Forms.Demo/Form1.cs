using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Implementations;
using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces;
using System.Windows.Forms;

namespace Finanzas.CursoVisualStudio.Forms.Demo
{
    public partial class DemoForm : Form
    {
        private ModuleVM context;

        public DemoForm()
        {
            InitializeComponent();
            this.context = new ModuleVM();
            this.CreateBindings();
        }

        private void CreateBindings()
        {
            this.btnSave.DataBindings
                .Add("Visible"
                , context
                , "IsEditingBtnVisible");

            this.btnCancel.DataBindings
                .Add("Visible"
                , context
                , "IsEditingBtnVisible");

            this.btnCreate.DataBindings
                .Add("Visible"
                , context
                , "IsOperationBtnVisible");

            this.btnModify.DataBindings
                .Add("Visible"
                , context
                , "IsOperationBtnVisible");

            this.btnDelete.DataBindings
                .Add("Visible"
                , context
                , "IsOperationBtnVisible");

            this.gpbModule.DataBindings
                .Add("Enabled"
                , context
                , "IsEditingBtnVisible");

            this.txtName.DataBindings
                .Add("Text",
                this.context,
                "ModuleDto.Name");

            this.txtDescription.DataBindings
                .Add("Text",
                this.context,
                "ModuleDto.Description");
        }

        private void btnSaveModule_Click(object sender, EventArgs e)
        {
            var result = this.context.SaveModule();

            if (result.IsSucess == true)
            {
                MessageBox.Show(result.Message
                    , "Guardar Módulo"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                this.context.Clean();
            }
            else
            {
                MessageBox.Show($"{result.Message}:\n\n" +
                $"{String.Join("\n", result.Errors.Select(e => e.ErrorMessage))}"
                , "Guardar Módulo"
                , MessageBoxButtons.OK
                , MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.context.EnableEditingMode(true);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            this.context.EnableEditingMode(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.context.EnableEditingMode(false);
        }
    }
}