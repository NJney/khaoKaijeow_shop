using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace khaokaijeow_shop
{
    public partial class IngredientCard : UserControl
    {
        public IngredientCard()
        {
            InitializeComponent();
        }

        // 1. Properties (สมมติว่าคุณสร้างไว้แล้ว)
        public int IngID { get; set; }
        public string IngName { get; set; }
        public decimal IngPrice { get; set; }
        public string IngImgPath { get; set; }

        // 2. เมธอดแสดงผล
        public void DisplayIngredientData()
        {
            // *** 1. แสดงชื่อและราคา (ต้องมี Label ชื่อ lblIngName และ lblIngPrice) ***
            this.lblIngName.Text = IngName;
            this.lblIngPrice.Text = IngPrice.ToString("N0") + " บาท";

            // *** 2. โหลดรูปภาพ (ต้องมี PictureBox ชื่อ picIngredient) ***
            if (System.IO.File.Exists(IngImgPath))
            {
                try
                {
                    // ต้องมี PictureBox ชื่อ picIngredient 
                    this.picIngredient.Load(IngImgPath);
                }
                catch
                {
                    this.picIngredient.Image = null;
                }
            }
            else
            {
                this.picIngredient.Image = null; // Path ผิด ให้แสดง Placeholder
            }
        }

        // 3. Event Handler สำหรับปุ่มเพิ่ม
        private void btnAddIng_Click(object sender, System.EventArgs e)
        {
            // ปล่อยว่างไว้ เพราะ Logic การเพิ่มจะถูกผูกใน FormCustomOrder
        }
    }
}