namespace khaokaijeow_shop
{
    partial class FormForgotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForgotPassword));
            this.pnlStep1 = new System.Windows.Forms.Panel();
            this.btnCheckID = new System.Windows.Forms.Button();
            this.txtResetID = new System.Windows.Forms.TextBox();
            this.lblReset = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlStep2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblResetpwd = new System.Windows.Forms.Label();
            this.btnSaveNewPassword = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.pnlStep1.SuspendLayout();
            this.pnlStep2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlStep1
            // 
            this.pnlStep1.BackColor = System.Drawing.Color.LemonChiffon;
            this.pnlStep1.Controls.Add(this.btnCheckID);
            this.pnlStep1.Controls.Add(this.txtResetID);
            this.pnlStep1.Controls.Add(this.lblReset);
            this.pnlStep1.Controls.Add(this.label2);
            this.pnlStep1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStep1.Location = new System.Drawing.Point(81, 83);
            this.pnlStep1.Name = "pnlStep1";
            this.pnlStep1.Size = new System.Drawing.Size(565, 693);
            this.pnlStep1.TabIndex = 0;
            // 
            // btnCheckID
            // 
            this.btnCheckID.Location = new System.Drawing.Point(174, 359);
            this.btnCheckID.Name = "btnCheckID";
            this.btnCheckID.Size = new System.Drawing.Size(214, 65);
            this.btnCheckID.TabIndex = 2;
            this.btnCheckID.Text = "ยืนยัน";
            this.btnCheckID.UseVisualStyleBackColor = true;
            this.btnCheckID.Click += new System.EventHandler(this.btnCheckID_Click);
            // 
            // txtResetID
            // 
            this.txtResetID.Location = new System.Drawing.Point(83, 256);
            this.txtResetID.Name = "txtResetID";
            this.txtResetID.Size = new System.Drawing.Size(376, 42);
            this.txtResetID.TabIndex = 1;
            // 
            // lblReset
            // 
            this.lblReset.AutoSize = true;
            this.lblReset.Location = new System.Drawing.Point(201, 74);
            this.lblReset.Name = "lblReset";
            this.lblReset.Size = new System.Drawing.Size(155, 34);
            this.lblReset.TabIndex = 0;
            this.lblReset.Text = "ตรวจสอบตัวตน";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 34);
            this.label2.TabIndex = 0;
            this.label2.Text = "ใส่ชื่อ หรือ อีเมล เพื่อตรวจสอบ\r\n";
            // 
            // pnlStep2
            // 
            this.pnlStep2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStep2.BackColor = System.Drawing.Color.LemonChiffon;
            this.pnlStep2.Controls.Add(this.label5);
            this.pnlStep2.Controls.Add(this.label4);
            this.pnlStep2.Controls.Add(this.lblResetpwd);
            this.pnlStep2.Controls.Add(this.btnSaveNewPassword);
            this.pnlStep2.Controls.Add(this.txtConfirmPassword);
            this.pnlStep2.Controls.Add(this.txtNewPassword);
            this.pnlStep2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlStep2.Location = new System.Drawing.Point(898, 83);
            this.pnlStep2.Name = "pnlStep2";
            this.pnlStep2.Size = new System.Drawing.Size(565, 693);
            this.pnlStep2.TabIndex = 1;
            this.pnlStep2.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 34);
            this.label5.TabIndex = 6;
            this.label5.Text = "ยืนยันรหัสผ่านใหม่";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 34);
            this.label4.TabIndex = 5;
            this.label4.Text = "รหัสผ่านใหม่";
            // 
            // lblResetpwd
            // 
            this.lblResetpwd.AutoSize = true;
            this.lblResetpwd.Location = new System.Drawing.Point(213, 74);
            this.lblResetpwd.Name = "lblResetpwd";
            this.lblResetpwd.Size = new System.Drawing.Size(146, 34);
            this.lblResetpwd.TabIndex = 4;
            this.lblResetpwd.Text = "ตั้งรหัสผ่านใหม่";
            // 
            // btnSaveNewPassword
            // 
            this.btnSaveNewPassword.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveNewPassword.Location = new System.Drawing.Point(199, 541);
            this.btnSaveNewPassword.Name = "btnSaveNewPassword";
            this.btnSaveNewPassword.Size = new System.Drawing.Size(201, 70);
            this.btnSaveNewPassword.TabIndex = 3;
            this.btnSaveNewPassword.Text = "ยืนยัน";
            this.btnSaveNewPassword.UseVisualStyleBackColor = true;
            this.btnSaveNewPassword.Click += new System.EventHandler(this.btnSaveNewPassword_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(105, 411);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(374, 42);
            this.txtConfirmPassword.TabIndex = 2;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(105, 240);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(356, 42);
            this.txtNewPassword.TabIndex = 1;
            // 
            // FormForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1533, 871);
            this.Controls.Add(this.pnlStep2);
            this.Controls.Add(this.pnlStep1);
            this.Name = "FormForgotPassword";
            this.Text = "FormForgotPassword";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlStep1.ResumeLayout(false);
            this.pnlStep1.PerformLayout();
            this.pnlStep2.ResumeLayout(false);
            this.pnlStep2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlStep1;
        private System.Windows.Forms.Panel pnlStep2;
        private System.Windows.Forms.Label lblReset;
        private System.Windows.Forms.Button btnCheckID;
        private System.Windows.Forms.TextBox txtResetID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblResetpwd;
        private System.Windows.Forms.Button btnSaveNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
    }
}