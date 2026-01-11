namespace khaokaijeow_shop
{
    partial class FormAdminDashboard
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
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.dgvMenu = new System.Windows.Forms.DataGridView();
            this.pnlEditForm = new System.Windows.Forms.Panel();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblMenuStock = new System.Windows.Forms.Label();
            this.lblMenuPrice = new System.Windows.Forms.Label();
            this.lblMenuName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnDeleteMenu = new System.Windows.Forms.Button();
            this.btnSaveMenu = new System.Windows.Forms.Button();
            this.btnAddMenu = new System.Windows.Forms.Button();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.picMenuImage = new System.Windows.Forms.PictureBox();
            this.txtMenuStock = new System.Windows.Forms.TextBox();
            this.txtMenuPrice = new System.Windows.Forms.TextBox();
            this.txtMenuName = new System.Windows.Forms.TextBox();
            this.txtMenuID = new System.Windows.Forms.TextBox();
            this.btnSortStock = new System.Windows.Forms.Button();
            this.pnlAdminHeader = new System.Windows.Forms.Panel();
            this.btnNavSales = new System.Windows.Forms.Button();
            this.btnNavUser = new System.Windows.Forms.Button();
            this.btnNavMenu = new System.Windows.Forms.Button();
            this.pnlSubHeader = new System.Windows.Forms.Panel();
            this.txtSearchAdmin = new System.Windows.Forms.TextBox();
            this.btnFilterLowStock = new System.Windows.Forms.Button();
            this.btnSwitchMenuCustom = new System.Windows.Forms.Button();
            this.btnSwitchMenuSamret = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.lblAddCat = new System.Windows.Forms.Label();
            this.txtNewCategoryName = new System.Windows.Forms.TextBox();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.pnlMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            this.pnlEditForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMenuImage)).BeginInit();
            this.pnlAdminHeader.SuspendLayout();
            this.pnlSubHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMainContent.Controls.Add(this.dgvMenu);
            this.pnlMainContent.Controls.Add(this.pnlEditForm);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(0, 191);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(1570, 668);
            this.pnlMainContent.TabIndex = 3;
            // 
            // dgvMenu
            // 
            this.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMenu.Location = new System.Drawing.Point(0, 0);
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.RowHeadersWidth = 62;
            this.dgvMenu.RowTemplate.Height = 28;
            this.dgvMenu.Size = new System.Drawing.Size(926, 668);
            this.dgvMenu.TabIndex = 0;
            this.dgvMenu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenu_CellClick);
            // 
            // pnlEditForm
            // 
            this.pnlEditForm.BackColor = System.Drawing.Color.PowderBlue;
            this.pnlEditForm.Controls.Add(this.btnAddCategory);
            this.pnlEditForm.Controls.Add(this.txtNewCategoryName);
            this.pnlEditForm.Controls.Add(this.lblAddCat);
            this.pnlEditForm.Controls.Add(this.lblCategory);
            this.pnlEditForm.Controls.Add(this.cmbCategory);
            this.pnlEditForm.Controls.Add(this.lblMenuStock);
            this.pnlEditForm.Controls.Add(this.lblMenuPrice);
            this.pnlEditForm.Controls.Add(this.lblMenuName);
            this.pnlEditForm.Controls.Add(this.lblID);
            this.pnlEditForm.Controls.Add(this.btnDeleteMenu);
            this.pnlEditForm.Controls.Add(this.btnSaveMenu);
            this.pnlEditForm.Controls.Add(this.btnAddMenu);
            this.pnlEditForm.Controls.Add(this.btnSelectImage);
            this.pnlEditForm.Controls.Add(this.picMenuImage);
            this.pnlEditForm.Controls.Add(this.txtMenuStock);
            this.pnlEditForm.Controls.Add(this.txtMenuPrice);
            this.pnlEditForm.Controls.Add(this.txtMenuName);
            this.pnlEditForm.Controls.Add(this.txtMenuID);
            this.pnlEditForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEditForm.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlEditForm.Location = new System.Drawing.Point(926, 0);
            this.pnlEditForm.Name = "pnlEditForm";
            this.pnlEditForm.Size = new System.Drawing.Size(644, 668);
            this.pnlEditForm.TabIndex = 2;
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(33, 364);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(94, 34);
            this.lblCategory.TabIndex = 14;
            this.lblCategory.Text = "หมวดหมู่";
            this.lblCategory.Visible = false;
            // 
            // cmbCategory
            // 
            this.cmbCategory.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(36, 401);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(354, 42);
            this.cmbCategory.TabIndex = 1;
            this.cmbCategory.Visible = false;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblMenuStock
            // 
            this.lblMenuStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMenuStock.AutoSize = true;
            this.lblMenuStock.Location = new System.Drawing.Point(30, 270);
            this.lblMenuStock.Name = "lblMenuStock";
            this.lblMenuStock.Size = new System.Drawing.Size(131, 34);
            this.lblMenuStock.TabIndex = 13;
            this.lblMenuStock.Text = "จำนวนสต็อก";
            // 
            // lblMenuPrice
            // 
            this.lblMenuPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMenuPrice.AutoSize = true;
            this.lblMenuPrice.Location = new System.Drawing.Point(30, 188);
            this.lblMenuPrice.Name = "lblMenuPrice";
            this.lblMenuPrice.Size = new System.Drawing.Size(61, 34);
            this.lblMenuPrice.TabIndex = 12;
            this.lblMenuPrice.Text = "ราคา";
            // 
            // lblMenuName
            // 
            this.lblMenuName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMenuName.AutoSize = true;
            this.lblMenuName.Location = new System.Drawing.Point(30, 106);
            this.lblMenuName.Name = "lblMenuName";
            this.lblMenuName.Size = new System.Drawing.Size(75, 34);
            this.lblMenuName.TabIndex = 11;
            this.lblMenuName.Text = "ชื่อเมนู";
            // 
            // lblID
            // 
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(30, 23);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(110, 34);
            this.lblID.TabIndex = 10;
            this.lblID.Text = "ID สินค้า";
            // 
            // btnDeleteMenu
            // 
            this.btnDeleteMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDeleteMenu.Location = new System.Drawing.Point(432, 602);
            this.btnDeleteMenu.Name = "btnDeleteMenu";
            this.btnDeleteMenu.Size = new System.Drawing.Size(167, 54);
            this.btnDeleteMenu.TabIndex = 9;
            this.btnDeleteMenu.Text = "ลบ";
            this.btnDeleteMenu.UseVisualStyleBackColor = false;
            this.btnDeleteMenu.Click += new System.EventHandler(this.btnDeleteMenu_Click);
            // 
            // btnSaveMenu
            // 
            this.btnSaveMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSaveMenu.Location = new System.Drawing.Point(432, 531);
            this.btnSaveMenu.Name = "btnSaveMenu";
            this.btnSaveMenu.Size = new System.Drawing.Size(167, 54);
            this.btnSaveMenu.TabIndex = 8;
            this.btnSaveMenu.Text = "บันทึก/แก้ไข";
            this.btnSaveMenu.UseVisualStyleBackColor = false;
            this.btnSaveMenu.Click += new System.EventHandler(this.btnSaveMenu_Click);
            // 
            // btnAddMenu
            // 
            this.btnAddMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddMenu.Location = new System.Drawing.Point(432, 457);
            this.btnAddMenu.Name = "btnAddMenu";
            this.btnAddMenu.Size = new System.Drawing.Size(167, 54);
            this.btnAddMenu.TabIndex = 7;
            this.btnAddMenu.Text = "เพิ่ม";
            this.btnAddMenu.UseVisualStyleBackColor = false;
            this.btnAddMenu.Click += new System.EventHandler(this.btnAddMenu_Click);
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectImage.Location = new System.Drawing.Point(486, 329);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(98, 41);
            this.btnSelectImage.TabIndex = 6;
            this.btnSelectImage.Text = "เลือกรูป";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // picMenuImage
            // 
            this.picMenuImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picMenuImage.BackColor = System.Drawing.Color.LightCyan;
            this.picMenuImage.Location = new System.Drawing.Point(423, 23);
            this.picMenuImage.Name = "picMenuImage";
            this.picMenuImage.Size = new System.Drawing.Size(209, 279);
            this.picMenuImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMenuImage.TabIndex = 5;
            this.picMenuImage.TabStop = false;
            // 
            // txtMenuStock
            // 
            this.txtMenuStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMenuStock.Location = new System.Drawing.Point(36, 307);
            this.txtMenuStock.Name = "txtMenuStock";
            this.txtMenuStock.Size = new System.Drawing.Size(354, 42);
            this.txtMenuStock.TabIndex = 3;
            // 
            // txtMenuPrice
            // 
            this.txtMenuPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMenuPrice.Location = new System.Drawing.Point(36, 225);
            this.txtMenuPrice.Name = "txtMenuPrice";
            this.txtMenuPrice.Size = new System.Drawing.Size(354, 42);
            this.txtMenuPrice.TabIndex = 2;
            // 
            // txtMenuName
            // 
            this.txtMenuName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMenuName.Location = new System.Drawing.Point(36, 143);
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.Size = new System.Drawing.Size(354, 42);
            this.txtMenuName.TabIndex = 1;
            // 
            // txtMenuID
            // 
            this.txtMenuID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMenuID.BackColor = System.Drawing.SystemColors.Window;
            this.txtMenuID.Location = new System.Drawing.Point(36, 60);
            this.txtMenuID.Name = "txtMenuID";
            this.txtMenuID.ReadOnly = true;
            this.txtMenuID.Size = new System.Drawing.Size(354, 42);
            this.txtMenuID.TabIndex = 0;
            // 
            // btnSortStock
            // 
            this.btnSortStock.BackColor = System.Drawing.Color.LightCyan;
            this.btnSortStock.Location = new System.Drawing.Point(541, 16);
            this.btnSortStock.Name = "btnSortStock";
            this.btnSortStock.Size = new System.Drawing.Size(187, 54);
            this.btnSortStock.TabIndex = 0;
            this.btnSortStock.Text = "น้อย --> มาก";
            this.btnSortStock.UseVisualStyleBackColor = false;
            this.btnSortStock.Click += new System.EventHandler(this.btnSortStock_Click);
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
            this.pnlAdminHeader.Size = new System.Drawing.Size(1570, 104);
            this.pnlAdminHeader.TabIndex = 1;
            // 
            // btnNavSales
            // 
            this.btnNavSales.BackColor = System.Drawing.Color.LightCyan;
            this.btnNavSales.Location = new System.Drawing.Point(517, 20);
            this.btnNavSales.Name = "btnNavSales";
            this.btnNavSales.Size = new System.Drawing.Size(226, 53);
            this.btnNavSales.TabIndex = 2;
            this.btnNavSales.Text = "รายงานยอดขาย";
            this.btnNavSales.UseVisualStyleBackColor = false;
            this.btnNavSales.Click += new System.EventHandler(this.btnNavSales_Click);
            // 
            // btnNavUser
            // 
            this.btnNavUser.BackColor = System.Drawing.Color.LightCyan;
            this.btnNavUser.Location = new System.Drawing.Point(274, 20);
            this.btnNavUser.Name = "btnNavUser";
            this.btnNavUser.Size = new System.Drawing.Size(226, 53);
            this.btnNavUser.TabIndex = 1;
            this.btnNavUser.Text = "จัดการผู้ใช้";
            this.btnNavUser.UseVisualStyleBackColor = false;
            this.btnNavUser.Click += new System.EventHandler(this.btnNavUser_Click);
            // 
            // btnNavMenu
            // 
            this.btnNavMenu.BackColor = System.Drawing.Color.Cyan;
            this.btnNavMenu.Location = new System.Drawing.Point(27, 20);
            this.btnNavMenu.Name = "btnNavMenu";
            this.btnNavMenu.Size = new System.Drawing.Size(226, 53);
            this.btnNavMenu.TabIndex = 0;
            this.btnNavMenu.Text = "จัดการเมนู";
            this.btnNavMenu.UseVisualStyleBackColor = false;
            // 
            // pnlSubHeader
            // 
            this.pnlSubHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlSubHeader.Controls.Add(this.txtSearchAdmin);
            this.pnlSubHeader.Controls.Add(this.btnSortStock);
            this.pnlSubHeader.Controls.Add(this.btnFilterLowStock);
            this.pnlSubHeader.Controls.Add(this.btnSwitchMenuCustom);
            this.pnlSubHeader.Controls.Add(this.btnSwitchMenuSamret);
            this.pnlSubHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubHeader.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSubHeader.Location = new System.Drawing.Point(0, 104);
            this.pnlSubHeader.Name = "pnlSubHeader";
            this.pnlSubHeader.Size = new System.Drawing.Size(1570, 87);
            this.pnlSubHeader.TabIndex = 2;
            // 
            // txtSearchAdmin
            // 
            this.txtSearchAdmin.BackColor = System.Drawing.Color.LightCyan;
            this.txtSearchAdmin.Location = new System.Drawing.Point(746, 23);
            this.txtSearchAdmin.Name = "txtSearchAdmin";
            this.txtSearchAdmin.Size = new System.Drawing.Size(302, 42);
            this.txtSearchAdmin.TabIndex = 3;
            this.txtSearchAdmin.Text = "ค้นหา";
            this.txtSearchAdmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearchAdmin.TextChanged += new System.EventHandler(this.txtSearchAdmin_TextChanged);
            // 
            // btnFilterLowStock
            // 
            this.btnFilterLowStock.BackColor = System.Drawing.Color.LightCyan;
            this.btnFilterLowStock.Location = new System.Drawing.Point(381, 15);
            this.btnFilterLowStock.Name = "btnFilterLowStock";
            this.btnFilterLowStock.Size = new System.Drawing.Size(144, 55);
            this.btnFilterLowStock.TabIndex = 1;
            this.btnFilterLowStock.Text = "คงเหลือ\r\n";
            this.btnFilterLowStock.UseVisualStyleBackColor = false;
            this.btnFilterLowStock.Click += new System.EventHandler(this.btnFilterLowStock_Click);
            // 
            // btnSwitchMenuCustom
            // 
            this.btnSwitchMenuCustom.BackColor = System.Drawing.Color.LightCyan;
            this.btnSwitchMenuCustom.Location = new System.Drawing.Point(212, 15);
            this.btnSwitchMenuCustom.Name = "btnSwitchMenuCustom";
            this.btnSwitchMenuCustom.Size = new System.Drawing.Size(144, 55);
            this.btnSwitchMenuCustom.TabIndex = 1;
            this.btnSwitchMenuCustom.Text = "วัตถุดิบ";
            this.btnSwitchMenuCustom.UseVisualStyleBackColor = false;
            this.btnSwitchMenuCustom.Click += new System.EventHandler(this.btnSwitchMenuCustom_Click);
            // 
            // btnSwitchMenuSamret
            // 
            this.btnSwitchMenuSamret.BackColor = System.Drawing.Color.LightCyan;
            this.btnSwitchMenuSamret.Location = new System.Drawing.Point(49, 16);
            this.btnSwitchMenuSamret.Name = "btnSwitchMenuSamret";
            this.btnSwitchMenuSamret.Size = new System.Drawing.Size(144, 54);
            this.btnSwitchMenuSamret.TabIndex = 0;
            this.btnSwitchMenuSamret.Text = "เมนู ";
            this.btnSwitchMenuSamret.UseVisualStyleBackColor = false;
            this.btnSwitchMenuSamret.Click += new System.EventHandler(this.btnSwitchMenuSamret_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(0, 0);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersWidth = 62;
            this.dgvUsers.RowTemplate.Height = 28;
            this.dgvUsers.Size = new System.Drawing.Size(1570, 859);
            this.dgvUsers.TabIndex = 5;
            // 
            // lblAddCat
            // 
            this.lblAddCat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddCat.AutoSize = true;
            this.lblAddCat.Location = new System.Drawing.Point(33, 457);
            this.lblAddCat.Name = "lblAddCat";
            this.lblAddCat.Size = new System.Drawing.Size(129, 34);
            this.lblAddCat.TabIndex = 15;
            this.lblAddCat.Text = "เพิ่มหมวดหมู่";
            this.lblAddCat.Visible = false;
            // 
            // txtNewCategoryName
            // 
            this.txtNewCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewCategoryName.Location = new System.Drawing.Point(36, 510);
            this.txtNewCategoryName.Name = "txtNewCategoryName";
            this.txtNewCategoryName.Size = new System.Drawing.Size(354, 42);
            this.txtNewCategoryName.TabIndex = 16;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddCategory.Location = new System.Drawing.Point(36, 577);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(207, 54);
            this.btnAddCategory.TabIndex = 17;
            this.btnAddCategory.Text = "เพิ่มหมวดหมู่";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // FormAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1570, 859);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlSubHeader);
            this.Controls.Add(this.pnlAdminHeader);
            this.Controls.Add(this.dgvUsers);
            this.Name = "FormAdminDashboard";
            this.Text = "FormAdminDashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlMainContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            this.pnlEditForm.ResumeLayout(false);
            this.pnlEditForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMenuImage)).EndInit();
            this.pnlAdminHeader.ResumeLayout(false);
            this.pnlSubHeader.ResumeLayout(false);
            this.pnlSubHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlSubHeader;
        private System.Windows.Forms.Panel pnlAdminHeader;
        private System.Windows.Forms.Button btnNavSales;
        private System.Windows.Forms.Button btnNavUser;
        private System.Windows.Forms.Button btnNavMenu;
        private System.Windows.Forms.Button btnFilterLowStock;
        private System.Windows.Forms.Button btnSwitchMenuCustom;
        private System.Windows.Forms.Button btnSwitchMenuSamret;
        private System.Windows.Forms.Panel pnlEditForm;
        private System.Windows.Forms.Button btnSortStock;
        private System.Windows.Forms.Label lblMenuStock;
        private System.Windows.Forms.Label lblMenuPrice;
        private System.Windows.Forms.Label lblMenuName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnDeleteMenu;
        private System.Windows.Forms.Button btnSaveMenu;
        private System.Windows.Forms.Button btnAddMenu;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.PictureBox picMenuImage;
        private System.Windows.Forms.TextBox txtMenuStock;
        private System.Windows.Forms.TextBox txtMenuPrice;
        private System.Windows.Forms.TextBox txtMenuName;
        private System.Windows.Forms.TextBox txtMenuID;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvMenu;
        private System.Windows.Forms.TextBox txtSearchAdmin;
        private System.Windows.Forms.Label lblAddCat;
        private System.Windows.Forms.TextBox txtNewCategoryName;
        private System.Windows.Forms.Button btnAddCategory;
    }
}