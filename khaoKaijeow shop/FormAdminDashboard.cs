using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace khaokaijeow_shop
{
    public partial class FormAdminDashboard : Form
    {

        private string currentMode = "Menu";
        private string newImagePath = "";
        private string originalImagePath = "";

        public FormAdminDashboard()
        {
            InitializeComponent();
            LoadMenuDataGrid(); 
            LoadCategories();

            txtNewCategoryName.Visible = false;
            btnAddCategory.Visible = false;
        }

        public void LoadMenuDataGrid()
        {
            // 1. กำหนด SQL Query
            string sql = "SELECT menu_id, name, price, stock, image_path FROM Menu ORDER BY menu_id";

            // 2. ดึง Connection Object จาก Global Connector
            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    connection.Open();

                    // 3. ใช้ MySqlDataAdapter เพื่อโหลดข้อมูลทั้งหมดเข้า DataTable
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataTable menuTable = new DataTable();
                    adapter.Fill(menuTable);

                    // 4. ผูกข้อมูลเข้ากับ DataGridView
                    dgvMenu.DataSource = menuTable;

                    // 5. ปรับแต่งคอลัมน์
                    dgvMenu.Columns["menu_id"].HeaderText = "รหัสสินค้า";
                    dgvMenu.Columns["name"].HeaderText = "ชื่อเมนู";
                    dgvMenu.Columns["price"].HeaderText = "ราคา (บาท)";
                    dgvMenu.Columns["stock"].HeaderText = "คงเหลือ";

                    dgvMenu.Columns["image_path"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading menu data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvMenu.Rows[e.RowIndex];
            string imagePath = ""; // ประกาศตัวแปร Path รูปภาพไว้ด้านนอก

            if (currentMode == "Menu")
            {
                // === 1. โหมดเมนูสำเร็จ ===
                txtMenuID.Text = row.Cells["menu_id"].Value.ToString();
                txtMenuName.Text = row.Cells["name"].Value.ToString();
                txtMenuPrice.Text = row.Cells["price"].Value.ToString();
                txtMenuStock.Text = row.Cells["stock"].Value.ToString();

                imagePath = row.Cells["image_path"].Value.ToString();

                // ซ่อน ComboBox ของ Custom
                cmbCategory.Visible = false;
            }
            else if (currentMode == "Custom")
            {
                // === 2. โหมดวัตถุดิบเลือกเอง ===
                txtMenuID.Text = row.Cells["item_id"].Value.ToString(); // << แก้ไขเป็น item_id
                txtMenuName.Text = row.Cells["name"].Value.ToString();
                txtMenuPrice.Text = row.Cells["price"].Value.ToString();
                txtMenuStock.Text = row.Cells["stock"].Value.ToString();

                imagePath = row.Cells["image_path"].Value.ToString();
                cmbCategory.SelectedValue = row.Cells["category_id"].Value;

                originalImagePath = imagePath;

                cmbCategory.Visible = true;
            }

            // === 3. Logic โหลดรูปภาพ (ใช้ร่วมกัน) ===
            try
            {
                if (File.Exists(imagePath))
                {
                    picMenuImage.Image = Image.FromFile(imagePath);
                }
                else
                {
                    picMenuImage.Image = null;
                }
            }
            catch (Exception ex)
            {
                picMenuImage.Image = null;
                MessageBox.Show("ข้อผิดพลาดในการโหลดรูปภาพ: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // === 4. ตั้งสถานะปุ่ม (ใช้ร่วมกัน) ===
            btnSaveMenu.Enabled = true;
            btnDeleteMenu.Enabled = true;
            btnAddMenu.Enabled = false;
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            // 1. เคลียร์ฟอร์มและรีเซ็ตสถานะปุ่ม
            ResetEditFormState();

            // 2. เปลี่ยนสถานะปุ่มเพื่อเข้าสู่โหมด "เพิ่มใหม่"
            btnSaveMenu.Text = "บันทึกเมนูใหม่"; // เปลี่ยน Text เพื่อบ่งบอกสถานะ INSERT
            btnAddMenu.Enabled = false;           // ปิดปุ่ม "เพิ่ม" เมื่ออยู่ในโหมดเพิ่ม
            btnSaveMenu.Enabled = true;           // เปิดปุ่มบันทึก

            // 3. จัดการ ComboBox สำหรับโหมด Custom
            if (currentMode == "Custom")
            {
                cmbCategory.Enabled = true;
                
            }

            // 4. โฟกัสไปที่ช่องกรอกชื่อ
            txtMenuName.Focus();
        }

        private void btnSaveMenu_Click(object sender, EventArgs e)
        {

            // 1. === ประกาศตัวแปรทั้งหมดไว้ด้านบนสุดของ Method ===
            string itemID = txtMenuID.Text.Trim();
            string itemName = txtMenuName.Text.Trim();
            string price = txtMenuPrice.Text.Trim();
            string stock = txtMenuStock.Text.Trim();

            // ประกาศตัวแปร Logic
            bool isUpdate = !string.IsNullOrEmpty(itemID);
            string sql = "";
            string tableName = "";
            string finalImagePath = "";
            decimal itemPrice;
            int itemStock;

            // 2. ดึงข้อมูลจาก TextBoxes และทำการ Validation เบื้องต้น
            if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(price) || string.IsNullOrEmpty(stock))
            {
                MessageBox.Show("กรุณากรอก ชื่อ, ราคา, และจำนวนสต็อกให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(price, out itemPrice) || !int.TryParse(stock, out itemStock))
            {
                MessageBox.Show("ราคาและจำนวนสต็อกต้องเป็นตัวเลขที่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. === โค้ดจัดการรูปภาพ (คัดลอกไฟล์และกำหนด finalImagePath) ===

            if (!string.IsNullOrEmpty(newImagePath)) // ถ้ามีการเลือกรูปใหม่
            {
                // 3a. ตรวจสอบและสร้างโฟลเดอร์ Resources (แก้ปัญหา 'Could not find path')
                string resourceDirectory = System.IO.Path.Combine(Application.StartupPath, "Resources");
                if (!System.IO.Directory.Exists(resourceDirectory))
                {
                    System.IO.Directory.CreateDirectory(resourceDirectory);
                }

                // 3b. สร้างชื่อไฟล์ใหม่ (ใช้ ID/GUID)
                string fileName = (isUpdate ? itemID : Guid.NewGuid().ToString()) + "_" + System.IO.Path.GetFileName(newImagePath);
                string destinationPath = System.IO.Path.Combine(resourceDirectory, fileName);

                try
                {
                    System.IO.File.Copy(newImagePath, destinationPath, true);
                    finalImagePath = destinationPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ไม่สามารถคัดลอกไฟล์รูปภาพได้: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // ถ้าไม่ได้เลือกรูปใหม่: ดึง Path เก่าจาก DataGridView เพื่อใช้ในการ UPDATE
                if (isUpdate)
                {
                    finalImagePath = originalImagePath;
                }
                else
                {
                    // สำหรับ INSERT ใหม่ที่ยังไม่มีรูปภาพ (placeholder)
                    finalImagePath = "placeholder_path";
                }
            }

            // 4. === กำหนด SQL Query และ Logic ตามโหมดปัจจุบัน ===

            if (currentMode == "Custom")
            {
                tableName = "CustomItems";
                int categoryID = Convert.ToInt32(cmbCategory.SelectedValue);

                if (isUpdate)
                {
                    sql = $"UPDATE {tableName} SET name = @name, price = @price, stock = @stock, category_id = @categoryId, image_path = @imagePath WHERE item_id = @id";
                }
                else // INSERT NEW CUSTOM ITEM
                {
                    sql = $"INSERT INTO {tableName} (name, price, stock, category_id, image_path) VALUES (@name, @price, @stock, @categoryId, @imagePath)";
                }
                // [เพิ่ม Logic การจัดการ categoryID ใน Parameters]
            }
            else // Mode == "Menu"
            {
                tableName = "Menu";
                if (isUpdate)
                {
                    sql = $"UPDATE {tableName} SET name = @name, price = @price, stock = @stock, image_path = @imagePath WHERE menu_id = @id";
                }
                else // INSERT NEW MENU ITEM
                {
                    sql = $"INSERT INTO {tableName} (name, price, stock, image_path, is_hot) VALUES (@name, @price, @stock, @imagePath, 0)";
                }
            }

            // 5. เชื่อมต่อและรัน Query
            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, connection);

                    // 6. กำหนดค่า Parameters
                    if (isUpdate)
                    {
                        cmd.Parameters.AddWithValue("@id", itemID);
                    }

                    cmd.Parameters.AddWithValue("@name", itemName);
                    cmd.Parameters.AddWithValue("@price", itemPrice);
                    cmd.Parameters.AddWithValue("@stock", itemStock);
                    cmd.Parameters.AddWithValue("@imagePath", finalImagePath);

                    if (currentMode == "Custom")
                    {
                        cmd.Parameters.AddWithValue("@categoryId", Convert.ToInt32(cmbCategory.SelectedValue));
                    }

                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"บันทึกข้อมูล {tableName} สำเร็จ!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 7. โหลดข้อมูล DataGridView ใหม่ และรีเซ็ตฟอร์ม
                    if (currentMode == "Custom")
                    {
                        LoadCustomDataGrid();
                    }
                    else
                    {
                        LoadMenuDataGrid();
                    }
                    ResetEditFormState();

                    newImagePath = "";
                    originalImagePath = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ResetEditFormState()
        {
            // ล้าง TextBoxes
            txtMenuID.Clear();
            txtMenuName.Clear();
            txtMenuPrice.Clear();
            txtMenuStock.Clear();

            // โค้ดสำหรับ picMenuImage.Image = null; 
            picMenuImage.Image = null;
            newImagePath = "";
            originalImagePath = "";

            // รีเซ็ตสถานะปุ่ม (กลับสู่สถานะที่ไม่เลือกรายการ)
            btnAddMenu.Enabled = true; 
            btnSaveMenu.Enabled = false;
            btnDeleteMenu.Enabled = false;
            btnSaveMenu.Text = "บันทึก/แก้ไข";
        }

        private void btnDeleteMenu_Click(object sender, EventArgs e)
        {
            string itemID = txtMenuID.Text.Trim();

            // 1. ตรวจสอบ ID และยืนยันการลบ
            if (string.IsNullOrEmpty(itemID))
            {
                MessageBox.Show("กรุณาเลือกรายการที่ต้องการลบก่อน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tableName = (currentMode == "Custom") ? "CustomItems" : "Menu";
            string idColumn = (currentMode == "Custom") ? "item_id" : "menu_id";

            DialogResult confirm = MessageBox.Show($"คุณแน่ใจหรือไม่ที่จะลบรายการ ID: {itemID} จากตาราง {tableName}?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
            {
                return;
            }

            // 2. กำหนด SQL Query (DELETE)
            string sql = $"DELETE FROM {tableName} WHERE {idColumn} = @id";

            // 3. เชื่อมต่อและรัน Query
            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, connection);

                    // 4. กำหนดค่า Parameter
                    cmd.Parameters.AddWithValue("@id", itemID);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("ลบรายการสำเร็จ!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. โหลดข้อมูล DataGridView ใหม่ และรีเซ็ตฟอร์ม
                    if (currentMode == "Custom")
                    {
                        LoadCustomDataGrid();
                    }
                    else
                    {
                        LoadMenuDataGrid();
                    }
                    ResetEditFormState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการลบข้อมูล: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        public void LoadCategories()
        {
            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    string sql = "SELECT category_id, name FROM Categories ORDER BY name";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // กำหนดค่าให้กับ ComboBox
                    cmbCategory.DisplayMember = "name";     // สิ่งที่แสดงให้ผู้ใช้เห็น
                    cmbCategory.ValueMember = "category_id"; // ค่าที่ใช้ในการบันทึกเข้า DB
                    cmbCategory.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading categories: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void LoadCustomDataGrid()
        {
            string sql = @"
        SELECT 
            ci.item_id, ci.name, ci.price, ci.stock, c.name AS category_name, ci.category_id,
            ci.image_path 
        FROM CustomItems ci
        INNER JOIN Categories c ON ci.category_id = c.category_id
        ORDER BY ci.item_id";

            // 2. ดึง Connection Object
            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataTable customTable = new DataTable();
                    adapter.Fill(customTable);

                    // 3. ผูกข้อมูลเข้ากับ DataGridView ตัวเดิม
                    dgvMenu.DataSource = customTable;

                    // 4. ปรับแต่งคอลัมน์สำหรับโหมด Custom
                    dgvMenu.Columns["item_id"].HeaderText = "รหัสวัตถุดิบ";
                    dgvMenu.Columns["name"].HeaderText = "ชื่อวัตถุดิบ";
                    dgvMenu.Columns["price"].HeaderText = "ราคา";
                    dgvMenu.Columns["stock"].HeaderText = "คงเหลือ";
                    dgvMenu.Columns["category_name"].HeaderText = "หมวดหมู่";

                    dgvMenu.Columns["category_id"].Visible = false;
                    dgvMenu.Columns["image_path"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading custom items data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSwitchMenuCustom_Click(object sender, EventArgs e)
        {
            LoadCustomDataGrid(); // โหลดข้อมูลวัตถุดิบเสริม
            currentMode = "Custom";

            // **โค้ดที่เพิ่ม: สั่งให้ ComboBox แสดงผล**
            this.cmbCategory.Visible = true;
            this.lblCategory.Visible = true;

            txtNewCategoryName.Visible = true;
            btnAddCategory.Visible = true;
            lblAddCat.Visible = true;

            // ตั้งชื่อ Label ด้านบนช่องแก้ไขให้เป็น "ID วัตถุดิบ"
            lblID.Text = "ID วัตถุดิบ";
            lblMenuName.Text = "ชื่อวัตถุดิบ";
        }

        private void btnSwitchMenuSamret_Click(object sender, EventArgs e)
        {
            LoadMenuDataGrid(); // โหลดข้อมูลเมนูสำเร็จ
            currentMode = "Menu";

            // **โค้ดที่เพิ่ม: สั่งให้ ComboBox ซ่อน**
            this.cmbCategory.Visible = false;
            this.lblCategory.Visible = false;

            txtNewCategoryName.Visible = false;
            btnAddCategory.Visible = false;
            lblAddCat.Visible = false;

            // ตั้งชื่อ Label ด้านบนช่องแก้ไขให้เป็น "ID"
            lblID.Text = "ID สินค้า";
            lblMenuName.Text = "ชื่อเมนู";


        }

        private void btnFilterLowStock_Click(object sender, EventArgs e)
        {
            // เราจะใช้ DataView เพื่อกรองข้อมูลที่โหลดไว้ใน DataTable แล้ว (มีประสิทธิภาพกว่าการ Query DB ซ้ำ)
            if (dgvMenu.DataSource is DataTable menuTable)
            {
                DataView dv = menuTable.DefaultView;

                // ตรวจสอบโหมดปัจจุบันเพื่อใช้ชื่อคอลัมน์ที่ถูกต้อง
                string stockColumn = (currentMode == "Custom") ? "stock" : "stock"; // คอลัมน์ชื่อ stock เหมือนกัน

                // กรองแถวที่มีค่า Stock น้อยกว่าหรือเท่ากับ 10
                dv.RowFilter = string.Format("{0} <= 10", stockColumn);

            }
            else
            {
                // หากไม่มีข้อมูลใน dgvMenu ให้โหลดใหม่
                if (currentMode == "Custom")
                    LoadCustomDataGrid();
                else
                    LoadMenuDataGrid();

                
            }
        }

        private void btnSortStock_Click(object sender, EventArgs e)
        {
            // ตรวจสอบว่า dgvMenu มีแหล่งข้อมูล (DataSource) ที่เป็น DataTable หรือไม่
            if (dgvMenu.DataSource is DataTable menuTable)
            {
                // 1. สร้าง DataView เพื่อใช้ในการเรียงลำดับ
                DataView dv = menuTable.DefaultView;

                // 2. กำหนดเงื่อนไขการเรียงลำดับ: คอลัมน์ 'stock' (น้อยไปมาก)
                dv.Sort = "stock ASC"; // ASC = Ascending (น้อยไปมาก)

                // 3. ผูก DataGridView กับ DataView ที่เรียงลำดับแล้ว
                dgvMenu.DataSource = dv;
            }
            else
            {
                MessageBox.Show("กรุณาโหลดข้อมูลเมนูสำเร็จหรือวัตถุดิบเลือกเองก่อน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearchAdmin_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchAdmin.Text.Trim();

            // ตรวจสอบว่า dgvMenu มีแหล่งข้อมูล (DataSource) ที่เป็น DataTable หรือไม่
            if (dgvMenu.DataSource is DataTable menuTable)
            {
                DataView dv = menuTable.DefaultView;

                // 1. ตรวจสอบโหมดปัจจุบันเพื่อกำหนดชื่อคอลัมน์ ID ที่ถูกต้อง
                string idColumn = (currentMode == "Custom") ? "item_id" : "menu_id";
                string nameColumn = "name";

                // 2. กำหนดเงื่อนไขการกรอง (Filter): ค้นหาใน ID หรือ Name
                if (!string.IsNullOrEmpty(searchText))
                {
                    // ใช้ LIKE เพื่อค้นหาส่วนหนึ่งของข้อความ (Case-Insensitive search)
                    dv.RowFilter = string.Format(
                        "{0} LIKE '%{1}%' OR {2} LIKE '%{1}%'",
                        idColumn, searchText, nameColumn
                    );
                }
                else
                {
                    // ถ้าช่องค้นหาว่าง ให้แสดงทุกรายการ
                    dv.RowFilter = string.Empty;
                }

            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ตรวจสอบว่าอยู่ในโหมด Custom และ ComboBox ถูกโหลดข้อมูลแล้ว
            if (currentMode == "Custom" && cmbCategory.SelectedValue != null)
            {
                // 1. ดึง ID หมวดหมู่ที่ถูกเลือก
                int selectedCategoryID = Convert.ToInt32(cmbCategory.SelectedValue);

                // 2. โหลดข้อมูลวัตถุดิบทั้งหมด (โดยไม่กรอง)
                LoadCustomDataGrid();

                // 3. กรอง DataView (Filter) เพื่อแสดงเฉพาะ Category ที่ถูกเลือก
                if (dgvMenu.DataSource is DataTable customTable)
                {
                    DataView dv = customTable.DefaultView;

                    // ใช้ RowFilter เพื่อกรองตาม category_id
                    dv.RowFilter = string.Format("category_id = {0}", selectedCategoryID);

                    dgvMenu.DataSource = dv;
                }
            }
        }


        private void btnNavUser_Click(object sender, EventArgs e)
        {
            FormAdminManageUser userForm = new FormAdminManageUser();
            userForm.ShowDialog();
        }

        private void btnNavSales_Click(object sender, EventArgs e)
        {
            FormAdminSalesRecords salesForm = new FormAdminSalesRecords();
            salesForm.ShowDialog();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // กำหนด Filter เฉพาะไฟล์รูปภาพ
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            // แสดงหน้าต่างเลือกไฟล์
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 1. เก็บ Path ใหม่ไว้ในตัวแปรชั่วคราว (ที่คุณประกาศไว้ระดับ Class)
                newImagePath = openFileDialog.FileName;

                // 2. แสดงรูปภาพตัวอย่างใน PictureBox ทันที
                // ต้องแน่ใจว่าได้ใช้ using System.Drawing; และ using System.IO; แล้ว
                try
                {
                    picMenuImage.Image = System.Drawing.Image.FromFile(newImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ไม่สามารถโหลดรูปภาพตัวอย่างได้: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtNewCategoryName.Text.Trim();

            // 1. ตรวจสอบว่าไม่ได้กรอกค่าว่าง
            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("กรุณากรอกชื่อหมวดหมู่ที่ต้องการเพิ่ม", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    conn.Open();

                    // 2. ตรวจสอบก่อนว่าชื่อซ้ำไหม (Optional แต่แนะนำ)
                    string checkSql = "SELECT COUNT(*) FROM Categories WHERE name = @name";
                    MySqlCommand checkCmd = new MySqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@name", categoryName);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("หมวดหมู่นี้มีอยู่ในระบบแล้ว", "ซ้ำ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 3. บันทึกหมวดหมู่ใหม่
                    string sql = "INSERT INTO Categories (name) VALUES (@name)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", categoryName);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("เพิ่มหมวดหมู่สำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. ล้างช่องกรอก
                    txtNewCategoryName.Clear();

                    // 5. ***สำคัญมาก*** ต้องโหลด ComboBox ใหม่ เพื่อให้ชื่อหมวดหมู่ที่เพิ่งเพิ่มปรากฏทันที
                    LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
