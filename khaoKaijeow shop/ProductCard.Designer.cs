namespace khaokaijeow_shop
{
    partial class ProductCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductCard));
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblHotStatus = new System.Windows.Forms.Label();
            this.picAddtoCart = new System.Windows.Forms.PictureBox();
            this.picProductImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAddtoCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.White;
            this.lblProductName.Location = new System.Drawing.Point(19, 226);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(109, 45);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "ไข่เจียว";
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.White;
            this.lblPrice.Location = new System.Drawing.Point(19, 280);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(62, 48);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "01";
            // 
            // lblHotStatus
            // 
            this.lblHotStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHotStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblHotStatus.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHotStatus.ForeColor = System.Drawing.Color.Red;
            this.lblHotStatus.Location = new System.Drawing.Point(315, 0);
            this.lblHotStatus.Name = "lblHotStatus";
            this.lblHotStatus.Size = new System.Drawing.Size(77, 42);
            this.lblHotStatus.TabIndex = 5;
            this.lblHotStatus.Text = "HOT!";
            this.lblHotStatus.Visible = false;
            // 
            // picAddtoCart
            // 
            this.picAddtoCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picAddtoCart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picAddtoCart.BackgroundImage")));
            this.picAddtoCart.Location = new System.Drawing.Point(304, 256);
            this.picAddtoCart.Name = "picAddtoCart";
            this.picAddtoCart.Size = new System.Drawing.Size(69, 61);
            this.picAddtoCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAddtoCart.TabIndex = 7;
            this.picAddtoCart.TabStop = false;
            this.picAddtoCart.Click += new System.EventHandler(this.picAddtoCart_Click);
            // 
            // picProductImage
            // 
            this.picProductImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picProductImage.Location = new System.Drawing.Point(16, 19);
            this.picProductImage.Name = "picProductImage";
            this.picProductImage.Size = new System.Drawing.Size(357, 204);
            this.picProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProductImage.TabIndex = 0;
            this.picProductImage.TabStop = false;
            // 
            // ProductCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.Controls.Add(this.picAddtoCart);
            this.Controls.Add(this.lblHotStatus);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.picProductImage);
            this.Name = "ProductCard";
            this.Size = new System.Drawing.Size(395, 338);
            this.Click += new System.EventHandler(this.ProductCard_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picAddtoCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox picProductImage;
        public System.Windows.Forms.Label lblHotStatus;
        public System.Windows.Forms.Label lblProductName;
        public System.Windows.Forms.Label lblPrice;
        public System.Windows.Forms.PictureBox picAddtoCart;
    }
}
