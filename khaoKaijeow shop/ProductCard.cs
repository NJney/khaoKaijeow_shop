using khaokaijeow_shop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static khaokaijeow_shop.FormMyCart;

namespace khaokaijeow_shop
{
    public partial class ProductCard : UserControl
    {
        public ProductCard()
        {
            InitializeComponent();
        }

        private void ProductCard_Load(object sender, EventArgs e)
        {

        }


        // ส่วน Properties
            public int PMenuID { get; set; }
            public string PName { get; set; }
            public decimal PPrice { get; set; }
            public string PImgPath { get; set; }
            public bool PIsHot { get; set; }

            public bool PIsCustom { get; set; } = false;



        public void DisplayProductData()
        {

            this.lblProductName.Text = PName;

            this.lblPrice.Text = PPrice.ToString("N0") + "บาท";

            if (System.IO.File.Exists(PImgPath))
            {
                try
                {
                    this.picProductImage.Load(PImgPath);
                }
                catch
                {
                    // หากโหลดรูปไม่ได้เนื่องจากสิทธิ์/ปัญหาอื่นๆ ให้ใช้ Placeholder
                    this.picProductImage.Image = null;
                    
                }
            }
            else
            {
                // Path ไม่ถูกต้องหรือไฟล์ไม่มี ให้ใช้ Placeholder
                this.picProductImage.Image = null;
            }

            if (PIsHot)
            {
                // เมื่อ IsHot เป็น true, เราจะทำให้ Label ที่ชื่อ lblHotStatus ปรากฏขึ้นมา
                this.lblHotStatus.Visible = true;
            }
            else
            {
                // ถ้าไม่ hot ก็ให้ซ่อนไว้ (ตามที่เราตั้งค่าเริ่มต้น)
                this.lblHotStatus.Visible = false;
            }

        }

        private void picAddtoCart_Click(object sender, EventArgs e)
        {

            // กำหนด ItemType ที่ถูกต้อง
            string itemType = PIsCustom ? "Ingredient" : "Menu";

            // 1. สร้าง CartItem
            CartManager.CartItem newItem = new CartManager.CartItem
            {
                ProductID = this.PMenuID,
                Name = this.PName,
                UnitPrice = this.PPrice,
                Quantity = 1,
                ItemType = itemType,
                CustomDetails = ""
            };

            // 2. เรียกใช้ AddItem และรับผลลัพธ์ (bool)
            bool success = CartManager.AddItem(newItem);

            // 3. แจ้งเตือนผู้ใช้เฉพาะเมื่อเพิ่มสำเร็จเท่านั้น
            if (success)
            {
                MessageBox.Show($"{this.PName} ถูกเพิ่มเข้าตะกร้าแล้ว!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // หากไม่สำเร็จ (success == false), CartManager.AddItem จะแสดง MessageBox.Show แจ้งเตือนของหมดเอง
        }



        private void ProductCard_Click(object sender, EventArgs e)
        {
            // 1. ตรวจสอบว่าเป็น Menu สำเร็จ (ไม่ใช่ Custom Item)
            if (!PIsCustom)
            {
                // 2. เปิด FormCustomOrder ในโหมด "ปรับแต่งเมนูสำเร็จ"
                FormCustomOrder customForm = new FormCustomOrder(
                    id: this.PMenuID,
                    name: this.PName,
                     price: this.PPrice
                );

                customForm.ShowDialog();
            }
        }
    }
}
