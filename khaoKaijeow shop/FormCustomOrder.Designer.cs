namespace khaokaijeow_shop
{
    partial class FormCustomOrder
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
            this.lblBaseMenu = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFinalPrice = new System.Windows.Forms.Label();
            this.flpIngredientsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.btnAddToMainCart = new System.Windows.Forms.Button();
            this.dgvSelectedIngredients = new System.Windows.Forms.DataGridView();
            this.ColSummaryDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColSummaryMinus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedIngredients)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBaseMenu
            // 
            this.lblBaseMenu.AutoSize = true;
            this.lblBaseMenu.Font = new System.Drawing.Font("Verdana", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseMenu.Location = new System.Drawing.Point(37, 22);
            this.lblBaseMenu.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBaseMenu.Name = "lblBaseMenu";
            this.lblBaseMenu.Size = new System.Drawing.Size(222, 59);
            this.lblBaseMenu.TabIndex = 1;
            this.lblBaseMenu.Text = "ชื่อเมนูหลัก";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.SaddleBrown;
            this.pnlHeader.Controls.Add(this.lblFinalPrice);
            this.pnlHeader.Controls.Add(this.lblBaseMenu);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Font = new System.Drawing.Font("Verdana", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1617, 107);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblFinalPrice
            // 
            this.lblFinalPrice.AutoSize = true;
            this.lblFinalPrice.Font = new System.Drawing.Font("Verdana", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalPrice.Location = new System.Drawing.Point(1290, 22);
            this.lblFinalPrice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFinalPrice.Name = "lblFinalPrice";
            this.lblFinalPrice.Size = new System.Drawing.Size(217, 59);
            this.lblFinalPrice.TabIndex = 2;
            this.lblFinalPrice.Text = "รวมทั้งหมด";
            // 
            // flpIngredientsContainer
            // 
            this.flpIngredientsContainer.AutoScroll = true;
            this.flpIngredientsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpIngredientsContainer.Location = new System.Drawing.Point(0, 107);
            this.flpIngredientsContainer.Name = "flpIngredientsContainer";
            this.flpIngredientsContainer.Size = new System.Drawing.Size(781, 687);
            this.flpIngredientsContainer.TabIndex = 3;
            // 
            // pnlSummary
            // 
            this.pnlSummary.Controls.Add(this.btnAddToMainCart);
            this.pnlSummary.Controls.Add(this.dgvSelectedIngredients);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSummary.Location = new System.Drawing.Point(781, 107);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(836, 687);
            this.pnlSummary.TabIndex = 4;
            // 
            // btnAddToMainCart
            // 
            this.btnAddToMainCart.Location = new System.Drawing.Point(570, 556);
            this.btnAddToMainCart.Name = "btnAddToMainCart";
            this.btnAddToMainCart.Size = new System.Drawing.Size(205, 83);
            this.btnAddToMainCart.TabIndex = 1;
            this.btnAddToMainCart.Text = "ยืนยันเพื่อเพิ่มออเดอร์";
            this.btnAddToMainCart.UseVisualStyleBackColor = true;
            this.btnAddToMainCart.Click += new System.EventHandler(this.btnAddToMainCart_Click);
            // 
            // dgvSelectedIngredients
            // 
            this.dgvSelectedIngredients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSelectedIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedIngredients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSummaryDelete,
            this.ColSummaryMinus,
            this.ColName,
            this.ColQuantity,
            this.ColTotalPrice});
            this.dgvSelectedIngredients.Location = new System.Drawing.Point(23, 17);
            this.dgvSelectedIngredients.Name = "dgvSelectedIngredients";
            this.dgvSelectedIngredients.RowHeadersWidth = 62;
            this.dgvSelectedIngredients.RowTemplate.Height = 28;
            this.dgvSelectedIngredients.Size = new System.Drawing.Size(790, 488);
            this.dgvSelectedIngredients.TabIndex = 0;
            this.dgvSelectedIngredients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectedIngredients_CellContentClick);
            // 
            // ColSummaryDelete
            // 
            this.ColSummaryDelete.FillWeight = 50F;
            this.ColSummaryDelete.HeaderText = "ลบเมนู";
            this.ColSummaryDelete.MinimumWidth = 8;
            this.ColSummaryDelete.Name = "ColSummaryDelete";
            this.ColSummaryDelete.Text = "❌";
            this.ColSummaryDelete.UseColumnTextForButtonValue = true;
            // 
            // ColSummaryMinus
            // 
            this.ColSummaryMinus.FillWeight = 53.97727F;
            this.ColSummaryMinus.HeaderText = "-";
            this.ColSummaryMinus.MinimumWidth = 8;
            this.ColSummaryMinus.Name = "ColSummaryMinus";
            this.ColSummaryMinus.Text = "-";
            this.ColSummaryMinus.UseColumnTextForButtonValue = true;
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "Name";
            this.ColName.FillWeight = 200F;
            this.ColName.HeaderText = "วัตถุดิบ";
            this.ColName.MinimumWidth = 8;
            this.ColName.Name = "ColName";
            // 
            // ColQuantity
            // 
            this.ColQuantity.DataPropertyName = "Quantity";
            this.ColQuantity.FillWeight = 53.97727F;
            this.ColQuantity.HeaderText = "จำนวน";
            this.ColQuantity.MinimumWidth = 8;
            this.ColQuantity.Name = "ColQuantity";
            // 
            // ColTotalPrice
            // 
            this.ColTotalPrice.DataPropertyName = "TotalPrice";
            this.ColTotalPrice.FillWeight = 53.97727F;
            this.ColTotalPrice.HeaderText = "ราคา";
            this.ColTotalPrice.MinimumWidth = 8;
            this.ColTotalPrice.Name = "ColTotalPrice";
            // 
            // FormCustomOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 34F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1617, 794);
            this.Controls.Add(this.flpIngredientsContainer);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FormCustomOrder";
            this.Text = "FormCustomOrder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedIngredients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblBaseMenu;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblFinalPrice;
        private System.Windows.Forms.FlowLayoutPanel flpIngredientsContainer;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.DataGridView dgvSelectedIngredients;
        private System.Windows.Forms.Button btnAddToMainCart;
        private System.Windows.Forms.DataGridViewButtonColumn ColSummaryDelete;
        private System.Windows.Forms.DataGridViewButtonColumn ColSummaryMinus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalPrice;
    }
}