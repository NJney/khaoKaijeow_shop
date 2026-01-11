namespace khaokaijeow_shop
{
    partial class FormAdminSalesRecords
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
            this.pnlChartArea = new System.Windows.Forms.Panel();
            this.dgvRanking = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalPriceSummary = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnApplyDateFilter = new System.Windows.Forms.Button();
            this.txtFilterYear = new System.Windows.Forms.TextBox();
            this.cmbFilterMonth = new System.Windows.Forms.ComboBox();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnRankWorst = new System.Windows.Forms.Button();
            this.btnRankBest = new System.Windows.Forms.Button();
            this.btnFilterWeek = new System.Windows.Forms.Button();
            this.btnFilterAll = new System.Windows.Forms.Button();
            this.btnFilterIngredient = new System.Windows.Forms.Button();
            this.btnFilterMenu = new System.Windows.Forms.Button();
            this.pnlAdminHeader = new System.Windows.Forms.Panel();
            this.btnNavSales = new System.Windows.Forms.Button();
            this.btnNavUser = new System.Windows.Forms.Button();
            this.btnNavMenu = new System.Windows.Forms.Button();
            this.dgvSalesRecords = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchSales = new System.Windows.Forms.TextBox();
            this.pnlChartArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlAdminHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChartArea
            // 
            this.pnlChartArea.Controls.Add(this.dgvRanking);
            this.pnlChartArea.Controls.Add(this.panel1);
            this.pnlChartArea.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlChartArea.Location = new System.Drawing.Point(1091, 191);
            this.pnlChartArea.Name = "pnlChartArea";
            this.pnlChartArea.Size = new System.Drawing.Size(843, 741);
            this.pnlChartArea.TabIndex = 4;
            // 
            // dgvRanking
            // 
            this.dgvRanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRanking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRanking.Location = new System.Drawing.Point(0, 55);
            this.dgvRanking.Name = "dgvRanking";
            this.dgvRanking.RowHeadersWidth = 62;
            this.dgvRanking.RowTemplate.Height = 28;
            this.dgvRanking.Size = new System.Drawing.Size(843, 686);
            this.dgvRanking.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotalPriceSummary);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 55);
            this.panel1.TabIndex = 0;
            // 
            // lblTotalPriceSummary
            // 
            this.lblTotalPriceSummary.AutoSize = true;
            this.lblTotalPriceSummary.Font = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPriceSummary.Location = new System.Drawing.Point(14, 9);
            this.lblTotalPriceSummary.Name = "lblTotalPriceSummary";
            this.lblTotalPriceSummary.Size = new System.Drawing.Size(109, 34);
            this.lblTotalPriceSummary.TabIndex = 0;
            this.lblTotalPriceSummary.Text = "ราคารวม";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlFilter.Controls.Add(this.txtSearchSales);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.btnApplyDateFilter);
            this.pnlFilter.Controls.Add(this.txtFilterYear);
            this.pnlFilter.Controls.Add(this.cmbFilterMonth);
            this.pnlFilter.Controls.Add(this.btnExportPDF);
            this.pnlFilter.Controls.Add(this.btnRankWorst);
            this.pnlFilter.Controls.Add(this.btnRankBest);
            this.pnlFilter.Controls.Add(this.btnFilterWeek);
            this.pnlFilter.Controls.Add(this.btnFilterAll);
            this.pnlFilter.Controls.Add(this.btnFilterIngredient);
            this.pnlFilter.Controls.Add(this.btnFilterMenu);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFilter.Location = new System.Drawing.Point(0, 104);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1934, 87);
            this.pnlFilter.TabIndex = 7;
            // 
            // btnApplyDateFilter
            // 
            this.btnApplyDateFilter.BackColor = System.Drawing.Color.LightCyan;
            this.btnApplyDateFilter.Location = new System.Drawing.Point(963, 26);
            this.btnApplyDateFilter.Name = "btnApplyDateFilter";
            this.btnApplyDateFilter.Size = new System.Drawing.Size(119, 43);
            this.btnApplyDateFilter.TabIndex = 9;
            this.btnApplyDateFilter.Text = "ยืนยัน";
            this.btnApplyDateFilter.UseVisualStyleBackColor = false;
            this.btnApplyDateFilter.Click += new System.EventHandler(this.btnApplyDateFilter_Click);
            // 
            // txtFilterYear
            // 
            this.txtFilterYear.Location = new System.Drawing.Point(832, 27);
            this.txtFilterYear.Name = "txtFilterYear";
            this.txtFilterYear.Size = new System.Drawing.Size(125, 42);
            this.txtFilterYear.TabIndex = 8;
            // 
            // cmbFilterMonth
            // 
            this.cmbFilterMonth.FormattingEnabled = true;
            this.cmbFilterMonth.Location = new System.Drawing.Point(664, 27);
            this.cmbFilterMonth.Name = "cmbFilterMonth";
            this.cmbFilterMonth.Size = new System.Drawing.Size(162, 42);
            this.cmbFilterMonth.TabIndex = 7;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.BackColor = System.Drawing.Color.LightCyan;
            this.btnExportPDF.Location = new System.Drawing.Point(1825, 24);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(187, 47);
            this.btnExportPDF.TabIndex = 6;
            this.btnExportPDF.Text = "Export CSV";
            this.btnExportPDF.UseVisualStyleBackColor = false;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // btnRankWorst
            // 
            this.btnRankWorst.BackColor = System.Drawing.Color.LightCyan;
            this.btnRankWorst.Location = new System.Drawing.Point(1681, 25);
            this.btnRankWorst.Name = "btnRankWorst";
            this.btnRankWorst.Size = new System.Drawing.Size(138, 47);
            this.btnRankWorst.TabIndex = 5;
            this.btnRankWorst.Text = "ขายแย่";
            this.btnRankWorst.UseVisualStyleBackColor = false;
            this.btnRankWorst.Click += new System.EventHandler(this.btnRankWorst_Click);
            // 
            // btnRankBest
            // 
            this.btnRankBest.BackColor = System.Drawing.Color.LightCyan;
            this.btnRankBest.Location = new System.Drawing.Point(1543, 24);
            this.btnRankBest.Name = "btnRankBest";
            this.btnRankBest.Size = new System.Drawing.Size(132, 48);
            this.btnRankBest.TabIndex = 4;
            this.btnRankBest.Text = "ขายดี";
            this.btnRankBest.UseVisualStyleBackColor = false;
            this.btnRankBest.Click += new System.EventHandler(this.btnRankBest_Click);
            // 
            // btnFilterWeek
            // 
            this.btnFilterWeek.BackColor = System.Drawing.Color.LightCyan;
            this.btnFilterWeek.Location = new System.Drawing.Point(487, 26);
            this.btnFilterWeek.Name = "btnFilterWeek";
            this.btnFilterWeek.Size = new System.Drawing.Size(171, 44);
            this.btnFilterWeek.TabIndex = 0;
            this.btnFilterWeek.Text = "เวลาทั้งหมด";
            this.btnFilterWeek.UseVisualStyleBackColor = false;
            this.btnFilterWeek.Click += new System.EventHandler(this.btnFilterWeek_Click);
            // 
            // btnFilterAll
            // 
            this.btnFilterAll.BackColor = System.Drawing.Color.LightCyan;
            this.btnFilterAll.Location = new System.Drawing.Point(312, 16);
            this.btnFilterAll.Name = "btnFilterAll";
            this.btnFilterAll.Size = new System.Drawing.Size(144, 55);
            this.btnFilterAll.TabIndex = 1;
            this.btnFilterAll.Text = "ทั้งหมด";
            this.btnFilterAll.UseVisualStyleBackColor = false;
            this.btnFilterAll.Click += new System.EventHandler(this.btnFilterAll_Click);
            // 
            // btnFilterIngredient
            // 
            this.btnFilterIngredient.BackColor = System.Drawing.Color.LightCyan;
            this.btnFilterIngredient.Location = new System.Drawing.Point(162, 14);
            this.btnFilterIngredient.Name = "btnFilterIngredient";
            this.btnFilterIngredient.Size = new System.Drawing.Size(144, 55);
            this.btnFilterIngredient.TabIndex = 1;
            this.btnFilterIngredient.Text = "วัตถุดิบ";
            this.btnFilterIngredient.UseVisualStyleBackColor = false;
            this.btnFilterIngredient.Click += new System.EventHandler(this.btnFilterIngredient_Click_1);
            // 
            // btnFilterMenu
            // 
            this.btnFilterMenu.BackColor = System.Drawing.Color.LightCyan;
            this.btnFilterMenu.Location = new System.Drawing.Point(12, 15);
            this.btnFilterMenu.Name = "btnFilterMenu";
            this.btnFilterMenu.Size = new System.Drawing.Size(144, 54);
            this.btnFilterMenu.TabIndex = 0;
            this.btnFilterMenu.Text = "เมนู";
            this.btnFilterMenu.UseVisualStyleBackColor = false;
            this.btnFilterMenu.Click += new System.EventHandler(this.btnFilterMenu_Click);
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
            this.pnlAdminHeader.Size = new System.Drawing.Size(1934, 104);
            this.pnlAdminHeader.TabIndex = 6;
            // 
            // btnNavSales
            // 
            this.btnNavSales.BackColor = System.Drawing.Color.Cyan;
            this.btnNavSales.Location = new System.Drawing.Point(517, 20);
            this.btnNavSales.Name = "btnNavSales";
            this.btnNavSales.Size = new System.Drawing.Size(226, 53);
            this.btnNavSales.TabIndex = 2;
            this.btnNavSales.Text = "ผลการขาย";
            this.btnNavSales.UseVisualStyleBackColor = false;
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
            this.btnNavMenu.BackColor = System.Drawing.Color.LightCyan;
            this.btnNavMenu.Location = new System.Drawing.Point(27, 20);
            this.btnNavMenu.Name = "btnNavMenu";
            this.btnNavMenu.Size = new System.Drawing.Size(226, 53);
            this.btnNavMenu.TabIndex = 0;
            this.btnNavMenu.Text = "จัดการเมนู";
            this.btnNavMenu.UseVisualStyleBackColor = false;
            this.btnNavMenu.Click += new System.EventHandler(this.btnNavMenu_Click);
            // 
            // dgvSalesRecords
            // 
            this.dgvSalesRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesRecords.Location = new System.Drawing.Point(0, 191);
            this.dgvSalesRecords.Name = "dgvSalesRecords";
            this.dgvSalesRecords.RowHeadersWidth = 62;
            this.dgvSalesRecords.RowTemplate.Height = 28;
            this.dgvSalesRecords.Size = new System.Drawing.Size(1091, 741);
            this.dgvSalesRecords.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1123, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 34);
            this.label1.TabIndex = 10;
            this.label1.Text = "ค้นหา (ID/ชื่อ/เมนู):";
            // 
            // txtSearchSales
            // 
            this.txtSearchSales.Location = new System.Drawing.Point(1344, 29);
            this.txtSearchSales.Name = "txtSearchSales";
            this.txtSearchSales.Size = new System.Drawing.Size(183, 42);
            this.txtSearchSales.TabIndex = 11;
            this.txtSearchSales.TextChanged += new System.EventHandler(this.txtSearchSales_TextChanged);
            // 
            // FormAdminSalesRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1934, 932);
            this.Controls.Add(this.dgvSalesRecords);
            this.Controls.Add(this.pnlChartArea);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlAdminHeader);
            this.Name = "FormAdminSalesRecords";
            this.Text = "FormAdminSalesRecords";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlChartArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlAdminHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesRecords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChartArea;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnFilterWeek;
        private System.Windows.Forms.Button btnFilterAll;
        private System.Windows.Forms.Button btnFilterIngredient;
        private System.Windows.Forms.Button btnFilterMenu;
        private System.Windows.Forms.Panel pnlAdminHeader;
        private System.Windows.Forms.Button btnNavSales;
        private System.Windows.Forms.Button btnNavUser;
        private System.Windows.Forms.Button btnNavMenu;
        private System.Windows.Forms.DataGridView dgvSalesRecords;
        private System.Windows.Forms.Button btnRankWorst;
        private System.Windows.Forms.Button btnRankBest;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalPriceSummary;
        private System.Windows.Forms.DataGridView dgvRanking;
        private System.Windows.Forms.Button btnApplyDateFilter;
        private System.Windows.Forms.TextBox txtFilterYear;
        private System.Windows.Forms.ComboBox cmbFilterMonth;
        private System.Windows.Forms.TextBox txtSearchSales;
        private System.Windows.Forms.Label label1;
    }
}