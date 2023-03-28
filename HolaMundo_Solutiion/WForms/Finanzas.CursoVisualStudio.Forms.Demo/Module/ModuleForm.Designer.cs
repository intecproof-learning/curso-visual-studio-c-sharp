namespace Finanzas.CursoVisualStudio.Forms.Demo
{
    partial class DemoForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.gpbModuleButtons = new System.Windows.Forms.GroupBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLinkUser = new System.Windows.Forms.Button();
            this.gpbModule = new System.Windows.Forms.GroupBox();
            this.dgvRelatedUsers = new System.Windows.Forms.DataGridView();
            this.lblDescription = new System.Windows.Forms.Label();
            this.gpbModuleList = new System.Windows.Forms.GroupBox();
            this.lstModules = new System.Windows.Forms.ListView();
            this.idColLstModules = new System.Windows.Forms.ColumnHeader();
            this.nameColLstModules = new System.Windows.Forms.ColumnHeader();
            this.gpbModuleButtons.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.gpbModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedUsers)).BeginInit();
            this.gpbModuleList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.163636F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(6, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 19);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(98, 20);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(356, 26);
            this.txtName.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSaveModule_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(98, 52);
            this.txtDescription.MaxLength = 150;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(356, 77);
            this.txtDescription.TabIndex = 3;
            // 
            // gpbModuleButtons
            // 
            this.gpbModuleButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbModuleButtons.Controls.Add(this.flpButtons);
            this.gpbModuleButtons.Font = new System.Drawing.Font("Segoe UI", 9.163636F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gpbModuleButtons.Location = new System.Drawing.Point(12, 362);
            this.gpbModuleButtons.Name = "gpbModuleButtons";
            this.gpbModuleButtons.Size = new System.Drawing.Size(776, 74);
            this.gpbModuleButtons.TabIndex = 4;
            this.gpbModuleButtons.TabStop = false;
            this.gpbModuleButtons.Text = "Acciones";
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnSave);
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnCreate);
            this.flpButtons.Controls.Add(this.btnModify);
            this.flpButtons.Controls.Add(this.btnDelete);
            this.flpButtons.Controls.Add(this.btnLinkUser);
            this.flpButtons.Location = new System.Drawing.Point(6, 25);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(764, 39);
            this.flpButtons.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(109, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FlatAppearance.BorderSize = 4;
            this.btnCreate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnCreate.Location = new System.Drawing.Point(215, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 30);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Nuevo";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnModify
            // 
            this.btnModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModify.Location = new System.Drawing.Point(321, 3);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(100, 30);
            this.btnModify.TabIndex = 4;
            this.btnModify.Text = "Modificar";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(427, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnLinkUser
            // 
            this.btnLinkUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLinkUser.Location = new System.Drawing.Point(533, 3);
            this.btnLinkUser.Name = "btnLinkUser";
            this.btnLinkUser.Size = new System.Drawing.Size(127, 30);
            this.btnLinkUser.TabIndex = 7;
            this.btnLinkUser.Text = "Agregar usuario";
            this.btnLinkUser.UseVisualStyleBackColor = true;
            this.btnLinkUser.Click += new System.EventHandler(this.btnLinkUser_Click);
            // 
            // gpbModule
            // 
            this.gpbModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbModule.Controls.Add(this.dgvRelatedUsers);
            this.gpbModule.Controls.Add(this.lblDescription);
            this.gpbModule.Controls.Add(this.lblName);
            this.gpbModule.Controls.Add(this.txtDescription);
            this.gpbModule.Controls.Add(this.txtName);
            this.gpbModule.Font = new System.Drawing.Font("Segoe UI", 9.163636F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gpbModule.Location = new System.Drawing.Point(12, 12);
            this.gpbModule.Name = "gpbModule";
            this.gpbModule.Size = new System.Drawing.Size(460, 344);
            this.gpbModule.TabIndex = 5;
            this.gpbModule.TabStop = false;
            this.gpbModule.Text = "Propiedades del módulo";
            // 
            // dgvRelatedUsers
            // 
            this.dgvRelatedUsers.AllowUserToAddRows = false;
            this.dgvRelatedUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRelatedUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRelatedUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatedUsers.Location = new System.Drawing.Point(6, 135);
            this.dgvRelatedUsers.MultiSelect = false;
            this.dgvRelatedUsers.Name = "dgvRelatedUsers";
            this.dgvRelatedUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvRelatedUsers.RowTemplate.Height = 28;
            this.dgvRelatedUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelatedUsers.Size = new System.Drawing.Size(448, 203);
            this.dgvRelatedUsers.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.163636F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(5, 54);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(87, 19);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Descripción";
            // 
            // gpbModuleList
            // 
            this.gpbModuleList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbModuleList.Controls.Add(this.lstModules);
            this.gpbModuleList.Font = new System.Drawing.Font("Segoe UI", 9.163636F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gpbModuleList.Location = new System.Drawing.Point(478, 12);
            this.gpbModuleList.Name = "gpbModuleList";
            this.gpbModuleList.Size = new System.Drawing.Size(310, 344);
            this.gpbModuleList.TabIndex = 6;
            this.gpbModuleList.TabStop = false;
            this.gpbModuleList.Text = "Lista de módulos";
            // 
            // lstModules
            // 
            this.lstModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstModules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColLstModules,
            this.nameColLstModules});
            this.lstModules.FullRowSelect = true;
            this.lstModules.Location = new System.Drawing.Point(6, 25);
            this.lstModules.MultiSelect = false;
            this.lstModules.Name = "lstModules";
            this.lstModules.Size = new System.Drawing.Size(298, 313);
            this.lstModules.TabIndex = 0;
            this.lstModules.UseCompatibleStateImageBehavior = false;
            this.lstModules.View = System.Windows.Forms.View.Details;
            this.lstModules.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstModules_ItemSelectionChanged);
            // 
            // idColLstModules
            // 
            this.idColLstModules.Text = "ID";
            this.idColLstModules.Width = 29;
            // 
            // nameColLstModules
            // 
            this.nameColLstModules.Text = "Nombre";
            this.nameColLstModules.Width = 265;
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 445);
            this.Controls.Add(this.gpbModuleList);
            this.Controls.Add(this.gpbModule);
            this.Controls.Add(this.gpbModuleButtons);
            this.Font = new System.Drawing.Font("Segoe UI", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DemoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo";
            this.gpbModuleButtons.ResumeLayout(false);
            this.flpButtons.ResumeLayout(false);
            this.gpbModule.ResumeLayout(false);
            this.gpbModule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedUsers)).EndInit();
            this.gpbModuleList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Button btnSave;
        private TextBox txtDescription;
        private GroupBox gpbModuleButtons;
        private Button btnDelete;
        private Button btnModify;
        private Button btnCreate;
        private Button btnCancel;
        private GroupBox gpbModule;
        private DataGridView dgvRelatedUsers;
        private Label lblDescription;
        private GroupBox gpbModuleList;
        private ListView lstModules;
        private FlowLayoutPanel flpButtons;
        private ColumnHeader idColLstModules;
        private ColumnHeader nameColLstModules;
        private Button btnLinkUser;
    }
}