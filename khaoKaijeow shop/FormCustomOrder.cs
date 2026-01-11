// FormCustomOrder.cs

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing; // อาจต้องเพิ่มถ้าใช้การจัดการ Control
using System.Linq;
using System.Windows.Forms;
using static khaokaijeow_shop.FormMyCart;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace khaokaijeow_shop
{
    public partial class FormCustomOrder : Form
    {
        // ตัวแปรสำหรับเมนูพื้นฐาน/เมนูที่ถูกปรับแต่ง (ต้องตั้งค่า ID พิเศษ 9999 ใน DB สำหรับเมนูใหม่)
        private int BaseProductID;
        private string BaseName;
        private decimal BasePrice;

        // รายการวัตถุดิบเสริมที่ถูกเลือก (ใช้เก็บข้อมูลก่อนรวมใน CartItem)
        private List<CartManager.CartItem> SelectedIngredients = new List<CartManager.CartItem>();

        // -----------------------------------------------------------
        // 1. Constructors
        // -----------------------------------------------------------

        // Constructor หลัก (สำหรับ "สร้างใหม่" จากปุ่ม เลือกวัตถุดิบเอง)
        public FormCustomOrder()
        {
            // *** โหลดข้อมูลเมนูหลักจาก DB โดยใช้ ID จริง (เช่น ID=1) ***
            LoadBaseProduct(1);


            InitializeComponent();
            LoadIngredients();

            // ตั้งค่า Label พื้นฐานเมื่อสร้างใหม่
            lblBaseMenu.Text = BaseName;
            UpdateSummary();
        }

        // Constructor สำหรับ "ปรับแต่ง" เมนูสำเร็จรูป (โค้ดเดิม)
        public FormCustomOrder(int id, string name, decimal price)
        {
            BaseProductID = id;
            BaseName = name;
            BasePrice = price;

            InitializeComponent();
            LoadIngredients();

            // ตั้งค่า Label พื้นฐาน
            lblBaseMenu.Text = BaseName;
            UpdateSummary();
        }

        // -----------------------------------------------------------
        // 2. Method สำหรับโหลดข้อมูลเมนูหลักจากฐานข้อมูล
        // -----------------------------------------------------------
        private void LoadBaseProduct(int menuId)
        {
            string sql = "SELECT menu_id, name, price FROM Menu WHERE menu_id = @id";

            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id", menuId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            BaseProductID = reader.GetInt32("menu_id");
                            BaseName = reader.GetString("name");
                            BasePrice = reader.GetDecimal("price");
                        }
                        else
                        {
                            // Fallback กรณีหา ID ไม่เจอ (ใช้ค่า Hardcode เดิม)
                            BaseProductID = 9999;
                            BaseName = "เมนูหลักไม่พบ (ID: " + menuId + ")";
                            BasePrice = 0.00m;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Fallback กรณี DB Error
                    MessageBox.Show("เกิดข้อผิดพลาดในการโหลดเมนูหลัก: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BaseProductID = 9999;
                    BaseName = "เมนูหลัก (DB Error)";
                    BasePrice = 0.00m;
                }
            }
        }

        // -----------------------------------------------------------
        // Data Loading
        // -----------------------------------------------------------

        private void LoadIngredients()
        {
            // ดึงข้อมูลวัตถุดิบเสริม (Custom Items) ทั้งหมด
            string sql = @"
                SELECT 
                    ci.item_id, ci.name, ci.price, ci.image_path, ci.category_id 
                FROM CustomItems ci
                ORDER BY ci.category_id, ci.item_id";

            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    flpIngredientsContainer.Controls.Clear();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32("item_id");
                        string name = reader.GetString("name");
                        decimal price = reader.GetDecimal("price");
                        string imagePath = reader.GetString("image_path");

                        // ใช้ ProductCard เพื่อแสดงวัตถุดิบแต่ละชิ้น
                        IngredientCard ingredientCard = new IngredientCard();

                        ingredientCard.IngID = id;
                        ingredientCard.IngName = name;
                        ingredientCard.IngPrice = price;
                        ingredientCard.IngImgPath = imagePath;

                        ingredientCard.DisplayIngredientData();

                        // *** ผูก Event: ต้องอ้างอิงถึงปุ่มจริงใน IngredientCard (btnAddIng) ***
                        ingredientCard.btnAddIng.Click += (sender, e) => IngredientCard_Click(ingredientCard); 

                        flpIngredientsContainer.Controls.Add(ingredientCard);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading ingredients: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // -----------------------------------------------------------
        // Logic: จัดการการเลือกวัตถุดิบ
        // -----------------------------------------------------------

        // เมธอดนี้ถูกเรียกเมื่อผู้ใช้คลิกปุ่ม Add to Cart บน ProductCard ของวัตถุดิบเสริม
        private void IngredientCard_Click(IngredientCard clickedCard)
        {
            // 1. ตรวจสอบสต็อกปัจจุบันใน DB
            // ใช้ ItemType = "Ingredient" เพื่อดึงข้อมูลจากตาราง CustomItems
            int currentStock = CartManager.GetCurrentStock(clickedCard.IngID, "Ingredient");

            // 2. ค้นหาว่าวัตถุดิบนี้ถูกเลือกไปแล้วหรือไม่
            var existingIngredient = SelectedIngredients.FirstOrDefault(i => i.ProductID == clickedCard.IngID);

            int totalDesiredQuantity; // จำนวนที่ต้องการรวมในตะกร้า

            if (existingIngredient != null)
            {
                // 3a. ถ้ามีอยู่แล้ว: คำนวณจำนวนใหม่
                totalDesiredQuantity = existingIngredient.Quantity + 1;
            }
            else
            {
                // 3b. ถ้ายังไม่มี: จำนวนที่ต้องการคือ 1
                totalDesiredQuantity = 1;
            }

            // 4. *** Logic ตรวจสอบสต็อก ***
            if (totalDesiredQuantity > currentStock)
            {
                MessageBox.Show($"ไม่สามารถเพิ่มได้: สต็อกของ '{clickedCard.IngName}' เหลือเพียง {currentStock} ชิ้น", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // *************************

            // 5. ถ้าผ่านการตรวจสอบ: อัปเดตรายการ
            if (existingIngredient != null)
            {
                existingIngredient.Quantity++;
            }
            else
            {
                // เพิ่มรายการใหม่
                SelectedIngredients.Add(new CartManager.CartItem
                {
                    ProductID = clickedCard.IngID,
                    Name = clickedCard.IngName,
                    UnitPrice = clickedCard.IngPrice,
                    Quantity = 1,
                    ItemType = "Ingredient",
                    CustomDetails = ""
                });
            }

            // 6. รีเฟรชข้อมูลสรุป
            UpdateSummary();
        }

        private void UpdateSummary()
        {
            // 1. คำนวณราคารวมวัตถุดิบเสริม
            decimal ingredientsTotal = SelectedIngredients.Sum(i => i.TotalPrice);
            decimal finalPrice = BasePrice + ingredientsTotal;

            // 2. ผูกข้อมูลเข้ากับ DataGrid สรุป
            dgvSelectedIngredients.DataSource = null;
            dgvSelectedIngredients.DataSource = SelectedIngredients.ToList();

            // *** โค้ดใหม่: ซ่อนคอลัมน์ที่ไม่ต้องการ และจัดรูปแบบ ***
            if (dgvSelectedIngredients.DataSource != null)
            {
                // คอลัมน์ที่ต้องการซ่อน (คอลัมน์ที่มาจาก CartItem Properties)
                string[] columnsToHide = 
                {
                  "ProductID",
                  "UnitPrice",
                  "ItemType",
                  "CustomDetails",
                   // คอลัมน์ที่เพิ่มใหม่สำหรับ VAT (คำนวณใน CartItem)
                  "NetPricePerUnit",
                  "TotalNetPrice",
                  "TotalTaxAmount"
                };

                foreach (string columnName in columnsToHide)
                {
                    if (dgvSelectedIngredients.Columns.Contains(columnName))
                    {
                        dgvSelectedIngredients.Columns[columnName].Visible = false;
                    }
                }

                // จัดรูปแบบคอลัมน์ที่โชว์ (ถ้ายังไม่ได้ทำ)
                if (dgvSelectedIngredients.Columns.Contains("TotalPrice"))
                {
                    dgvSelectedIngredients.Columns["TotalPrice"].DefaultCellStyle.Format = "N2";
                }

                // ปรับชื่อคอลัมน์ที่โชว์ (ถ้าคุณไม่ได้กำหนด HeaderText ใน Designer)
                if (dgvSelectedIngredients.Columns.Contains("Name"))
                {
                    dgvSelectedIngredients.Columns["Name"].HeaderText = "วัตถุดิบ";
                }
                if (dgvSelectedIngredients.Columns.Contains("Quantity"))
                {
                    dgvSelectedIngredients.Columns["Quantity"].HeaderText = "จำนวน";
                }

                // ตั้งค่าให้คอลัมน์วัตถุดิบยืดเต็มพื้นที่
                if (dgvSelectedIngredients.Columns.Contains("Name"))
                {
                    dgvSelectedIngredients.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            // *** สิ้นสุดโค้ดใหม่ ***

            // 3. อัปเดต Label สรุปยอดรวม 
            lblFinalPrice.Text = $"{finalPrice:N2} บาท";
        }

        // -----------------------------------------------------------
        // Logic: จัดการปุ่ม Add to Cart (ปุ่มใหญ่)
        // -----------------------------------------------------------

        private void btnAddToMainCart_Click(object sender, EventArgs e)
        {
            // 1. ตรวจสอบว่ามีวัตถุดิบหลักหรือไม่
            if (BaseProductID == 0)
            {
                MessageBox.Show("กรุณาเลือกเมนูหลัก (ข้าวไข่เจียว) ก่อน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. รวบรวมรายละเอียดวัตถุดิบเสริม
            List<string> details = SelectedIngredients.Select(i => $"{i.Name} x{i.Quantity}").ToList();
            decimal ingredientsTotal = SelectedIngredients.Sum(i => i.TotalPrice);

            // 3. สร้าง CartItem เดียว
            CartManager.CartItem customOrder = new CartManager.CartItem
            {
                ProductID = BaseProductID,
                Name = BaseName,
                UnitPrice = BasePrice + ingredientsTotal, // ราคารวมแม่+ลูก
                Quantity = 1,
                ItemType = (BaseProductID == 9999) ? "CustomNew" : "CustomizedMenu",

                // เก็บชื่อไว้โชว์ในใบเสร็จเหมือนเดิม
                CustomDetails = "เสริม: " + (details.Count > 0 ? string.Join(", ", details) : "ไม่มี"),

                SubIngredients = new List<CartManager.CartItem>(SelectedIngredients)
            };

            CartManager.AddItem(customOrder);

            MessageBox.Show($"เมนู '{BaseName}' ถูกเพิ่มเข้าตะกร้าแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        // -----------------------------------------------------------
        //  Logic: จัดการปุ่มใน DataGrid สรุป (สำหรับการลบ/ลดจำนวนวัตถุดิบ)
        // -----------------------------------------------------------

        private void dgvSelectedIngredients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. ตรวจสอบว่าคลิกที่แถวข้อมูลและคอลัมน์นั้นเป็นคอลัมน์ที่ถูกต้องหรือไม่
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var senderGrid = (DataGridView)sender;

            // *** การแก้ไข Error CS0023: ตรวจสอบว่าคอลัมน์ที่ถูกคลิก 'เป็น' DataGridViewButtonColumn หรือไม่ ***
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // ต้องมั่นใจว่า SelectedIngredients มีข้อมูลอยู่
                if (SelectedIngredients.Count <= e.RowIndex) return;

                var ingredient = SelectedIngredients[e.RowIndex];
                string columnName = senderGrid.Columns[e.ColumnIndex].Name;

                switch (columnName)
                {
                    case "ColSummaryDelete": // สมมติชื่อปุ่มลบรายการทั้งหมด (❌)
                        SelectedIngredients.RemoveAt(e.RowIndex);
                        break;

                    case "ColSummaryMinus": // สมมติชื่อปุ่มลดจำนวน (-)
                        if (ingredient.Quantity > 1)
                        {
                            ingredient.Quantity--;
                        }
                        else
                        {
                            // ถ้าเหลือ 1 ชิ้นและถูกกดลดจำนวน ให้ลบรายการออกไปเลย
                            SelectedIngredients.RemoveAt(e.RowIndex);
                        }
                        break;
                }

                // 2. รีเฟรชหน้าจอหลังจากมีการเปลี่ยนแปลง
                UpdateSummary();
            }
        }
    }
}