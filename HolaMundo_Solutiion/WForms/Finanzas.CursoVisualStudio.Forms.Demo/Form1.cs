using System.ComponentModel;

namespace Finanzas.CursoVisualStudio.Forms.Demo
{
    public partial class DemoForm : Form
    {
        private ModuleVM context;

        public DemoForm()
        {
            InitializeComponent();
            this.context = new ModuleVM();
            this.context.PropertyChanged += Context_PropertyChanged;
            this.context.GetModules();
            this.CreateBindings();
        }

        private void Context_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Modules")
            {
                this.lstModules.Items.Clear();

                foreach (var item in this.context.Modules)
                {
                    this.lstModules.Items.Add(new
                        ListViewItem(new string[] {
                            item.ID.ToString(),
                            item.Name
                        }));
                }
            }
        }

        private void CreateBindings()
        {
            this.btnSave.DataBindings.Add("Visible", context, "IsEditingBtnVisible");
            this.btnCancel.DataBindings.Add("Visible", context, "IsEditingBtnVisible");
            this.btnCreate.DataBindings.Add("Visible", context, "IsOperationBtnVisible");
            this.btnModify.DataBindings.Add("Visible", context, "IsOperationBtnVisible");
            this.btnDelete.DataBindings.Add("Visible", context, "IsOperationBtnVisible");
            this.gpbModule.DataBindings.Add("Enabled", context, "IsEditingBtnVisible");
            this.txtName.DataBindings.Add("Text", this.context, "ModuleDto.Name");
            this.txtDescription.DataBindings.Add("Text", this.context, "ModuleDto.Description");
            this.lstModules.DataBindings.Add("Enabled", this.context, "IsOperationBtnVisible");
            this.dgvRelatedUsers.DataBindings
                .Add("DataSource"
                , this.context
                , "RelatedUsers");
        }

        private void btnSaveModule_Click(object sender, EventArgs e)
        {
            var result = this.context.SaveModule();

            if (result.IsSucess == true)
            {
                MessageBox.Show(result.Message, "Guardar Módulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.context.Clean();
            }
            else
            {
                MessageBox.Show($"{result.Message}:\n\n" + $"{String.Join("\n", result.Errors.Select(e => e.ErrorMessage))}", "Guardar Módulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.context.Clean();
            this.context.EnableEditingMode(true);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            this.context.EnableEditingMode(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea cancelar la operación?", "Cancelar operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.context.Clean();
            }

        }

        private void lstModules_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected == true)
            {
                this.context.ModuleDto = this.context.Modules.Where(m => m.ID.ToString() == e.Item.Text).First();
                this.context.RelatedUsers
                    = new BindingList<Shared.DTOs.ModuleUserRelDto>
                    (this.context.ModuleDto.RelatedUsers);
            }
            else
            {
                this.context.ModuleDto = new Shared.DTOs.Module();
                this.context.RelatedUsers
                    = new BindingList<Shared.DTOs
                    .ModuleUserRelDto>();
            }
        }
    }
}