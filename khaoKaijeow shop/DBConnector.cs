using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

// Class นี้จัดการการเชื่อมต่อกับ MySQL ใน XAMPP
public class DBConnector
{
    // Connection String: ใช้ค่าเริ่มต้นของ XAMPP (root และไม่มีรหัสผ่าน)
    private string connectionString = "Server=localhost;Database=khaokaijeow_db;Uid=root;Pwd=;";
    private MySqlConnection connection;

    public DBConnector()
    {
        connection = new MySqlConnection(connectionString);
        TestConnection();
    }

    // Method สำหรับทดสอบการเชื่อมต่อ
    private void TestConnection()
    {
        try
        {
            connection.Open();
            connection.Close();
        }
        catch (Exception ex)
        {
            // โค้ดแจ้ง Error นี้อาจเรียกใช้โค้ดที่ผิดพลาดใน Form
            MessageBox.Show("เกิดข้อผิดพลาดในการเชื่อมต่อ! ตรวจสอบ XAMPP และ Connection String: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Method สำคัญ: ส่งคืน Connection Object เพื่อใช้ใน Query
    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString); // สร้างใหม่ทุกครั้งเพื่อป้องกันปัญหา
    }
}