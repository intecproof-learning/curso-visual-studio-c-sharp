using Finanzas.CursoVisualStudio.Forms.Demo.User;
using Finanzas.CursoVisualStudio.Shared.Utilities;

namespace Finanzas.CursoVisualStudio.Forms.Demo
{
    public partial class Finanzas : Form
    {
        private DemoForm modules;
        private UserForm users;

        public Finanzas(String session)
        {
            Utilities.session = session;
            InitializeComponent();
        }

        private void mnsUsersSubItem_Click(object sender, EventArgs e)
        {
            if (this.users == null || this.users.IsDisposed == true)
            {
                this.users = new UserForm();
            }

            this.users.MdiParent = this;
            this.users.WindowState = FormWindowState.Maximized;
            this.users.Show();
        }

        private void mnsModulesSubItem_Click(object sender, EventArgs e)
        {
            if (this.modules == null || this.modules.IsDisposed == true)
            {
                this.modules = new DemoForm();
            }

            this.modules.MdiParent = this;
            this.modules.WindowState = FormWindowState.Maximized;
            this.modules.Show();
        }
    }
}
