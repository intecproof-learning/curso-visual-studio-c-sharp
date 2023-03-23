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
        }

        private void btnSaveModule_Click(object sender, EventArgs e)
        {
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