namespace khaokaijeow_shop
{
    partial class FormMyCart
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCustomDetails = new System.Windows.Forms.Label();
            this.picSelectedItem = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSelectedItemName = new System.Windows.Forms.Label();
            this.btnContinueShopping = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.dgvCartItems = new System.Windows.Forms.DataGridView();
            this.ColDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColMinus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColPlus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedItem)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartItems)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Bisque;
            this.panel1.Controls.Add(this.lblCustomDetails);
            this.panel1.Controls.Add(this.picSelectedItem);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lblSelectedItemName);
            this.panel1.Controls.Add(this.btnContinueShopping);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnCheckout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1264, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 907);
            this.panel1.TabIndex = 0;
            // 
            // lblCustomDetails
            // 
            this.lblCustomDetails.AutoSize = true;
            this.lblCustomDetails.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomDetails.Location = new System.Drawing.Point(214, 700);
            this.lblCustomDetails.Name = "lblCustomDetails";
            this.lblCustomDetails.Size = new System.Drawing.Size(184, 38);
            this.lblCustomDetails.TabIndex = 8;
            this.lblCustomDetails.Text = "ไม่มีวัตถุดิบเสริม";
            this.lblCustomDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picSelectedItem
            // 
            this.picSelectedItem.BackColor = System.Drawing.Color.SeaShell;
            this.picSelectedItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.picSelectedItem.Location = new System.Drawing.Point(0, 217);
            this.picSelectedItem.Name = "picSelectedItem";
            this.picSelectedItem.Size = new System.Drawing.Size(587, 389);
            this.picSelectedItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSelectedItem.TabIndex = 5;
            this.picSelectedItem.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SaddleBrown;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 189);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(587, 28);
            this.panel3.TabIndex = 6;
            // 
            // lblSelectedItemName
            // 
            this.lblSelectedItemName.AutoSize = true;
            this.lblSelectedItemName.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedItemName.Location = new System.Drawing.Point(214, 637);
            this.lblSelectedItemName.Name = "lblSelectedItemName";
            this.lblSelectedItemName.Size = new System.Drawing.Size(304, 48);
            this.lblSelectedItemName.TabIndex = 7;
            this.lblSelectedItemName.Text = "ยังไม่มีรายการที่เลือก";
            this.lblSelectedItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnContinueShopping
            // 
            this.btnContinueShopping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContinueShopping.Location = new System.Drawing.Point(76, 791);
            this.btnContinueShopping.Name = "btnContinueShopping";
            this.btnContinueShopping.Size = new System.Drawing.Size(160, 104);
            this.btnContinueShopping.TabIndex = 4;
            this.btnContinueShopping.Text = "เลือกซื้อต่อ";
            this.btnContinueShopping.UseVisualStyleBackColor = true;
            this.btnContinueShopping.Click += new System.EventHandler(this.btnContinueShopping_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Sienna;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblTotalPrice);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(587, 189);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 48);
            this.label2.TabIndex = 3;
            this.label2.Text = "ราคารวม";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 86);
            this.label1.TabIndex = 2;
            this.label1.Text = "ตะกร้า";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.Location = new System.Drawing.Point(378, 115);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(129, 48);
            this.lblTotalPrice.TabIndex = 0;
            this.lblTotalPrice.Text = "ราคารวม";
            // 
            // btnCheckout
            // 
            this.btnCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckout.Location = new System.Drawing.Point(276, 791);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(240, 104);
            this.btnCheckout.TabIndex = 1;
            this.btnCheckout.Text = "ชำระเงิน";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // dgvCartItems
            // 
            this.dgvCartItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCartItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDelete,
            this.ColMinus,
            this.ColPlus,
            this.ColName,
            this.ColCustomDetails,
            this.ColQuantity,
            this.ColUnitPrice,
            this.ColTotalPrice});
            this.dgvCartItems.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvCartItems.Location = new System.Drawing.Point(0, 0);
            this.dgvCartItems.Name = "dgvCartItems";
            this.dgvCartItems.ReadOnly = true;
            this.dgvCartItems.RowHeadersWidth = 62;
            this.dgvCartItems.RowTemplate.Height = 28;
            this.dgvCartItems.Size = new System.Drawing.Size(1264, 907);
            this.dgvCartItems.TabIndex = 1;
            this.dgvCartItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCartItems_CellClick);
            this.dgvCartItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCartItems_CellContentClick);
            // 
            // ColDelete
            // 
            this.ColDelete.HeaderText = "ลบ";
            this.ColDelete.MinimumWidth = 8;
            this.ColDelete.Name = "ColDelete";
            this.ColDelete.ReadOnly = true;
            this.ColDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColDelete.Text = "X";
            // 
            // ColMinus
            // 
            this.ColMinus.HeaderText = "-";
            this.ColMinus.MinimumWidth = 8;
            this.ColMinus.Name = "ColMinus";
            this.ColMinus.ReadOnly = true;
            this.ColMinus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColMinus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColMinus.Text = "-";
            // 
            // ColPlus
            // 
            this.ColPlus.HeaderText = "+";
            this.ColPlus.MinimumWidth = 8;
            this.ColPlus.Name = "ColPlus";
            this.ColPlus.ReadOnly = true;
            this.ColPlus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColPlus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColPlus.Text = "+";
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "Name";
            this.ColName.HeaderText = "สินค้า";
            this.ColName.MinimumWidth = 8;
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColCustomDetails
            // 
            this.ColCustomDetails.DataPropertyName = "CustomDetails";
            this.ColCustomDetails.HeaderText = "รายละเอียด";
            this.ColCustomDetails.MinimumWidth = 8;
            this.ColCustomDetails.Name = "ColCustomDetails";
            this.ColCustomDetails.ReadOnly = true;
            // 
            // ColQuantity
            // 
            this.ColQuantity.DataPropertyName = "Quantity";
            this.ColQuantity.HeaderText = "จำนวน";
            this.ColQuantity.MinimumWidth = 8;
            this.ColQuantity.Name = "ColQuantity";
            this.ColQuantity.ReadOnly = true;
            // 
            // ColUnitPrice
            // 
            this.ColUnitPrice.DataPropertyName = "UnitPrice";
            this.ColUnitPrice.HeaderText = "ราคาต่อหน่วย";
            this.ColUnitPrice.MinimumWidth = 8;
            this.ColUnitPrice.Name = "ColUnitPrice";
            this.ColUnitPrice.ReadOnly = true;
            // 
            // ColTotalPrice
            // 
            this.ColTotalPrice.DataPropertyName = "TotalPrice";
            this.ColTotalPrice.HeaderText = "ราคารวม";
            this.ColTotalPrice.MinimumWidth = 8;
            this.ColTotalPrice.Name = "ColTotalPrice";
            this.ColTotalPrice.ReadOnly = true;
            // 
            // FormMyCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1851, 907);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvCartItems);
            this.Name = "FormMyCart";
            this.Text = "FormMyCart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedItem)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCartItems;
        private System.Windows.Forms.Button btnContinueShopping;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.PictureBox picSelectedItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSelectedItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCustomDetails;
        private System.Windows.Forms.DataGridViewButtonColumn ColDelete;
        private System.Windows.Forms.DataGridViewButtonColumn ColMinus;
        private System.Windows.Forms.DataGridViewButtonColumn ColPlus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalPrice;
    }
}