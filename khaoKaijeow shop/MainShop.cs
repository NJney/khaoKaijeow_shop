using khaokaijeow_shop;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using static khaokaijeow_shop.FormMyCart;

namespace khaokaijeow_shop
{
    // Form หลักสำหรับแสดงเมนู
    public partial class MainShop : Form
    {
        

        public MainShop()
        {
            InitializeComponent();
            // โหลดข้อมูลเมนู
            LoadMenuData();
        }

        public void LoadMenuData()
        {
            // 1. กำหนด Query SQL (ต้องดึง image_path มาด้วย)
            string sql = "SELECT menu_id, name, price, image_path, is_hot FROM Menu";

            // 2. ดึง Connection Object
            using (MySql.Data.MySqlClient.MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, connection);
                    MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();

                    // ล้าง Controls เดิมออกก่อนโหลดใหม่ (ถ้ามี)
                    flpMenuContainer.Controls.Clear();

                    while (reader.Read())
                    {
                        // 3. อ่านข้อมูลจากแต่ละคอลัมน์
                        int id = reader.GetInt32("menu_id");
                        string name = reader.GetString("name");
                        decimal price = reader.GetDecimal("price");
                        string imagePath = reader.GetString("image_path");
                        bool isHot = reader.GetBoolean("is_hot");

                        // 4. สร้าง Object ProductCard ใหม่
                        ProductCard card = new ProductCard();

                        // 5. กำหนดค่า Properties (ที่คุณสร้างไว้ใน ProductCard.cs)
                        card.PMenuID = id;
                        card.PName = name; // ใช้ PName ตามที่เราแก้ไข Naming Conflict
                        card.PPrice = price;
                        card.PImgPath = imagePath;
                        card.PIsHot = isHot;
                        card.PIsCustom = false;

                        // 6. สั่งให้ Card แสดงผล และจัดการ Event Click
                        card.DisplayProductData();

                        // 7. นำ Card ไปแสดงใน FlowLayoutPanel
                        flpMenuContainer.Controls.Add(card);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading menu data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private void picCart_Click(object sender, EventArgs e)
        {
            FormMyCart cartForm = new FormMyCart();
            cartForm.ShowDialog(); // เปิดแบบ Modal เพื่อจัดการตะกร้า
        }

        private void picLogin_Click(object sender, EventArgs e)
        {
            // 1. ถามผู้ใช้เพื่อยืนยันการออกจากระบบ
            DialogResult confirm = MessageBox.Show("คุณต้องการออกจากระบบหรือไม่?", "ยืนยันการออกจากระบบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // 2. ล้างข้อมูลตะกร้า (ถ้ามี)
                CartManager.ClearCart();

                // 3. ปิด Form MainShop ปัจจุบัน
                this.Hide();

                // 4. เปิด FormLogin ขึ้นมาใหม่
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
            }
        }

      

        private void btnMenuSamret_Click(object sender, EventArgs e)
        {
          
                LoadMenuData(); // เมธอดเดิมที่คุณมีอยู่แล้ว
            
        }

        private void btnCustomMenu_Click(object sender, EventArgs e)
        {
            // 1. สร้าง Object ของ FormCustomOrder 
            FormCustomOrder customForm = new FormCustomOrder();

            // 2. ซ่อน Form MainShop 
            this.Hide();

            // 3. แสดง FormCustomOrder เป็น Dialog
            customForm.ShowDialog();

            // 4. แสดง Form MainShop กลับมาเมื่อ Dialog ปิด
            this.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // ตรวจสอบว่ามี Controls ใน FlowLayoutPanel หรือไม่
            if (flpMenuContainer.Controls.Count > 0)
            {
                string searchText = txtSearch.Text.Trim().ToLower();

                // 1. วนลูปผ่าน ProductCard แต่ละใบ
                foreach (Control control in flpMenuContainer.Controls)
                {
                    // 2. ตรวจสอบว่าเป็น ProductCard
                    if (control is ProductCard card)
                    {
                        // 3. กรองตาม PName (ชื่อเมนู)
                        if (string.IsNullOrEmpty(searchText) || card.PName.ToLower().Contains(searchText))
                        {
                            card.Visible = true; // แสดง
                        }
                        else
                        {
                            card.Visible = false; // ซ่อน
                        }
                    }
                }
            }
        }

        private void picOrderHistory_Click(object sender, EventArgs e)
        {
            // 1. ตรวจสอบการล็อกอิน
            if (Program.CurrentUserID <= 0)
            {
                MessageBox.Show("กรุณาเข้าสู่ระบบก่อนเพื่อดูประวัติการสั่งซื้อ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. สร้าง Object ของ FormOrderHistory 
            FormOrderHistory historyForm = new FormOrderHistory();

            // 3. *** แสดง Form แบบ Modal (บังคับให้ปิดก่อนใช้ MainShop) ***
            // ShowDialog() จะทำให้ MainShop ถูก "Lock" ไว้ชั่วคราว
            historyForm.ShowDialog(this);
        }

        private void btnUserProfile_Click(object sender, EventArgs e)
        {
            FormUserProfile profile = new FormUserProfile();
            profile.ShowDialog();
        }
    }
}
