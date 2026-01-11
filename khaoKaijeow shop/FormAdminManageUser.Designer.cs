namespace khaokaijeow_shop
{
    partial class FormAdminManageUser
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
            this.pnlSubHeader = new System.Windows.Forms.Panel();
            this.txtSearchAdmin = new System.Windows.Forms.TextBox();
            this.pnlAdminHeader = new System.Windows.Forms.Panel();
            this.btnNavSales = new System.Windows.Forms.Button();
            this.btnNavUser = new System.Windows.Forms.Button();
            this.btnNavMenu = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblUserEmail = new System.Windows.Forms.Label();
            this.txtUserEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.cmbUserRole = new System.Windows.Forms.ComboBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.picUserImage = new System.Windows.Forms.PictureBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.pnlSubHeader.SuspendLayout();
            this.pnlAdminHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSubHeader
            // 
            this.pnlSubHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlSubHeader.Controls.Add(this.txtSearchAdmin);
            this.pnlSubHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubHeader.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSubHeader.Location = new System.Drawing.Point(0, 104);
            this.pnlSubHeader.Name = "pnlSubHeader";
            this.pnlSubHeader.Size = new System.Drawing.Size(1590, 87);
            this.pnlSubHeader.TabIndex = 7;
            // 
            // txtSearchAdmin
            // 
            this.txtSearchAdmin.BackColor = System.Drawing.Color.LightCyan;
            this.txtSearchAdmin.Location = new System.Drawing.Point(27, 18);
            this.txtSearchAdmin.Name = "txtSearchAdmin";
            this.txtSearchAdmin.Size = new System.Drawing.Size(302, 42);
            this.txtSearchAdmin.TabIndex = 2;
            this.txtSearchAdmin.Text = "ค้นหา";
            this.txtSearchAdmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearchAdmin.TextChanged += new System.EventHandler(this.txtSearchAdmin_TextChanged);
            // 
            // pnlAdminHeader
            // 
            this.pnlAdminHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlAdminHeader.Controls.Add(this.btnNavSales);
            this.pnlAdminHeader.Controls.Add(this.btnNavUser);
            this.pnlAdminHeader.Controls.Add(this.btnNavMenu);
            this.pnlAdminHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAdminHeader.Font = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlAdminHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlAdminHeader.Name = "pnlAdminHeader";
            this.pnlAdminHeader.Size = new System.Drawing.Size(1590, 104);
            this.pnlAdminHeader.TabIndex = 6;
            // 
            // btnNavSales
            // 
            this.btnNavSales.BackColor = System.Drawing.Color.LightCyan;
            this.btnNavSales.Location = new System.Drawing.Point(517, 20);
            this.btnNavSales.Name = "btnNavSales";
            this.btnNavSales.Size = new System.Drawing.Size(388, 53);
            this.btnNavSales.TabIndex = 2;
            this.btnNavSales.Text = "รายการผลการขาย";
            this.btnNavSales.UseVisualStyleBackColor = false;
            this.btnNavSales.Click += new System.EventHandler(this.btnNavSales_Click);
            // 
            // btnNavUser
            // 
            this.btnNavUser.BackColor = System.Drawing.Color.Cyan;
            this.btnNavUser.Location = new System.Drawing.Point(274, 20);
            this.btnNavUser.Name = "btnNavUser";
            this.btnNavUser.Size = new System.Drawing.Size(226, 53);
            this.btnNavUser.TabIndex = 1;
            this.btnNavUser.Text = "จัดการผู้ใช้";
            this.btnNavUser.UseVisualStyleBackColor = false;
            // 
            // btnNavMenu
            // 
            this.btnNavMenu.BackColor = System.Drawing.Color.LightCyan;
            this.btnNavMenu.Location = new System.Drawing.Point(27, 20);
            this.btnNavMenu.Name = "btnNavMenu";
            this.btnNavMenu.Size = new System.Drawing.Size(226, 53);
            this.btnNavMenu.TabIndex = 0;
            this.btnNavMenu.Text = "จัดการเมนู";
            this.btnNavMenu.UseVisualStyleBackColor = false;
            this.btnNavMenu.Click += new System.EventHandler(this.btnNavMenu_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(0, 191);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersWidth = 62;
            this.dgvUsers.RowTemplate.Height = 28;
            this.dgvUsers.Size = new System.Drawing.Size(984, 805);
            this.dgvUsers.TabIndex = 8;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.PapayaWhip;
            this.panel1.Controls.Add(this.btnSelectImage);
            this.panel1.Controls.Add(this.picUserImage);
            this.panel1.Controls.Add(this.lblLastName);
            this.panel1.Controls.Add(this.txtLastName);
            this.panel1.Controls.Add(this.lblFirstName);
            this.panel1.Controls.Add(this.txtFirstName);
            this.panel1.Controls.Add(this.lblUserEmail);
            this.panel1.Controls.Add(this.txtUserEmail);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtUserID);
            this.panel1.Controls.Add(this.lblUserRole);
            this.panel1.Controls.Add(this.lblNewPassword);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.btnDeleteUser);
            this.panel1.Controls.Add(this.btnSaveUser);
            this.panel1.Controls.Add(this.cmbUserRole);
            this.panel1.Controls.Add(this.txtNewPassword);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(984, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 805);
            this.panel1.TabIndex = 30;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(51, 476);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(93, 34);
            this.lblLastName.TabIndex = 40;
            this.lblLastName.Text = "นามสกุล";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(48, 513);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(332, 37);
            this.txtLastName.TabIndex = 39;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(51, 399);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(73, 34);
            this.lblFirstName.TabIndex = 38;
            this.lblFirstName.Text = "ชื่อจริง";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(48, 436);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(332, 37);
            this.txtFirstName.TabIndex = 37;
            // 
            // lblUserEmail
            // 
            this.lblUserEmail.AutoSize = true;
            this.lblUserEmail.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserEmail.Location = new System.Drawing.Point(51, 553);
            this.lblUserEmail.Name = "lblUserEmail";
            this.lblUserEmail.Size = new System.Drawing.Size(60, 34);
            this.lblUserEmail.TabIndex = 36;
            this.lblUserEmail.Text = "อีเมล";
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserEmail.Location = new System.Drawing.Point(48, 590);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.Size = new System.Drawing.Size(332, 37);
            this.txtUserEmail.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(543, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 34);
            this.label2.TabIndex = 34;
            this.label2.Text = "ID";
            this.label2.Visible = false;
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(414, 359);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(180, 37);
            this.txtUserID.TabIndex = 33;
            this.txtUserID.Visible = false;
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserRole.Location = new System.Drawing.Point(51, 630);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(116, 34);
            this.lblUserRole.TabIndex = 32;
            this.lblUserRole.Text = "สถานะภาพ";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.Location = new System.Drawing.Point(51, 707);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(52, 34);
            this.lblNewPassword.TabIndex = 31;
            this.lblNewPassword.Text = "รหัส\r\n";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(51, 322);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(42, 34);
            this.lblUserName.TabIndex = 30;
            this.lblUserName.Text = "ชื่อ\r\n";
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDeleteUser.Location = new System.Drawing.Point(452, 732);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(139, 61);
            this.btnDeleteUser.TabIndex = 29;
            this.btnDeleteUser.Text = "ลบ";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSaveUser.Location = new System.Drawing.Point(452, 648);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(139, 61);
            this.btnSaveUser.TabIndex = 28;
            this.btnSaveUser.Text = "บันทึก";
            this.btnSaveUser.UseVisualStyleBackColor = false;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // cmbUserRole
            // 
            this.cmbUserRole.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbUserRole.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserRole.FormattingEnabled = true;
            this.cmbUserRole.Location = new System.Drawing.Point(48, 667);
            this.cmbUserRole.Name = "cmbUserRole";
            this.cmbUserRole.Size = new System.Drawing.Size(332, 37);
            this.cmbUserRole.TabIndex = 27;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.Location = new System.Drawing.Point(48, 744);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(336, 37);
            this.txtNewPassword.TabIndex = 26;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(48, 359);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(333, 37);
            this.txtUserName.TabIndex = 25;
            // 
            // picUserImage
            // 
            this.picUserImage.Location = new System.Drawing.Point(48, 28);
            this.picUserImage.Name = "picUserImage";
            this.picUserImage.Size = new System.Drawing.Size(268, 278);
            this.picUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUserImage.TabIndex = 41;
            this.picUserImage.TabStop = false;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSelectImage.Location = new System.Drawing.Point(357, 259);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(139, 47);
            this.btnSelectImage.TabIndex = 42;
            this.btnSelectImage.Text = "บันทึกรูป";
            this.btnSelectImage.UseVisualStyleBackColor = false;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // FormAdminManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1590, 996);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlSubHeader);
            this.Controls.Add(this.pnlAdminHeader);
            this.Name = "FormAdminManageUser";
            this.Text = "FormAdminManageUser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSubHeader.ResumeLayout(false);
            this.pnlSubHeader.PerformLayout();
            this.pnlAdminHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSubHeader;
        private System.Windows.Forms.TextBox txtSearchAdmin;
        private System.Windows.Forms.Panel pnlAdminHeader;
        private System.Windows.Forms.Button btnNavSales;
        private System.Windows.Forms.Button btnNavUser;
        private System.Windows.Forms.Button btnNavMenu;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.ComboBox cmbUserRole;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblUserEmail;
        private System.Windows.Forms.TextBox txtUserEmail;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.PictureBox picUserImage;
    }
}