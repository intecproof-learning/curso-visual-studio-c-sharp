using Finanzas.CursoVisualStudio.Forms.Demo.Common;
using Finanzas.CursoVisualStudio.Shared.DTOs;
using Finanzas.CursoVisualStudio.Shared.Utilities;
using System.ComponentModel;

namespace Finanzas.CursoVisualStudio.Forms.Demo.User
{
    public partial class UserForm : Form
    {
        private UserVM context;
        private SearchDialogBox searchdb;

        public UserForm()
        {
            InitializeComponent();
            this.context = new UserVM();
            this.context.PropertyChanged += Context_PropertyChanged;
            this.context.GetUsers();
            this.searchdb = new SearchDialogBox();
            this.CreateBindings();
        }

        private void Context_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Users")
            {
                this.lstUsers.Items.Clear();

                foreach (var item in this.context.Users)
                {
                    this.lstUsers.Items.Add(new
                        ListViewItem(new string[] {
                            item.ID.ToString(),
                            item.NickName
                        }));
                }
            }

            if (e.PropertyName == "AllModulesSearchBox")
            {
                ((ListBox)this.searchdb.clbRelatedItems).DataSource = this.context.AllModulesSearchBox;
                ((ListBox)this.searchdb.clbRelatedItems).DisplayMember = "Name";
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
            this.gpbUser.DataBindings.Add("Enabled", context, "IsEditingBtnVisible");
            this.txtName.DataBindings.Add("Text", this.context, "UserDto.NickName");
            this.txtDescription.DataBindings.Add("Text", this.context, "UserDto.Email");
            this.lstUsers.DataBindings.Add("Enabled", this.context, "IsOperationBtnVisible");
            this.dgvRelatedModules.DataBindings.Add("DataSource", this.context, "RelatedModules");

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

            this.context.RelatedModules = new BindingList<ModuleUserRelDto>(selectedUsers);
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
                this.context.UserDto = this.context.Users.Where(m => m.ID.ToString() == e.Item.Text).First();
                //this.context.RelatedModules
                //    = new BindingList<Shared.DTOs.ModuleUserRelDto>
                //    (this.context.UserDto.RelatedModules);
            }
            else
            {
                this.context.UserDto = new Shared.DTOs.User();
                this.context.RelatedModules
                    = new BindingList<Shared.DTOs
                    .ModuleUserRelDto>();
            }
        }

        private void btnLinkUser_Click(object sender, EventArgs e)
        {
            this.context.GetRelatedModules();
            this.searchdb.ShowDialog();
        }

        private void SearchDialogBox_BtnSearch_Click(object? sender, EventArgs e)
        {
            this.context.GetRelatedModules();
        }
    }
}