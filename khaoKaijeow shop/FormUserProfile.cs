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
    public partial class FormUserProfile : Form
    {
        private string newImagePath = "";
        private string currentImagePath = "";

        public FormUserProfile()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {
            using (MySqlConnection conn = Program.DbGlobalConnector.GetConnection())
            {
                conn.Open();
                string sql = "SELECT first_name, last_name, phone_number, address, profile_image, email FROM Users WHERE id = @uid";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uid", Program.CurrentUserID);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtFirstName.Text = reader["first_name"].ToString();
                        txtLastName.Text = reader["last_name"].ToString();
                        txtPhone.Text = reader["phone_number"].ToString();
                        txtAddress.Text = reader["address"].ToString();
                        txtEmail.Text = reader["email"].ToString();

                        currentImagePath = reader["profile_image"].ToString();
                        if (!string.IsNullOrEmpty(currentImagePath) && File.Exists(currentImagePath))
                        {
                            using (FileStream fs = new FileStream(currentImagePath, FileMode.Open, FileAccess.Read))
                            {
                                picProfile.Image = Image.FromStream(fs);
                            }
                        }
                        else
                        {
                            picProfile.Image = null;
                        }
                    }
                }
            }
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png" };
            if (open.ShowDialog() == DialogResult.OK)
            {
                newImagePath = open.FileName;

                // [แก้ไขใหม่] โหลดรูปตัวอย่างแบบไม่ล็อกไฟล์
                try
                {
                    using (FileStream fs = new FileStream(newImagePath, FileMode.Open, FileAccess.Read))
                    {
                        picProfile.Image = Image.FromStream(fs);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ไม่สามารถเปิดรูปภาพนี้ได้: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
         
            string newEmail = txtEmail.Text.Trim();
            string finalImagePath = currentImagePath;

            if (!string.IsNullOrEmpty(newImagePath))
            {
                try
                {
                    // 1. ตรวจสอบว่ามีโฟลเดอร์ UserImages
                    string dir = Path.Combine(Application.StartupPath, "UserImages");
                    if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                    // 2. ตั้งชื่อไฟล์ใหม่ (ใช้ ID + เวลา เพื่อไม่ให้ซ้ำ)
                    string extension = Path.GetExtension(newImagePath);
                    string fileName = $"User_{Program.CurrentUserID}_{DateTime.Now.Ticks}{extension}";
                    string destinationPath = Path.Combine(dir, fileName);

                    // 3. Copy ไฟล์ 
                    File.Copy(newImagePath, destinationPath, true);
                    finalImagePath = destinationPath;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"เกิดข้อผิดพลาดในการอัปโหลดรูป: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // ออกจากฟังก์ชัน ไม่ฝืนบันทึกต่อ
                }
            }

            if (string.IsNullOrEmpty(newEmail))
            {
                MessageBox.Show("กรุณากรอกอีเมล", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = Program.DbGlobalConnector.GetConnection())
            {
                conn.Open();

                // -----------------------------------------------------------
                // ตรวจสอบว่าอีเมลนี้ มีคนอื่นใช้ไปหรือยัง
                // -----------------------------------------------------------
                string checkSql = "SELECT COUNT(*) FROM Users WHERE email = @email AND id != @uid";
                MySqlCommand checkCmd = new MySqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@email", newEmail);
                checkCmd.Parameters.AddWithValue("@uid", Program.CurrentUserID); // เช็คว่าไม่ใช่ id ของเราเอง

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("อีเมลนี้มีผู้ใช้งานแล้ว กรุณาใช้อีเมลอื่น", "ข้อมูลซ้ำ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // หยุดการทำงานทันที ไม่บันทึก
                }

                // -----------------------------------------------------------
                // ถ้าไม่ซ้ำ ก็ทำการบันทึก (UPDATE)
                // -----------------------------------------------------------
                string sql = @"UPDATE Users 
                       SET first_name=@fn, 
                           last_name=@ln, 
                           phone_number=@ph, 
                           address=@addr, 
                           profile_image=@img,
                           email=@email  /* <--- เพิ่มตรงนี้ */
                       WHERE id=@uid";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                // Parameters เดิม
                cmd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@ph", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@img", finalImagePath);      

                // Parameters ใหม่ (Email)
                cmd.Parameters.AddWithValue("@email", newEmail);

                cmd.Parameters.AddWithValue("@uid", Program.CurrentUserID);

                cmd.ExecuteNonQuery();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "สำเร็จ");
                this.Close();
            }
        }
    }
}
