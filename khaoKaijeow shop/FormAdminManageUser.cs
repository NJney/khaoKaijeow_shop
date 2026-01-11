using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace khaokaijeow_shop
{
    public partial class FormAdminManageUser : Form
    {
        private string newImagePath = "";     // เก็บ Path รูปใหม่ที่เลือกจากเครื่อง
        private string currentImagePath = ""; // เก็บ Path รูปเดิมจาก Database

        public FormAdminManageUser()
        {
            InitializeComponent();
            LoadUserDataGrid(); // โหลดข้อมูลเมื่อ Form เปิด


            // เติมตัวเลือกใน ComboBox Role
            cmbUserRole.DataSource = new List<string> { "Customer", "Admin" };
        }

        public void LoadUserDataGrid()
        {
         string sql = "SELECT id, username, email, first_name, last_name, role, password, profile_image FROM Users ORDER BY id";

            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataTable userTable = new DataTable();
                    adapter.Fill(userTable);

                    dgvUsers.DataSource = userTable;

                    // จัดรูปแบบ Column
                    dgvUsers.Columns["id"].HeaderText = "ID";
                    dgvUsers.Columns["username"].HeaderText = "ชื่อผู้ใช้";
                    dgvUsers.Columns["email"].HeaderText = "อีเมล";
                    dgvUsers.Columns["first_name"].HeaderText = "ชื่อจริง";
                    dgvUsers.Columns["last_name"].HeaderText = "นามสกุล";
                    dgvUsers.Columns["role"].HeaderText = "สถานะ";
                    dgvUsers.Columns["password"].HeaderText = "รหัสผ่าน";

                    // ซ่อน Column ที่ไม่จำเป็นต้องโชว์ในตาราง
                    if(dgvUsers.Columns.Contains("profile_image")) dgvUsers.Columns["profile_image"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading user data: " + ex.Message);
                }
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                txtUserID.Text = row.Cells["id"].Value.ToString();
                txtUserName.Text = row.Cells["username"].Value.ToString();
                txtUserEmail.Text = row.Cells["email"].Value.ToString();
                txtFirstName.Text = row.Cells["first_name"].Value.ToString();
                txtLastName.Text = row.Cells["last_name"].Value.ToString();
                txtNewPassword.Text = ""; // เคลียร์ช่องรหัสผ่าน เพื่อความปลอดภัย

                if (row.Cells["role"].Value != DBNull.Value)
                    cmbUserRole.SelectedItem = row.Cells["role"].Value.ToString();

                // --- ส่วนจัดการรูปภาพ ---
                currentImagePath = row.Cells["profile_image"].Value.ToString();
                newImagePath = ""; // รีเซ็ตตัวแปรรูปใหม่ทุกครั้งที่เลือก User ใหม่

                // แสดงรูปภาพ (ใช้ FileStream เพื่อไม่ให้ไฟล์ล็อก)
                if (!string.IsNullOrEmpty(currentImagePath) && File.Exists(currentImagePath))
                {
                    using (FileStream fs = new FileStream(currentImagePath, FileMode.Open, FileAccess.Read))
                    {
                        picUserImage.Image = Image.FromStream(fs);
                    }
                }
                else
                {
                    picUserImage.Image = null; // หรือใส่รูป Default
                }

                btnSaveUser.Enabled = true;
                btnDeleteUser.Enabled = true;
            }
        }

        private void ResetUserEditFormState()
        {
            txtUserID.Clear();
            txtUserName.Clear();
            txtUserEmail.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtNewPassword.Clear();
            cmbUserRole.SelectedIndex = -1; // ไม่เลือกสถานะใดๆ
            picUserImage.Image = null;
            newImagePath = "";
            currentImagePath = "";

            btnSaveUser.Enabled = false;
            btnDeleteUser.Enabled = false;
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png" };
            if (open.ShowDialog() == DialogResult.OK)
            {
                newImagePath = open.FileName;

                // แสดงตัวอย่างรูปทันที
                using (FileStream fs = new FileStream(newImagePath, FileMode.Open, FileAccess.Read))
                {
                    picUserImage.Image = Image.FromStream(fs);
                }
            }
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            // 1. ดึงข้อมูล
            string userID = txtUserID.Text.Trim();
            string newUsername = txtUserName.Text.Trim();
            string newEmail = txtUserEmail.Text.Trim();
            string newFirstName = txtFirstName.Text.Trim();
            string newLastName = txtLastName.Text.Trim();
            string newRole = cmbUserRole.SelectedItem.ToString();
            string newPassword = txtNewPassword.Text; // รหัสผ่านใหม่
            string finalImagePath = currentImagePath;

            if (!string.IsNullOrEmpty(newImagePath)) // ถ้ามีการเลือกรูปใหม่
            {
                try
                {
                    string dir = Path.Combine(Application.StartupPath, "UserImages");
                    if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                    // ตั้งชื่อไฟล์: User_{ID}_{Tick}.ext
                    string extension = Path.GetExtension(newImagePath);
                    string fileName = $"User_{userID}_{DateTime.Now.Ticks}{extension}";
                    string destinationPath = Path.Combine(dir, fileName);

                    File.Copy(newImagePath, destinationPath, true);
                    finalImagePath = destinationPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("อัปโหลดรูปไม่สำเร็จ: " + ex.Message);
                    return;
                }
            }

            // ตรวจสอบเบื้องต้น (เพิ่มโค้ด Validation อื่นๆ ที่นี่หากต้องการ)
            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newEmail))
            {
                MessageBox.Show("กรุณากรอกชื่อผู้ใช้และอีเมลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. === กำหนด SQL Query (รวม Logic Password) ===
            string sql = "UPDATE Users SET username = @username, email = @email, first_name = @first_name, last_name = @last_name, role = @role ,profile_image = @img";

            // Logic: ถ้ามีการกรอกรหัสผ่านใหม่ ให้เพิ่มการ UPDATE รหัสผ่านด้วย
            if (!string.IsNullOrEmpty(newPassword))
            {
                sql += ", password = @password"; // << เพิ่ม , password = @password เข้าไป
            }
            // เพิ่มเงื่อนไข WHERE เพื่อระบุ User ที่ต้องการแก้ไข
            sql += " WHERE id = @id";

            // 3. เชื่อมต่อและรัน Query
            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    // สร้าง MySqlCommand หลังจาก string sql ถูกกำหนดเสร็จสมบูรณ์
                    MySqlCommand cmd = new MySqlCommand(sql, connection);

                    // 4. กำหนดค่า Parameters
                    cmd.Parameters.AddWithValue("@id", userID);
                    cmd.Parameters.AddWithValue("@username", newUsername);
                    cmd.Parameters.AddWithValue("@email", newEmail);
                    cmd.Parameters.AddWithValue("@first_name", newFirstName);
                    cmd.Parameters.AddWithValue("@last_name", newLastName);
                    cmd.Parameters.AddWithValue("@role", newRole);
                    cmd.Parameters.AddWithValue("@img", finalImagePath);

                    // === แก้ไขปัญหา Password Parameter ===
                    // ถ้ามีการกรอกรหัสผ่านใหม่ ให้ส่งค่า password ไปด้วย
                    if (!string.IsNullOrEmpty(newPassword))
                    {
                        cmd.Parameters.AddWithValue("@password", newPassword); // << กำหนดค่า Password ที่นี่
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("แก้ไขข้อมูลผู้ใช้สำเร็จ!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadUserDataGrid();
                    ResetUserEditFormState();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูลผู้ใช้: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string userID = txtUserID.Text.Trim();
            // ... (โค้ด Validation และ MessageBox.Show ยืนยันการลบ)

            // SQL Query (DELETE)
            string sql = "DELETE FROM Users WHERE id = @id";

            // ... (โค้ดเชื่อมต่อและรัน Query)
            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id", userID);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ลบผู้ใช้สำเร็จ!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadUserDataGrid();
                    ResetUserEditFormState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการลบข้อมูล: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearchAdmin_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchAdmin.Text.Trim();

            // 1. ตรวจสอบว่า dgvUsers มีแหล่งข้อมูล (DataSource) ที่เป็น DataTable หรือไม่
            if (dgvUsers.DataSource is DataTable userTable)
            {
                DataView dv = userTable.DefaultView;

                // 2. กำหนดเงื่อนไขการกรอง (Filter)
                if (!string.IsNullOrEmpty(searchText))
                {
                    //  ใช้ CONVERT แปลง id เป็น String ก่อนค้นหา
                    dv.RowFilter = string.Format(
                        "CONVERT(id, 'System.String') LIKE '%{0}%' OR username LIKE '%{0}%' OR email LIKE '%{0}%'",
                        searchText
                    );
                }
                else
                {
                    // ถ้าช่องค้นหาว่าง ให้แสดงทุกรายการ
                    dv.RowFilter = string.Empty;
                }
            }

        }

        private void btnNavSales_Click(object sender, EventArgs e)
        {
            // สร้าง Form Sales Records ใหม่
            FormAdminSalesRecords salesForm = new FormAdminSalesRecords();

            // ซ่อน Form จัดการผู้ใช้ปัจจุบัน
            this.Hide();

            //  เปิด Form ผลการขาย
            salesForm.ShowDialog();

            //  เปิด Form จัดการผู้ใช้ปัจจุบัน
            this.Show();
        }

        private void btnNavMenu_Click(object sender, EventArgs e)
        {
            //  สร้าง Form Admin Dashboard ใหม่ (โหมด Menu เป็นค่าเริ่มต้น)
            FormAdminDashboard adminForm = new FormAdminDashboard();

            // 2. ซ่อน Form จัดการผู้ใช้ปัจจุบัน
            this.Hide();

            // 3. เปิด Form Admin Dashboard
            adminForm.Show();
        }

        
    }
}
