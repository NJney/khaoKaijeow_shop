namespace khaokaijeow_shop
{
    partial class IngredientCard
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
            this.picIngredient = new System.Windows.Forms.PictureBox();
            this.lblIngName = new System.Windows.Forms.Label();
            this.lblIngPrice = new System.Windows.Forms.Label();
            this.btnAddIng = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picIngredient)).BeginInit();
            this.SuspendLayout();
            // 
            // picIngredient
            // 
            this.picIngredient.Location = new System.Drawing.Point(12, 12);
            this.picIngredient.Name = "picIngredient";
            this.picIngredient.Size = new System.Drawing.Size(114, 81);
            this.picIngredient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIngredient.TabIndex = 0;
            this.picIngredient.TabStop = false;
            // 
            // lblIngName
            // 
            this.lblIngName.AutoSize = true;
            this.lblIngName.ForeColor = System.Drawing.Color.White;
            this.lblIngName.Location = new System.Drawing.Point(8, 96);
            this.lblIngName.Name = "lblIngName";
            this.lblIngName.Size = new System.Drawing.Size(51, 20);
            this.lblIngName.TabIndex = 1;
            this.lblIngName.Text = "label1";
            // 
            // lblIngPrice
            // 
            this.lblIngPrice.AutoSize = true;
            this.lblIngPrice.ForeColor = System.Drawing.Color.White;
            this.lblIngPrice.Location = new System.Drawing.Point(8, 116);
            this.lblIngPrice.Name = "lblIngPrice";
            this.lblIngPrice.Size = new System.Drawing.Size(51, 20);
            this.lblIngPrice.TabIndex = 2;
            this.lblIngPrice.Text = "label2";
            // 
            // btnAddIng
            // 
            this.btnAddIng.Location = new System.Drawing.Point(84, 99);
            this.btnAddIng.Name = "btnAddIng";
            this.btnAddIng.Size = new System.Drawing.Size(51, 39);
            this.btnAddIng.TabIndex = 3;
            this.btnAddIng.Text = "เพิ่ม";
            this.btnAddIng.UseVisualStyleBackColor = true;
            this.btnAddIng.Click += new System.EventHandler(this.btnAddIng_Click);
            // 
            // IngredientCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.Controls.Add(this.btnAddIng);
            this.Controls.Add(this.lblIngPrice);
            this.Controls.Add(this.lblIngName);
            this.Controls.Add(this.picIngredient);
            this.Name = "IngredientCard";
            ((System.ComponentModel.ISupportInitialize)(this.picIngredient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picIngredient;
        private System.Windows.Forms.Label lblIngName;
        private System.Windows.Forms.Label lblIngPrice;
        public System.Windows.Forms.Button btnAddIng;
    }
}
