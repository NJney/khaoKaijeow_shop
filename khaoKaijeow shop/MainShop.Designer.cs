namespace khaokaijeow_shop
{
    partial class MainShop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainShop));
            this.flpMenuContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlheadline = new System.Windows.Forms.Panel();
            this.lblnameshop = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.picBanner = new System.Windows.Forms.PictureBox();
            this.picOrderHistory = new System.Windows.Forms.PictureBox();
            this.btnCustomMenu = new System.Windows.Forms.Button();
            this.btnMenuSamret = new System.Windows.Forms.Button();
            this.picCart = new System.Windows.Forms.PictureBox();
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnUserProfile = new System.Windows.Forms.PictureBox();
            this.pnlheadline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOrderHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUserProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // flpMenuContainer
            // 
            this.flpMenuContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenuContainer.Location = new System.Drawing.Point(0, 405);
            this.flpMenuContainer.Name = "flpMenuContainer";
            this.flpMenuContainer.Size = new System.Drawing.Size(1515, 439);
            this.flpMenuContainer.TabIndex = 2;
            // 
            // pnlheadline
            // 
            this.pnlheadline.BackColor = System.Drawing.Color.SaddleBrown;
            this.pnlheadline.Controls.Add(this.btnUserProfile);
            this.pnlheadline.Controls.Add(this.picOrderHistory);
            this.pnlheadline.Controls.Add(this.lblnameshop);
            this.pnlheadline.Controls.Add(this.btnCustomMenu);
            this.pnlheadline.Controls.Add(this.btnMenuSamret);
            this.pnlheadline.Controls.Add(this.picCart);
            this.pnlheadline.Controls.Add(this.picLogin);
            this.pnlheadline.Controls.Add(this.txtSearch);
            this.pnlheadline.Controls.Add(this.picLogo);
            this.pnlheadline.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlheadline.Location = new System.Drawing.Point(0, 0);
            this.pnlheadline.Name = "pnlheadline";
            this.pnlheadline.Size = new System.Drawing.Size(1515, 146);
            this.pnlheadline.TabIndex = 0;
            // 
            // lblnameshop
            // 
            this.lblnameshop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblnameshop.AutoSize = true;
            this.lblnameshop.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnameshop.ForeColor = System.Drawing.Color.White;
            this.lblnameshop.Location = new System.Drawing.Point(529, 95);
            this.lblnameshop.Name = "lblnameshop";
            this.lblnameshop.Size = new System.Drawing.Size(418, 48);
            this.lblnameshop.TabIndex = 7;
            this.lblnameshop.Text = "khaokaijeow ข้าวไข่เจียว";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("TH Sarabun New", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSearch.Location = new System.Drawing.Point(812, 52);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(319, 55);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // picBanner
            // 
            this.picBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.picBanner.Image = ((System.Drawing.Image)(resources.GetObject("picBanner.Image")));
            this.picBanner.Location = new System.Drawing.Point(0, 146);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(1515, 259);
            this.picBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBanner.TabIndex = 1;
            this.picBanner.TabStop = false;
            // 
            // picOrderHistory
            // 
            this.picOrderHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picOrderHistory.Image = ((System.Drawing.Image)(resources.GetObject("picOrderHistory.Image")));
            this.picOrderHistory.Location = new System.Drawing.Point(1417, 53);
            this.picOrderHistory.Name = "picOrderHistory";
            this.picOrderHistory.Size = new System.Drawing.Size(68, 54);
            this.picOrderHistory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOrderHistory.TabIndex = 8;
            this.picOrderHistory.TabStop = false;
            this.picOrderHistory.Click += new System.EventHandler(this.picOrderHistory_Click);
            // 
            // btnCustomMenu
            // 
            this.btnCustomMenu.AutoSize = true;
            this.btnCustomMenu.BackgroundImage = global::khaokaijeow_shop.Properties.Resources.backgrond;
            this.btnCustomMenu.Font = new System.Drawing.Font("TH Sarabun New", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCustomMenu.ForeColor = System.Drawing.Color.White;
            this.btnCustomMenu.Location = new System.Drawing.Point(219, 19);
            this.btnCustomMenu.Name = "btnCustomMenu";
            this.btnCustomMenu.Size = new System.Drawing.Size(217, 98);
            this.btnCustomMenu.TabIndex = 6;
            this.btnCustomMenu.Text = "เลือกวัตถุดิบเอง";
            this.btnCustomMenu.UseVisualStyleBackColor = true;
            this.btnCustomMenu.Click += new System.EventHandler(this.btnCustomMenu_Click);
            // 
            // btnMenuSamret
            // 
            this.btnMenuSamret.AutoSize = true;
            this.btnMenuSamret.BackgroundImage = global::khaokaijeow_shop.Properties.Resources.backgrond;
            this.btnMenuSamret.Font = new System.Drawing.Font("TH Sarabun New", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnMenuSamret.ForeColor = System.Drawing.Color.White;
            this.btnMenuSamret.Location = new System.Drawing.Point(26, 19);
            this.btnMenuSamret.Name = "btnMenuSamret";
            this.btnMenuSamret.Size = new System.Drawing.Size(170, 98);
            this.btnMenuSamret.TabIndex = 5;
            this.btnMenuSamret.Text = "เมนูสำเร็จ";
            this.btnMenuSamret.UseVisualStyleBackColor = true;
            this.btnMenuSamret.Click += new System.EventHandler(this.btnMenuSamret_Click);
            // 
            // picCart
            // 
            this.picCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picCart.Image = ((System.Drawing.Image)(resources.GetObject("picCart.Image")));
            this.picCart.Location = new System.Drawing.Point(1325, 53);
            this.picCart.Name = "picCart";
            this.picCart.Size = new System.Drawing.Size(68, 54);
            this.picCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCart.TabIndex = 4;
            this.picCart.TabStop = false;
            this.picCart.Click += new System.EventHandler(this.picCart_Click);
            // 
            // picLogin
            // 
            this.picLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogin.Image = ((System.Drawing.Image)(resources.GetObject("picLogin.Image")));
            this.picLogin.Location = new System.Drawing.Point(1147, 53);
            this.picLogin.Name = "picLogin";
            this.picLogin.Size = new System.Drawing.Size(68, 54);
            this.picLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogin.TabIndex = 2;
            this.picLogin.TabStop = false;
            this.picLogin.Click += new System.EventHandler(this.picLogin_Click);
            // 
            // picLogo
            // 
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picLogo.Image = global::khaokaijeow_shop.Properties.Resources.iconshop;
            this.picLogo.Location = new System.Drawing.Point(667, 11);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(128, 84);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // btnUserProfile
            // 
            this.btnUserProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnUserProfile.Image")));
            this.btnUserProfile.Location = new System.Drawing.Point(1233, 53);
            this.btnUserProfile.Name = "btnUserProfile";
            this.btnUserProfile.Size = new System.Drawing.Size(68, 54);
            this.btnUserProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnUserProfile.TabIndex = 9;
            this.btnUserProfile.TabStop = false;
            this.btnUserProfile.Click += new System.EventHandler(this.btnUserProfile_Click);
            // 
            // MainShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(1515, 844);
            this.Controls.Add(this.flpMenuContainer);
            this.Controls.Add(this.picBanner);
            this.Controls.Add(this.pnlheadline);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainShop";
            this.Text = "khaokaijeow ข้าวไข่เจียว";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlheadline.ResumeLayout(false);
            this.pnlheadline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOrderHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUserProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlheadline;
        private System.Windows.Forms.PictureBox picBanner;
        private System.Windows.Forms.FlowLayoutPanel flpMenuContainer;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.PictureBox picCart;
        private System.Windows.Forms.PictureBox picLogin;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnCustomMenu;
        private System.Windows.Forms.Button btnMenuSamret;
        private System.Windows.Forms.Label lblnameshop;
        private System.Windows.Forms.PictureBox picOrderHistory;
        private System.Windows.Forms.PictureBox btnUserProfile;
    }
}

