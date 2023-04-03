namespace Finanzas.CursoVisualStudio.Forms.Demo
{
    partial class Finanzas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnsMainMenu = new System.Windows.Forms.MenuStrip();
            this.mnsManagementItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsUsersSubItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsModulesSubItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMainMenu
            // 
            this.mnsMainMenu.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.mnsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsManagementItem});
            this.mnsMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMainMenu.Name = "mnsMainMenu";
            this.mnsMainMenu.Size = new System.Drawing.Size(832, 27);
            this.mnsMainMenu.TabIndex = 1;
            this.mnsMainMenu.Text = "menuStrip1";
            // 
            // mnsManagementItem
            // 
            this.mnsManagementItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsUsersSubItem,
            this.mnsModulesSubItem});
            this.mnsManagementItem.Name = "mnsManagementItem";
            this.mnsManagementItem.Size = new System.Drawing.Size(114, 23);
            this.mnsManagementItem.Text = "Administración";
            // 
            // mnsUsersSubItem
            // 
            this.mnsUsersSubItem.Name = "mnsUsersSubItem";
            this.mnsUsersSubItem.Size = new System.Drawing.Size(206, 24);
            this.mnsUsersSubItem.Text = "Usuarios";
            this.mnsUsersSubItem.Click += new System.EventHandler(this.mnsUsersSubItem_Click);
            // 
            // mnsModulesSubItem
            // 
            this.mnsModulesSubItem.Name = "mnsModulesSubItem";
            this.mnsModulesSubItem.Size = new System.Drawing.Size(206, 24);
            this.mnsModulesSubItem.Text = "Módulos";
            this.mnsModulesSubItem.Click += new System.EventHandler(this.mnsModulesSubItem_Click);
            // 
            // Finanzas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 456);
            this.Controls.Add(this.mnsMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsMainMenu;
            this.MaximizeBox = false;
            this.Name = "Finanzas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finanzas";
            this.mnsMainMenu.ResumeLayout(false);
            this.mnsMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip mnsMainMenu;
        private ToolStripMenuItem mnsManagementItem;
        private ToolStripMenuItem mnsUsersSubItem;
        private ToolStripMenuItem mnsModulesSubItem;
    }
}