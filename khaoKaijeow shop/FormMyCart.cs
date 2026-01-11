using khaokaijeow_shop;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static khaokaijeow_shop.FormMyCart;


namespace khaokaijeow_shop
{
    

    public partial class FormMyCart : Form
    {
        
        private ReceiptData lastReceiptData;
        private PrintDocument pd = new PrintDocument();

        public FormMyCart()
        {
            InitializeComponent();
            LoadCartData();

            // ผูก Event PrintPage เมื่อ Form ถูกสร้าง
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            lblCustomDetails.AutoSize = true;
            lblCustomDetails.MaximumSize = new Size(350, 0);
        }

        // ====================================================================
        // I. Data Loading & DataGrid Interaction (โค้ดเดิม)
        // ====================================================================

        public void LoadCartData()
        {
            // 1. Unbind และ Bind ข้อมูลใหม่
            dgvCartItems.DataSource = null;
            dgvCartItems.DataSource = CartManager.Items.ToList();

            // 2. [แก้ไขใหม่] ซ่อนคอลัมน์ระบบที่ไม่จำเป็นต้องโชว์ลูกค้า
            string[] colsToHide = 
            {
                "ProductID",
                "ItemType",
                "CustomDetails",      // ซ่อนอันนี้ เพราะเราโชว์ด้านขวาแล้ว (ถ้าโชว์ในตารางมันจะยาวไป)
                "SubIngredients",     // ซ่อนลิสต์วัตถุดิบย่อย
                "NetPricePerUnit",    // ซ่อนราคาถอด VAT
                "TotalNetPrice",
                "TotalTaxAmount"
            };

            foreach (string colName in colsToHide)
            {
                if (dgvCartItems.Columns.Contains(colName))
                {
                    dgvCartItems.Columns[colName].Visible = false;
                }
            }

            // 3. [แก้ไขใหม่] เปลี่ยนชื่อหัวตารางเป็นภาษาไทย และจัดรูปแบบตัวเลข
            if (dgvCartItems.Columns.Contains("Name"))
            {
                dgvCartItems.Columns["Name"].HeaderText = "เมนู";
                dgvCartItems.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // ให้ชื่อเมนูยืดเต็มพื้นที่ที่เหลือ
            }

            if (dgvCartItems.Columns.Contains("UnitPrice"))
            {
                dgvCartItems.Columns["UnitPrice"].HeaderText = "ราคาต่อหน่วย";
                dgvCartItems.Columns["UnitPrice"].DefaultCellStyle.Format = "N2"; // ทศนิยม 2 ตำแหน่ง
                dgvCartItems.Columns["UnitPrice"].Width = 100;
                dgvCartItems.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvCartItems.Columns.Contains("Quantity"))
            {
                dgvCartItems.Columns["Quantity"].HeaderText = "จำนวน";
                dgvCartItems.Columns["Quantity"].Width = 60;
                dgvCartItems.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvCartItems.Columns.Contains("TotalPrice"))
            {
                dgvCartItems.Columns["TotalPrice"].HeaderText = "ราคารวม";
                dgvCartItems.Columns["TotalPrice"].DefaultCellStyle.Format = "N2";
                dgvCartItems.Columns["TotalPrice"].Width = 100;
                dgvCartItems.Columns["TotalPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // 4. อัปเดตยอดรวมด้านบน
            decimal total = CartManager.GetCartTotal();
            lblTotalPrice.Text = total.ToString("N2") + " บาท";
        }

        private void dgvCartItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (CartManager.Items.Count <= e.RowIndex) return;

                var cartItem = CartManager.Items[e.RowIndex];
                string columnName = senderGrid.Columns[e.ColumnIndex].Name;

                switch (columnName)
                {
                    case "ColPlus":
                        int currentStock = CartManager.GetCurrentStock(cartItem.ProductID, cartItem.ItemType);

                        // 2. ถ้าจำนวนในตะกร้า ยังน้อยกว่าสต็อกจริง -> ให้เพิ่มได้
                        if (cartItem.Quantity < currentStock)
                        {
                            cartItem.Quantity++;
                        }
                        else
                        {
                            // 3. ถ้าของหมดแล้ว แจ้งเตือน
                            MessageBox.Show($"สินค้า '{cartItem.Name}' เหลือเพียง {currentStock} ชิ้น ไม่สามารถเพิ่มได้อีก",
                                            "ของหมด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    case "ColMinus":
                        if (cartItem.Quantity > 1)
                        {
                            cartItem.Quantity--;
                        }
                        else
                        {
                            if (MessageBox.Show("ต้องการลบรายการนี้ออกจากตะกร้าหรือไม่?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                CartManager.Items.RemoveAt(e.RowIndex);
                            }
                        }
                        break;

                    case "ColDelete":
                        CartManager.Items.RemoveAt(e.RowIndex);
                        break;
                }
                LoadCartData();
            }
        }

        // ====================================================================
        // II. Checkout & Database Transaction Logic
        // ====================================================================

        private bool SaveOrderToDatabase(out long orderId, string slipFileName)
        {
            decimal totalOrderVAT = CartManager.Items.Sum(item => item.TotalTaxAmount);


            orderId = 0;
            using (MySql.Data.MySqlClient.MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                connection.Open();
                MySql.Data.MySqlClient.MySqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // 1. INSERT INTO Orders (Order Header)
                    string orderSql = "INSERT INTO Orders (user_id, order_time, total_price, total_vat, status, payment_slip) VALUES (@uid, NOW(), @total, @totalvat, 'Completed', @slipFileName); SELECT LAST_INSERT_ID();";

                    MySqlCommand orderCmd = new MySqlCommand(orderSql, connection, transaction);

                    orderCmd.Parameters.AddWithValue("@uid", Program.CurrentUserID);
                    orderCmd.Parameters.AddWithValue("@total", CartManager.GetCartTotal());
                    orderCmd.Parameters.AddWithValue("@totalvat", totalOrderVAT);
                    orderCmd.Parameters.AddWithValue("@slipFileName", slipFileName);

                    // ดึงค่า Order ID อย่างปลอดภัย
                    object result = orderCmd.ExecuteScalar();

                    if (result != null)
                    {
                        if (long.TryParse(result.ToString(), out long generatedId))
                        {
                            orderId = generatedId;
                        }
                        else
                        {
                            throw new InvalidCastException("Failed to convert LAST_INSERT_ID to long.");
                        }
                    }
                    else
                    {
                        throw new Exception("Failed to retrieve LAST_INSERT_ID.");
                    }

                    // 2. ประกาศตัวแปร detailSql (แก้ CS0103)
                    string detailSql = "INSERT INTO OrderDetails (order_id, product_id, product_name, quantity, price_at_sale, net_price_at_sale, item_type, custom_details) VALUES (@oid, @iid, @name, @qty, @price_inc, @price_net, @type, @details)";


                    foreach (var item in CartManager.Items)
                    {
                        // A. บันทึก Order Details
                        MySqlCommand detailCmd = new MySqlCommand(detailSql, connection, transaction);

                        detailCmd.Parameters.AddWithValue("@oid", orderId);
                        detailCmd.Parameters.AddWithValue("@iid", item.ProductID);
                        detailCmd.Parameters.AddWithValue("@name", item.Name);
                        detailCmd.Parameters.AddWithValue("@qty", item.Quantity);
                        detailCmd.Parameters.AddWithValue("@price_inc", item.UnitPrice);
                        detailCmd.Parameters.AddWithValue("@price_net", item.NetPricePerUnit);
                        detailCmd.Parameters.AddWithValue("@type", item.ItemType);
                        detailCmd.Parameters.AddWithValue("@details", item.CustomDetails);

                        detailCmd.ExecuteNonQuery();

                        // B. *** หักสต็อกสินค้า (Stock Deduction Logic) ***
                        string updateStockSql = "";

                        // ตรวจสอบว่าเป็นสินค้าจากตาราง Menu หรือ CustomItems
                        if (item.ItemType == "Menu" || item.ItemType == "CustomizedMenu")
                        {
                            updateStockSql = "UPDATE Menu SET stock = stock - @qty WHERE menu_id = @idParam AND stock >= @qty";
                        }
                        else if (item.ItemType == "Ingredient" || item.ItemType == "CustomNew")
                        {
                            updateStockSql = "UPDATE CustomItems SET stock = stock - @qty WHERE item_id = @idParam AND stock >= @qty";
                        }

                        // รันคำสั่ง UPDATE ถ้ามี SQL Query ที่เหมาะสม
                        if (!string.IsNullOrEmpty(updateStockSql))
                        {
                            MySqlCommand stockCmd = new MySqlCommand(updateStockSql, connection, transaction);
                            stockCmd.Parameters.AddWithValue("@qty", item.Quantity);
                            stockCmd.Parameters.AddWithValue("@idParam", item.ProductID);
                            stockCmd.ExecuteNonQuery();
                        }

                        if (item.SubIngredients != null && item.SubIngredients.Count > 0)
                        {
                            foreach (var subItem in item.SubIngredients)
                            {
                                // 1. คำนวณจำนวนที่ต้องใช้จริง (เช่น สั่งข้าวไข่เจียว 2 จาน x หมูสับจานละ 1 = ต้องตัด 2)
                                int totalSubQty = subItem.Quantity * item.Quantity;

                                // 2. บันทึกลงตาราง OrderDetails (เพื่อให้ยอดขายวัตถุดิบไปโผล่ในหน้า Admin)
                                MySqlCommand subDetailCmd = new MySqlCommand(detailSql, connection, transaction);
                                subDetailCmd.Parameters.AddWithValue("@oid", orderId);
                                subDetailCmd.Parameters.AddWithValue("@iid", subItem.ProductID);
                                subDetailCmd.Parameters.AddWithValue("@name", subItem.Name); // ชื่อหมูสับ/กุ้ง
                                subDetailCmd.Parameters.AddWithValue("@qty", totalSubQty);
                                subDetailCmd.Parameters.AddWithValue("@price_inc", subItem.UnitPrice);
                                subDetailCmd.Parameters.AddWithValue("@price_net", subItem.NetPricePerUnit);
                                subDetailCmd.Parameters.AddWithValue("@type", "Ingredient"); // ระบุ Type ให้ชัดเจน
                                subDetailCmd.Parameters.AddWithValue("@details", "");
                                subDetailCmd.ExecuteNonQuery();

                                // 3. ตัดสต็อกวัตถุดิบในตาราง CustomItems
                                string subStockSql = "UPDATE CustomItems SET stock = stock - @qty WHERE item_id = @idParam AND stock >= @qty";

                                MySqlCommand subStockCmd = new MySqlCommand(subStockSql, connection, transaction);
                                subStockCmd.Parameters.AddWithValue("@qty", totalSubQty);
                                subStockCmd.Parameters.AddWithValue("@idParam", subItem.ProductID);

                                int rows = subStockCmd.ExecuteNonQuery();
                                if (rows == 0)
                                {
                                    // ถ้าตัดไม่ได้แปลว่าของหมด
                                    throw new Exception($"วัตถุดิบ '{subItem.Name}' มีไม่พอในสต็อก!");
                                }
                            }
                        }


                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกรายการ: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (CartManager.Items.Count == 0)
            {
                MessageBox.Show("ไม่มีสินค้าในตะกร้า!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = CartManager.GetCartTotal();
            long newOrderId = 0;

            using (FormPayment paymentForm = new FormPayment(total))
            {
                if (paymentForm.ShowDialog() == DialogResult.OK)
                {
                    string slipFileName = paymentForm.SavedSlipFileName;

                    if (SaveOrderToDatabase(out newOrderId, slipFileName))
                    {
                        string custName = "ลูกค้าทั่วไป";
                        string custAddress = "-";
                        string custPhone = "-";

                        using (MySqlConnection conn = Program.DbGlobalConnector.GetConnection())
                        {
                            try
                            {
                                conn.Open();
                                // ดึงชื่อ, นามสกุล, ที่อยู่, เบอร์โทร 
                                string sqlUser = "SELECT first_name, last_name, address, phone_number FROM Users WHERE id = @uid";
                                MySqlCommand cmdUser = new MySqlCommand(sqlUser, conn);
                                cmdUser.Parameters.AddWithValue("@uid", Program.CurrentUserID);

                                using (MySqlDataReader rdr = cmdUser.ExecuteReader())
                                {
                                    if (rdr.Read())
                                    {
                                        string fname = rdr["first_name"].ToString();
                                        string lname = rdr["last_name"].ToString();
                                        custName = $"{fname} {lname}";

                                        custAddress = rdr["address"].ToString();
                                        if (string.IsNullOrEmpty(custAddress)) custAddress = "-";

                                        custPhone = rdr["phone_number"].ToString();
                                        if (string.IsNullOrEmpty(custPhone)) custPhone = "-";
                                    }
                                }
                            }
                            catch { /* ถ้า Error ก็ปล่อยเป็นค่า default ไป */ }
                        }

                        lastReceiptData = new ReceiptData
                        {
                            Items = CartManager.Items.ToList(),
                            Total = total,
                            OrderId = newOrderId,
                            Date = DateTime.Now,

                            CustomerName = custName,
                            Address = custAddress,
                            PhoneNumber = custPhone
                        };

                        // 2. ล้างตะกร้าและแสดงผล
                        CartManager.ClearCart();
                        LoadCartData();

                        // 3. แสดงใบเสร็จ Print Preview
                        PrintReceipt();

                        MessageBox.Show($"ชำระเงินสำเร็จ! Order ID: {newOrderId}", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void btnContinueShopping_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ====================================================================
        // III. Receipt Printing Logic
        // ====================================================================

        private void PrintReceipt()
        {
            PaperSize pkCustomSize = new PaperSize("Receipt", 400, 1000);
            PageSettings pgSettings = new PageSettings();
            pgSettings.PaperSize = pkCustomSize;
            pgSettings.Margins = new Margins(0, 0, 0, 0);

            PrinterSettings ps = new PrinterSettings();
            pd.DefaultPageSettings = pgSettings;
            pd.PrinterSettings = ps;

            PrintPreviewDialog printPreview = new PrintPreviewDialog();
            printPreview.Document = pd;

            ((Form)printPreview).WindowState = FormWindowState.Maximized;
            printPreview.ShowDialog(this);
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (lastReceiptData == null) return;

            // *** ประกาศ Font ภายในเมธอด (แก้ Error CS0103) ***
            Font titleFont = new Font("TH SarabunPSK", 24, FontStyle.Bold);
            Font headerFont = new Font("TH SarabunPSK", 16, FontStyle.Bold);
            Font bodyFont = new Font("TH SarabunPSK", 14);
            Font smallBodyFont = new Font("TH SarabunPSK", 12);

            float yPos = 0;
            float leftMargin = 20;
            float topMargin = 20;

            float contentWidth = 360;
            float rightAlignPos = 380;

            // --- วาด Header ---
            StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat rightFormat = new StringFormat { Alignment = StringAlignment.Far };

            // ---  ส่วนหัว ---
            e.Graphics.DrawString("ร้านข้าวไข่เจียว", headerFont, Brushes.Black, new RectangleF(leftMargin, topMargin, contentWidth, 30), centerFormat);
            yPos = topMargin + headerFont.GetHeight(e.Graphics);

            e.Graphics.DrawString($"เลขผู้เสียภาษี: {lastReceiptData.TaxId}", smallBodyFont, Brushes.Black, new RectangleF(leftMargin, yPos, contentWidth, 20), centerFormat);
            yPos += smallBodyFont.GetHeight(e.Graphics);

            e.Graphics.DrawString("ที่อยู่ร้าน: 123/1 ถ.มิตรภาพ อ.ในเมือง จ.ขอนแก่น", smallBodyFont, Brushes.Black, new RectangleF(leftMargin, yPos, contentWidth, 20), centerFormat);
            yPos += smallBodyFont.GetHeight(e.Graphics) + 10;

            e.Graphics.DrawString("ใบเสร็จรับเงิน (Receipt)", headerFont, Brushes.Black, new RectangleF(leftMargin, yPos, contentWidth, 30), centerFormat);
            yPos += headerFont.GetHeight(e.Graphics) + 10;

            // ---  ข้อมูลลูกค้า ---
            e.Graphics.DrawString($"Order ID: {lastReceiptData.OrderId}", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += bodyFont.GetHeight(e.Graphics);

            e.Graphics.DrawString($"ลูกค้า: {lastReceiptData.CustomerName}", bodyFont, Brushes.Black, leftMargin, yPos);
            yPos += bodyFont.GetHeight(e.Graphics);

            e.Graphics.DrawString($"ที่อยู่: {lastReceiptData.Address}", smallBodyFont, Brushes.Black, leftMargin, yPos);
            yPos += smallBodyFont.GetHeight(e.Graphics);

            e.Graphics.DrawString($"โทร: {lastReceiptData.PhoneNumber}", smallBodyFont, Brushes.Black, leftMargin, yPos);
            yPos += smallBodyFont.GetHeight(e.Graphics);

           

            // --- เส้นคั่น ---
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, rightAlignPos, yPos);
            yPos += 5;

            // --- รายการสินค้า ---
       
            foreach (var item in lastReceiptData.Items)
            {
                // 1. รายการสินค้าหลัก (ชื่อ + จำนวน)
                e.Graphics.DrawString($"{item.Quantity} x {item.Name}", bodyFont, Brushes.Black, leftMargin, yPos);
                e.Graphics.DrawString($"{item.TotalPrice:N2}", bodyFont, Brushes.Black, rightAlignPos, yPos, rightFormat);
                yPos += bodyFont.GetHeight(e.Graphics);

                // 2. รายละเอียดวัตถุดิบเสริม (CustomDetails)
                if (!string.IsNullOrEmpty(item.CustomDetails) && item.CustomDetails != "เสริม: ไม่มี")
                {
                    string detailText = $"  - {item.CustomDetails}";

                    // กำหนดความกว้างสูงสุดที่จะให้พิมพ์ได้ 
                    float maxTextWidth = 260;

                    // คำนวณความสูงที่ต้องใช้จริง (ว่าข้อความนี้ต้องใช้กี่บรรทัด)
                    SizeF textSize = e.Graphics.MeasureString(detailText, smallBodyFont, (int)maxTextWidth);

                    // สร้างกรอบสี่เหลี่ยมสำหรับวาดข้อความ
                    RectangleF textRect = new RectangleF(leftMargin + 10, yPos, maxTextWidth, textSize.Height);

                    // สั่งวาดข้อความลงในกรอบ (มันจะตัดคำให้อัตโนมัติ)
                    e.Graphics.DrawString(detailText, smallBodyFont, Brushes.Gray, textRect);

                    // บวกตำแหน่งแกน Y เพิ่มตามความสูงที่ใช้จริง
                    yPos += textSize.Height;
                }
            }
            // --- เส้นคั่น ---
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, rightAlignPos, yPos);
            yPos += 5;

            // --- ยอดรวม ---
            decimal netTotal = lastReceiptData.Items.Sum(i => i.TotalNetPrice);
            decimal taxTotal = lastReceiptData.Items.Sum(i => i.TotalTaxAmount);

            // ยอดรวมก่อน VAT
            e.Graphics.DrawString("รวมเป็นเงิน", bodyFont, Brushes.Black, leftMargin, yPos);
            e.Graphics.DrawString($"{netTotal:N2}", bodyFont, Brushes.Black, rightAlignPos, yPos, rightFormat);
            yPos += bodyFont.GetHeight(e.Graphics);

            // VAT
            e.Graphics.DrawString("ภาษีมูลค่าเพิ่ม 7%", bodyFont, Brushes.Black, leftMargin, yPos);
            e.Graphics.DrawString($"{taxTotal:N2}", bodyFont, Brushes.Black, rightAlignPos, yPos, rightFormat);
            yPos += bodyFont.GetHeight(e.Graphics);

            // ยอดสุทธิ (ตัวหนา)
            e.Graphics.DrawString("ยอดรวมสุทธิ", headerFont, Brushes.Black, leftMargin, yPos);
            e.Graphics.DrawString($"{lastReceiptData.Total:N2}", headerFont, Brushes.Black, rightAlignPos, yPos, rightFormat);
            yPos += headerFont.GetHeight(e.Graphics) + 20;

            // --- Footer ---
            e.Graphics.DrawString($"วันที่ {lastReceiptData.Date:dd-MM-yyyy HH:mm:ss}", smallBodyFont, Brushes.Black, new RectangleF(leftMargin, yPos, contentWidth, 30), centerFormat);
            yPos += smallBodyFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("ขอบคุณที่ใช้บริการครับ", bodyFont, Brushes.Black, new RectangleF(leftMargin, yPos, contentWidth, 30), centerFormat);
        }

        private void DisplaySelectedProductImage(int menuId)
        {

            if (menuId <= 0) return;

            // Query เพื่อดึง image_path จากตาราง Menu
            string sql = "SELECT image_path FROM Menu WHERE menu_id = @id";

            using (MySql.Data.MySqlClient.MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id", menuId);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        string imagePath = result.ToString();

                        // ตรวจสอบว่าไฟล์มีอยู่จริงก่อนโหลด
                        if (System.IO.File.Exists(imagePath))
                        {
                            // โหลดภาพจาก Path โดยใช้ FileStream เพื่อป้องกันการ Lock ไฟล์
                            using (var stream = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                            {
                                // Clone ภาพออกจาก Stream เพื่อให้ Stream ปิดได้ทันที
                                picSelectedItem.Image = System.Drawing.Image.FromStream(stream);
                            }
                        }
                        else
                        {
                            picSelectedItem.Image = null; // ถ้าไม่พบไฟล์ให้เคลียร์ภาพ
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading product image: " + ex.Message, "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCartItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ตรวจสอบว่าคลิกที่แถวข้อมูล (ไม่ใช่ Header) และแถวมีอยู่จริงใน CartManager
            if (e.RowIndex >= 0 && CartManager.Items.Count > e.RowIndex)
            {
                // 1. ดึง CartItem จากแถวที่เลือก
                var selectedItem = CartManager.Items[e.RowIndex];

                // 2. แสดงชื่อเมนูที่เลือก (โค้ดเดิม)
                lblSelectedItemName.Text = selectedItem.Name;

                // 3. *** โค้ดใหม่: แสดงรายละเอียดวัตถุดิบเสริม ***
                // ถ้าไม่มีรายละเอียด (เช่น "เสริม: ไม่มี") ให้แสดงข้อความที่เหมาะสม
                string details = selectedItem.CustomDetails;
                lblCustomDetails.Text = details.Replace("เสริม: ", "เสริม: \n"); // เพิ่มบรรทัดใหม่ให้รายละเอียด

                // 4. เรียกเมธอดแสดงภาพ (โค้ดเดิม)
                DisplaySelectedProductImage(selectedItem.ProductID);
            }
            else
            {
                // หากคลิกที่ Header หรือคลิกนอกแถว ให้เคลียร์ข้อมูล
                lblSelectedItemName.Text = "-- ยังไม่มีรายการที่เลือก --";
                lblCustomDetails.Text = "-- ไม่มีรายละเอียดวัตถุดิบเสริม --"; // *** เคลียร์ Label ใหม่นี้ด้วย ***
                picSelectedItem.Image = null;
            }
        }

 

        private void lblCustomDetails_Click(object sender, EventArgs e)
        {

        }
    }
}


// *** 1. คลาสข้อมูลใบเสร็จ (ReceiptData) ถูกประกาศไว้ข้างนอกคลาสหลักอย่างปลอดภัย ***
public class ReceiptData
{
    public List<CartManager.CartItem> Items { get; set; }
    public decimal Total { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public long OrderId { get; set; }

    public string CustomerName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string TaxId { get; set; } = "1234567890123";
}

public static class CartManager
{
    public class CartItem
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ItemType { get; set; }
        public string CustomDetails { get; set; }

        public List<CartItem> SubIngredients { get; set; } = new List<CartItem>();

        public decimal TotalPrice => UnitPrice * Quantity;
        public decimal NetPricePerUnit => Math.Round(UnitPrice / 1.07m, 2, MidpointRounding.AwayFromZero);
        public decimal TotalNetPrice => NetPricePerUnit * Quantity;
        public decimal TotalTaxAmount => TotalPrice - TotalNetPrice;
    }

    public static List<CartItem> Items { get; set; } = new List<CartItem>();

    // *** โค้ดที่แก้ไข: เปลี่ยน return type เป็น bool (true=สำเร็จ) ***
    public static bool AddItem(CartItem newItem)
    {
        // 1. ตรวจสอบสต็อกปัจจุบันใน DB
        int currentStock = GetCurrentStock(newItem.ProductID, newItem.ItemType);

        // ถ้าสต็อกเป็น 0 ห้ามเพิ่ม
        if (currentStock <= 0)
        {
            MessageBox.Show($"สินค้า '{newItem.Name}' หมดสต็อกแล้ว", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        var existingItem = Items.FirstOrDefault(item =>
            item.ProductID == newItem.ProductID &&
            item.ItemType == newItem.ItemType &&
            item.CustomDetails == newItem.CustomDetails);

        if (existingItem != null)
        {
            // 2. ถ้ามีอยู่แล้ว: ตรวจสอบว่าเพิ่มแล้วเกินสต็อกหรือไม่
            if (existingItem.Quantity + newItem.Quantity > currentStock)
            {
                MessageBox.Show($"ไม่สามารถเพิ่มได้: สต็อกเหลือเพียง {currentStock} ชิ้น", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            existingItem.Quantity += newItem.Quantity;
        }
        else
        {
            // 3. ถ้ายังไม่มี: ตรวจสอบว่าปริมาณที่ต้องการ (1) เกินสต็อกหรือไม่
            if (newItem.Quantity > currentStock)
            {
                MessageBox.Show($"ไม่สามารถเพิ่มได้: สต็อกเหลือเพียง {currentStock} ชิ้น", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            Items.Add(newItem);
        }

        return true; // เพิ่มสำเร็จ
    }

    public static decimal GetCartTotal()
    {
        return Items.Sum(item => item.TotalPrice);
    }

    public static void ClearCart()
    {
        Items.Clear();
    }

    // *** โค้ด GetCurrentStock ที่เพิ่มไว้ก่อนหน้านี้ (ใช้สำหรับตรวจสอบ) ***
    public static int GetCurrentStock(int productId, string itemType)
    {
        string tableName = "";
        string idColumn = "";

        // กำหนดตารางที่จะตรวจสอบตาม ItemType
        if (itemType == "Menu" || itemType == "CustomizedMenu")
        {
            tableName = "Menu";
            idColumn = "menu_id";
        }
        else if (itemType == "Ingredient" || itemType == "CustomNew")
        {
            tableName = "CustomItems";
            idColumn = "item_id";
        }

        if (string.IsNullOrEmpty(tableName)) return 0;

        string sql = $"SELECT stock FROM {tableName} WHERE {idColumn} = @id";

        using (MySql.Data.MySqlClient.MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
        {
            try
            {
                connection.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", productId);

                object result = cmd.ExecuteScalar();
                return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking stock: " + ex.Message);
                return 0;
            }
        }
    }
}