using Finanzas.CursoVisualStudio.Forms.Demo.Common;
using Finanzas.CursoVisualStudio.Shared.DTOs;
using Finanzas.CursoVisualStudio.Shared.Utilities;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Finanzas.CursoVisualStudio.Forms.Demo
{
    public partial class DemoForm : Form
    {
        private ModuleVM context;
        private SearchDialogBox searchdb;

        public DemoForm()
        {
            String prevState = String.Empty;
            if (File.Exists("C:\\Temp\\ModuleState.json") == true)
            {
                DialogResult result = MessageBox.Show("Existe un estado previo. ¿Deseas recuperarlo?"
                    , "Recuperar estado previo"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (StreamReader sr = new StreamReader("C:\\Temp\\ModuleState.json"))
                    {
                        prevState = sr.ReadToEnd();
                    }
                    File.Delete("C:\\Temp\\ModuleState.json");
                }
            }
            InitializeComponent();

            if (String.IsNullOrEmpty(prevState) == true)
            {
                this.context = new ModuleVM();
            }
            else
            {
                ModuleVM instanciaEstadoPrevio = JsonConvert
             .DeserializeObject<ModuleVM>(prevState);
                this.context = instanciaEstadoPrevio;
            }

            this.context.PropertyChanged += Context_PropertyChanged;
            this.context.GetModules();
            this.searchdb = new SearchDialogBox();
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

            if (e.PropertyName == "AllUsersSearchBox")
            {
                ((ListBox)this.searchdb.clbRelatedItems).DataSource = this.context.AllUsersSearchBox;
                ((ListBox)this.searchdb.clbRelatedItems).DisplayMember = "NickName";
                ((ListBox)this.searchdb.clbRelatedItems).ValueMember = "ID";

                for (int i = 0; i < this.searchdb.clbRelatedItems.Items.Count; i++)
                {
                    this.searchdb.clbRelatedItems.SetItemChecked(i, (this.searchdb.clbRelatedItems.Items[i] as ModuleUserRelSearchBoxDto).IsChecked);
                }
            }
        }

        private void CreateBindings()
        {
            this.btnSave.DataBindings.Add("Visible", context, "IsEditingBtnVisible");
            this.btnCancel.DataBindings.Add("Visible", context, "IsEditingBtnVisible");
            this.btnLinkUser.DataBindings.Add("Visible", context, "IsEditingBtnVisible");
            this.btnCreate.DataBindings.Add("Visible", context, "IsOperationBtnVisible");
            this.btnModify.DataBindings.Add("Visible", context, "IsOperationBtnVisible");
            this.btnDelete.DataBindings.Add("Visible", context, "IsOperationBtnVisible");
            this.gpbModule.DataBindings.Add("Enabled", context, "IsEditingBtnVisible");
            this.txtName.DataBindings.Add("Text", this.context, "ModuleDto.Name");
            this.txtDescription.DataBindings.Add("Text", this.context, "ModuleDto.Description");
            this.lstModules.DataBindings.Add("Enabled", this.context, "IsOperationBtnVisible");
            this.dgvRelatedUsers.DataBindings.Add("DataSource", this.context, "RelatedUsers");

            #region SearchDialogBox
            this.searchdb.btnSearch.Click += SearchDialogBox_BtnSearch_Click;
            this.searchdb.txtFilter.DataBindings.Add("Text", this.context, "SearchDialogBoxFilter");
            this.searchdb.btnAceptar.Click += SearchDialogBox_BtnAceptar;
            #endregion
        }

        private void SearchDialogBox_BtnAceptar(object? sender, EventArgs e)
        {
            List<ModuleUserRelDto> selectedUsers = new List<ModuleUserRelDto>();
            foreach (var item in this.searchdb.clbRelatedItems.CheckedItems)
            {
                selectedUsers.Add((item as ModuleUserRelDto));
            }

            this.context.RelatedUsers = new BindingList<ModuleUserRelDto>(selectedUsers);
            this.searchdb.Close();
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

        private void btnLinkUser_Click(object sender, EventArgs e)
        {
            this.context.GetUsers();
            this.searchdb.ShowDialog();
        }

        private void SearchDialogBox_BtnSearch_Click(object? sender, EventArgs e)
        {
            this.context.GetUsers();
        }
    }
}