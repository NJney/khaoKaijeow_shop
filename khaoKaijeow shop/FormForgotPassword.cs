using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace khaokaijeow_shop
{
    public partial class FormForgotPassword : Form
    {
        private string verifiedResetID;

        public FormForgotPassword()
        {
            InitializeComponent();
            this.KeyPreview = true;

        }

        private void btnCheckID_Click(object sender, EventArgs e)
        {
            // ช่องกรอกคือ txtResetID, Panel คือ pnlStep1 และ pnlStep2
            string resetId = txtResetID.Text.Trim();
            if (string.IsNullOrEmpty(resetId))
            {
                MessageBox.Show("กรุณากรอกชื่อผู้ใช้หรืออีเมลที่ต้องการตั้งรหัสใหม่", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SQL Query: ตรวจสอบว่า Username หรือ Email มีอยู่หรือไม่
            string sql = "SELECT COUNT(id) FROM Users WHERE username = @resetId OR email = @resetId";

            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@resetId", resetId);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        
                        verifiedResetID = resetId;

                        // ซ่อน Step 1 และแสดง Step 2
                        pnlStep1.Visible = false; // <<< ซ่อน Panel ยืนยัน ID <<<
                        pnlStep2.Visible = true;  // <<< แสดง Panel ตั้งรหัสใหม่ <<<

                        // แสดงข้อความยืนยัน
                        MessageBox.Show("ยืนยันตัวตนสำเร็จ! กรุณาตั้งรหัสผ่านใหม่", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("ไม่พบชื่อผู้ใช้หรืออีเมลนี้ในระบบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking user existence: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSaveNewPassword_Click(object sender, EventArgs e)
        {
           
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // 1. ตรวจสอบรหัสผ่านไม่ตรงกัน
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("รหัสผ่านใหม่ไม่ตรงกัน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. ตรวจสอบความแข็งแกร่ง (Regex)
            string passwordPattern = @"^(?=.*[0-9])(?=.*[a-zA-Z]).{8,}$";

            if (!Regex.IsMatch(newPassword, passwordPattern))
            {
                MessageBox.Show("รหัสผ่านไม่ปลอดภัย:\n\n- ต้องมีความยาวอย่างน้อย 8 ตัวอักษร\n- ต้องมีตัวอักษร (A-Z, a-z) อย่างน้อย 1 ตัว\n- ต้องมีตัวเลข (0-9) อย่างน้อย 1 ตัว", "แจ้งเตือนรหัสผ่าน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
                return;
            }

            // 3. UPDATE รหัสผ่านใหม่ในฐานข้อมูล
            string sql = "UPDATE Users SET password = @newPwd WHERE username = @resetId OR email = @resetId";

            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@newPwd", newPassword);
                    cmd.Parameters.AddWithValue("@resetId", verifiedResetID); // ใช้ ID ที่เก็บไว้

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("ตั้งรหัสผ่านใหม่สำเร็จ! กรุณาเข้าสู่ระบบด้วยรหัสผ่านใหม่", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการอัปเดตรหัสผ่าน: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
