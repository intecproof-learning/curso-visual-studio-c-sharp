using Finanzas.CursoVisualStudio.Shared.Utilities;

namespace Finanzas.CursoVisualStudio.Forms.Demo
{
    public partial class Finanzas : Form
    {
        private DemoForm modules;
        private DemoForm users;

        public Finanzas(String session)
        {
            Utilities.session = session;
            InitializeComponent();

            this.modules = new DemoForm();
            this.users = new DemoForm();
        }

        private void mnsUsersSubItem_Click(object sender, EventArgs e)
        {
            if (this.users.IsDisposed == true)
            {
                this.users = new DemoForm();
            }

            this.users.MdiParent = this;
            this.users.WindowState = FormWindowState.Maximized;
            this.users.Show();
        }

        private void mnsModulesSubItem_Click(object sender, EventArgs e)
        {
            if (this.modules.IsDisposed == true)
            {
                this.modules = new DemoForm();
            }

            this.modules.MdiParent = this;
            this.modules.WindowState = FormWindowState.Maximized;
            this.modules.Show();
        }
    }
}
