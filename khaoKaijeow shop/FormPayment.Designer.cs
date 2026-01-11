namespace khaokaijeow_shop
{
    partial class FormPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPayment));
            this.lblPaymentDetails = new System.Windows.Forms.Label();
            this.btnConfirmPayment = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUploadSlip = new System.Windows.Forms.Button();
            this.txtSlipFileName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPaymentDetails
            // 
            this.lblPaymentDetails.AutoSize = true;
            this.lblPaymentDetails.Location = new System.Drawing.Point(196, 570);
            this.lblPaymentDetails.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPaymentDetails.Name = "lblPaymentDetails";
            this.lblPaymentDetails.Size = new System.Drawing.Size(95, 29);
            this.lblPaymentDetails.TabIndex = 1;
            this.lblPaymentDetails.Text = "ราคารวม";
            // 
            // btnConfirmPayment
            // 
            this.btnConfirmPayment.Location = new System.Drawing.Point(129, 762);
            this.btnConfirmPayment.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.Size = new System.Drawing.Size(221, 77);
            this.btnConfirmPayment.TabIndex = 3;
            this.btnConfirmPayment.Text = "ชำระเงินเสร็จสิ้น";
            this.btnConfirmPayment.UseVisualStyleBackColor = true;
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(65, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 539);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnUploadSlip
            // 
            this.btnUploadSlip.Location = new System.Drawing.Point(96, 624);
            this.btnUploadSlip.Name = "btnUploadSlip";
            this.btnUploadSlip.Size = new System.Drawing.Size(282, 54);
            this.btnUploadSlip.TabIndex = 4;
            this.btnUploadSlip.Text = "อัปโหลดไฟล์สลิป";
            this.btnUploadSlip.UseVisualStyleBackColor = true;
            this.btnUploadSlip.Click += new System.EventHandler(this.btnUploadSlip_Click);
            // 
            // txtSlipFileName
            // 
            this.txtSlipFileName.Location = new System.Drawing.Point(96, 696);
            this.txtSlipFileName.Name = "txtSlipFileName";
            this.txtSlipFileName.Size = new System.Drawing.Size(282, 37);
            this.txtSlipFileName.TabIndex = 5;
            // 
            // FormPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(498, 852);
            this.Controls.Add(this.txtSlipFileName);
            this.Controls.Add(this.btnUploadSlip);
            this.Controls.Add(this.btnConfirmPayment);
            this.Controls.Add(this.lblPaymentDetails);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "FormPayment";
            this.Text = "FormPayment";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPaymentDetails;
        private System.Windows.Forms.Button btnConfirmPayment;
        private System.Windows.Forms.Button btnUploadSlip;
        private System.Windows.Forms.TextBox txtSlipFileName;
    }
}