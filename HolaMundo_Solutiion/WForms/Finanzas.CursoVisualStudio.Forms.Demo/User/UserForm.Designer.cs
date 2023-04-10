namespace Finanzas.CursoVisualStudio.Forms.Demo.User
{
    partial class UserForm
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
            this.lblNickName = new System.Windows.Forms.Label();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.gpbUserButtons = new System.Windows.Forms.GroupBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLinkUser = new System.Windows.Forms.Button();
            this.gpbUser = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.dgvRelatedModules = new System.Windows.Forms.DataGridView();
            this.lblEmail = new System.Windows.Forms.Label();
            this.gpbUserList = new System.Windows.Forms.GroupBox();
            this.lstUsers = new System.Windows.Forms.ListView();
            this.idColLstUsers = new System.Windows.Forms.ColumnHeader();
            this.nickNameColLstUsers = new System.Windows.Forms.ColumnHeader();
            this.gpbUserButtons.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.gpbUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedModules)).BeginInit();
            this.gpbUserList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNickName
            // 
            this.lblNickName.AutoSize = true;
            this.lblNickName.Font = new System.Drawing.Font("Segoe UI", 9.163636F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNickName.Location = new System.Drawing.Point(6, 22);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(55, 19);
            this.lblNickName.TabIndex = 0;
            this.lblNickName.Text = "Apodo";
            // 
            // txtNickName
            // 
            this.txtNickName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNickName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNickName.Location = new System.Drawing.Point(96, 20);
            this.txtNickName.MaxLength = 12;
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(358, 26);
            this.txtNickName.TabIndex = 1;
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
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(96, 59);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmail.Size = new System.Drawing.Size(358, 26);
            this.txtEmail.TabIndex = 3;
            // 
            // gpbUserButtons
            // 
            this.gpbUserButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbUserButtons.Controls.Add(this.flpButtons);
            this.gpbUserButtons.Font = new System.Drawing.Font("Segoe UI", 9.163636F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gpbUserButtons.Location = new System.Drawing.Point(12, 362);
            this.gpbUserButtons.Name = "gpbUserButtons";
            this.gpbUserButtons.Size = new System.Drawing.Size(776, 74);
            this.gpbUserButtons.TabIndex = 4;
            this.gpbUserButtons.TabStop = false;
            this.gpbUserButtons.Text = "Acciones";
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
            // gpbUser
            // 
            this.gpbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbUser.Controls.Add(this.txtPassword);
            this.gpbUser.Controls.Add(this.lblPassword);
            this.gpbUser.Controls.Add(this.dgvRelatedModules);
            this.gpbUser.Controls.Add(this.lblEmail);
            this.gpbUser.Controls.Add(this.lblNickName);
            this.gpbUser.Controls.Add(this.txtEmail);
            this.gpbUser.Controls.Add(this.txtNickName);
            this.gpbUser.Font = new System.Drawing.Font("Segoe UI", 9.163636F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gpbUser.Location = new System.Drawing.Point(12, 12);
            this.gpbUser.Name = "gpbUser";
            this.gpbUser.Size = new System.Drawing.Size(460, 344);
            this.gpbUser.TabIndex = 5;
            this.gpbUser.TabStop = false;
            this.gpbUser.Text = "Propiedades del usuario";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(96, 97);
            this.txtPassword.MaxLength = 16;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPassword.Size = new System.Drawing.Size(358, 26);
            this.txtPassword.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.163636F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.Location = new System.Drawing.Point(6, 99);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(84, 19);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Contraseña";
            // 
            // dgvRelatedModules
            // 
            this.dgvRelatedModules.AllowUserToAddRows = false;
            this.dgvRelatedModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRelatedModules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRelatedModules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatedModules.Location = new System.Drawing.Point(6, 135);
            this.dgvRelatedModules.MultiSelect = false;
            this.dgvRelatedModules.Name = "dgvRelatedModules";
            this.dgvRelatedModules.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvRelatedModules.RowTemplate.Height = 28;
            this.dgvRelatedModules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelatedModules.Size = new System.Drawing.Size(448, 203);
            this.dgvRelatedModules.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.163636F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEmail.Location = new System.Drawing.Point(6, 50);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(84, 38);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Correo\r\nelectrónico";
            // 
            // gpbUserList
            // 
            this.gpbUserList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbUserList.Controls.Add(this.lstUsers);
            this.gpbUserList.Font = new System.Drawing.Font("Segoe UI", 9.163636F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gpbUserList.Location = new System.Drawing.Point(478, 12);
            this.gpbUserList.Name = "gpbUserList";
            this.gpbUserList.Size = new System.Drawing.Size(310, 344);
            this.gpbUserList.TabIndex = 6;
            this.gpbUserList.TabStop = false;
            this.gpbUserList.Text = "Lista de usuarios";
            // 
            // lstUsers
            // 
            this.lstUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColLstUsers,
            this.nickNameColLstUsers});
            this.lstUsers.FullRowSelect = true;
            this.lstUsers.Location = new System.Drawing.Point(6, 25);
            this.lstUsers.MultiSelect = false;
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(298, 313);
            this.lstUsers.TabIndex = 0;
            this.lstUsers.UseCompatibleStateImageBehavior = false;
            this.lstUsers.View = System.Windows.Forms.View.Details;
            this.lstUsers.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstModules_ItemSelectionChanged);
            // 
            // idColLstUsers
            // 
            this.idColLstUsers.Text = "ID";
            this.idColLstUsers.Width = 29;
            // 
            // nickNameColLstUsers
            // 
            this.nickNameColLstUsers.Text = "Apodo";
            this.nickNameColLstUsers.Width = 265;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 445);
            this.Controls.Add(this.gpbUserList);
            this.Controls.Add(this.gpbUser);
            this.Controls.Add(this.gpbUserButtons);
            this.Font = new System.Drawing.Font("Segoe UI", 9.163636F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de usuarios";
            this.gpbUserButtons.ResumeLayout(false);
            this.flpButtons.ResumeLayout(false);
            this.gpbUser.ResumeLayout(false);
            this.gpbUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatedModules)).EndInit();
            this.gpbUserList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblNickName;
        private TextBox txtNickName;
        private Button btnSave;
        private TextBox txtEmail;
        private GroupBox gpbUserButtons;
        private Button btnDelete;
        private Button btnModify;
        private Button btnCreate;
        private Button btnCancel;
        private GroupBox gpbUser;
        private DataGridView dgvRelatedModules;
        private Label lblEmail;
        private GroupBox gpbUserList;
        private ListView lstUsers;
        private FlowLayoutPanel flpButtons;
        private ColumnHeader idColLstUsers;
        private ColumnHeader nickNameColLstUsers;
        private Button btnLinkUser;
        private TextBox txtPassword;
        private Label lblPassword;
    }
}