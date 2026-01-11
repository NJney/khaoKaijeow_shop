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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }


        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // สร้าง Object ของ FormForgotPassword
            FormForgotPassword resetForm = new FormForgotPassword();

            // แสดง Form เป็นแบบ Dialog (บังคับให้ผู้ใช้ดำเนินการก่อนกลับไป FormLogin)
            resetForm.ShowDialog();
        }


        private void picShowpassword_Click(object sender, EventArgs e)
        {

            // ตรวจสอบและสลับโหมดการซ่อนรหัสผ่านสำหรับช่องรหัสผ่าน (ส่วน Login)
            if (txtPassword.UseSystemPasswordChar == true)

            {
                // หากกำลังซ่อนอยู่ (True) ให้เปลี่ยนเป็นแสดง (False)
                txtPassword.UseSystemPasswordChar = false;

            }
            else
            {
                // หากกำลังแสดงอยู่ (False) ให้เปลี่ยนกลับไปซ่อน (True)
                txtPassword.UseSystemPasswordChar = true;

            }

            //  ย้ายเคอร์เซอร์ไปตำแหน่งสุดท้ายเสมอ เพื่อให้การซ่อน/แสดงทำงานได้สมบูรณ์
            txtPassword.SelectionStart = txtPassword.Text.Length;
        }


        private void picShowSU_Password_Click(object sender, EventArgs e)
        {
            // ตรวจสอบและสลับโหมดการซ่อนรหัสผ่านสำหรับช่องรหัสผ่าน (ส่วน Login)
            if (txtSU_Password.UseSystemPasswordChar == true)

            {
                // หากกำลังซ่อนอยู่ (True) ให้เปลี่ยนเป็นแสดง (False)
                txtSU_Password.UseSystemPasswordChar = false;

            }
            else
            {
                // หากกำลังแสดงอยู่ (False) ให้เปลี่ยนกลับไปซ่อน (True)
                txtSU_Password.UseSystemPasswordChar = true;

            }

            //  ย้ายเคอร์เซอร์ไปตำแหน่งสุดท้ายเสมอ เพื่อให้การซ่อน/แสดงทำงานได้สมบูรณ์
            txtSU_Password.SelectionStart = txtSU_Password.Text.Length;
        }

        private void picShowSU_ConfirmPwd_Click(object sender, EventArgs e)
        {
            // ตรวจสอบและสลับโหมดการซ่อนรหัสผ่านสำหรับช่องรหัสผ่าน (ส่วน Login)
            if (txtSU_ConfirmPwd.UseSystemPasswordChar == true)

            {
                // หากกำลังซ่อนอยู่ (True) ให้เปลี่ยนเป็นแสดง (False)
                txtSU_ConfirmPwd.UseSystemPasswordChar = false;

            }
            else
            {
                // หากกำลังแสดงอยู่ (False) ให้เปลี่ยนกลับไปซ่อน (True)
                txtSU_ConfirmPwd.UseSystemPasswordChar = true;

            }

            //  ย้ายเคอร์เซอร์ไปตำแหน่งสุดท้ายเสมอ เพื่อให้การซ่อน/แสดงทำงานได้สมบูรณ์
            txtSU_ConfirmPwd.SelectionStart = txtSU_ConfirmPwd.Text.Length;
        }

        private void OpenNextForm(string userRole)
        {
            if (userRole.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                
                // ===  Admin ===
                FormAdminDashboard adminForm = new FormAdminDashboard();
                adminForm.Show();
            }
            else // Customer
            {
                // 2. ถ้าเป็น Customer ให้เปิดหน้า MainShop
                MainShop shopForm = new MainShop();
                shopForm.Show();
            }
        }

        private void btnLoginConfirm_Click(object sender, EventArgs e)
        {
            // 1. ดึงข้อมูลจาก TextBoxes (สมมติชื่อ txtUserEmail และ txtPassword)
            string loginId = txtUserEmail.Text.Trim();
            string password = txtPassword.Text;

            // 2. การตรวจสอบเบื้องต้น (Validation)
            if (string.IsNullOrEmpty(loginId) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("กรุณากรอกชื่อผู้ใช้/อีเมลและรหัสผ่านให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. กำหนด SQL Query ด้วย Placeholder (@) 
            // SQL Query ต้องดึงคอลัมน์ 'id' ออกมาด้วย
            string sql = "SELECT id, role FROM Users WHERE (username = @login_id OR email = @login_id) AND password = @password";

            // 4. การเชื่อมต่อฐานข้อมูล
            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, connection);

                    // 5. กำหนดค่าให้กับ Placeholder (@)
                    cmd.Parameters.AddWithValue("@login_id", loginId);
                    cmd.Parameters.AddWithValue("@password", password);

                    // 6. อ่านข้อมูล
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // === A. เข้าสู่ระบบสำเร็จ ===
                            MessageBox.Show("เข้าสู่ระบบสำเร็จ!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 1. *** โค้ดที่เพิ่ม: ดึงและบันทึก User ID ***
                            int userId = reader.GetInt32("id"); // ดึงคอลัมน์ ID ของผู้ใช้
                            Program.CurrentUserID = userId;     // กำหนดให้เป็น ID ผู้ใช้ปัจจุบัน
                                                                // ***************************************

                            // 2. บันทึกข้อมูลผู้ใช้และสิทธิ์ (Role)
                            string role = reader.GetString("role");

                            // 3. ปิดหน้า Login และเปิด Form ถัดไป
                            this.Hide();
                            OpenNextForm(role);
                        }
                        else
                        {
                            // === B. ข้อมูลไม่ถูกต้อง ===
                            MessageBox.Show("ชื่อผู้ใช้/อีเมล หรือรหัสผ่านไม่ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการตรวจสอบสิทธิ์: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnSignUpConfirm_Click(object sender, EventArgs e)
        {
            // 1. ดึงข้อมูลจาก TextBoxes (ปรับชื่อตาม Controls ที่คุณสร้าง)
            string email = txtSU_Email.Text.Trim();
            string username = txtSU_Username.Text.Trim();
            string password = txtSU_Password.Text;
            string confirmPwd = txtSU_ConfirmPwd.Text;
            string firstName = txtSU_Name.Text.Trim();
            string lastName = txtSU_Surname.Text.Trim(); // ปรับชื่อตามที่คุณตั้ง
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // รูปแบบที่ MySQL เข้าใจ

            // 2. === การตรวจสอบเบื้องต้น (Client-Side Validation) ===

            // ตรวจสอบ: ห้ามช่องว่าง
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("กรุณากรอกข้อมูลในส่วนสมัครสมาชิกให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ตรวจสอบ: รหัสผ่านไม่ตรงกัน
            if (password != confirmPwd)
            {
                MessageBox.Show("รหัสผ่านและยืนยันรหัสผ่านไม่ตรงกัน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSU_Password.Clear();
                txtSU_ConfirmPwd.Clear();
                return;
            }

            //  === การตรวจสอบความแข็งแกร่งของรหัสผ่าน (Password Strength) ===
            // 1. (?=.*[0-9]): ต้องมีตัวเลขอย่างน้อย 1 ตัว
            // 2. (?=.*[a-zA-Z]): ต้องมีตัวอักษร (เล็กหรือใหญ่) อย่างน้อย 1 ตัว
            // 3. .{8,}: ความยาวรวมต้องมีอย่างน้อย 8 ตัวอักษรขึ้นไป
            string passwordPattern = @"^(?=.*[0-9])(?=.*[a-zA-Z]).{8,}$";

            if (!Regex.IsMatch(password, passwordPattern))
            {
                MessageBox.Show("รหัสผ่านไม่ปลอดภัย:\n\n- ต้องมีความยาวอย่างน้อย 8 ตัวอักษร\n- ต้องมีตัวอักษร (A-Z, a-z) อย่างน้อย 1 ตัว\n- ต้องมีตัวเลข (0-9) อย่างน้อย 1 ตัว", "แจ้งเตือนรหัสผ่าน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSU_Password.Clear();
                txtSU_ConfirmPwd.Clear();
                return;
            }

            //  === การตรวจสอบรูปแบบอีเมล (Email Format Validation) ===
            try
            {
                // การสร้าง MailAddress Object จะตรวจสอบรูปแบบอีเมลโดยอัตโนมัติ
                var addr = new System.Net.Mail.MailAddress(email);

            }
            catch
            {
                // ถ้าเกิด Exception (Error) แสดงว่ารูปแบบอีเมลไม่ถูกต้อง
                MessageBox.Show("รูปแบบอีเมลไม่ถูกต้อง (ต้องมี @ และ Domain ที่เหมาะสม)", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. === การตรวจสอบความซ้ำซ้อนในฐานข้อมูล (Uniqueness Check) ===
            // (ตรวจสอบว่า Username หรือ Email มีการใช้งานอยู่แล้วหรือไม่)
            if (IsUserExist(username, email))
            {
                MessageBox.Show("ชื่อผู้ใช้ (Username) หรืออีเมลนี้ถูกใช้งานแล้ว", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // 4. === บันทึกข้อมูลใหม่เข้าสู่ตาราง Users ===
            string sql = @"
            INSERT INTO Users (username, first_name, last_name, email, password, role, date_joined, last_login)
            VALUES (@username, @firstName, @lastName, @email, @password, 'Customer', @dateJoined, @lastLogin)";

            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, connection);

                    // 5. กำหนดค่าให้กับ Placeholder
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@dateJoined", currentDate);
                    cmd.Parameters.AddWithValue("@lastLogin", currentDate);

                    cmd.ExecuteNonQuery(); // สั่งรัน INSERT

                    MessageBox.Show("สมัครสมาชิกสำเร็จ! คุณสามารถเข้าสู่ระบบได้ทันที", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // ล้างข้อมูลในช่องกรอกสมัครสมาชิก
                    ClearSignUpFields();
                    // กลับไปหน้า Login
                    pnlSign.Visible = false;
                    pnlLogin.Visible = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการสมัครสมาชิก: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 1. Method สำหรับตรวจสอบว่า Username หรือ Email ซ้ำหรือไม่
        private bool IsUserExist(string username, string email)
        {
            string sql = "SELECT COUNT(id) FROM Users WHERE username = @username OR email = @email";

            DBConnector dbConnector = new DBConnector();
            using (MySqlConnection connection = dbConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@email", email);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking user existence: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true; // ถือว่ามีปัญหา (ป้องกันการสมัครซ้ำซ้อน)
                }
            }
        }

        // 2. Method สำหรับล้างช่องกรอกสมัครสมาชิก
        private void ClearSignUpFields()
        {
            txtSU_Email.Clear();
            txtSU_Username.Clear();
            txtSU_Password.Clear();
            txtSU_ConfirmPwd.Clear();
            txtSU_Name.Clear();
            txtSU_Surname.Clear();
        }

        private void lnkGoToSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // ซ่อน Panel เข้าสู่ระบบ
            pnlLogin.Visible = false;

            // แสดง Panel สมัครสมาชิก
            pnlSign.Visible = true;
        }

        private void lnkGoToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // ซ่อน Panel สมัครสมาชิก
            pnlSign.Visible = false;

            // แสดง Panel เข้าสู่ระบบ
            pnlLogin.Visible = true;

            // *** เคลียร์ข้อมูลสมัครสมาชิกเมื่อกลับมาหน้า Login ***
            ClearSignUpFields();
        }
    }
}
