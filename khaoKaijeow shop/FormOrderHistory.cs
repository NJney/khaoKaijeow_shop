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

namespace khaokaijeow_shop
{
    public partial class FormOrderHistory : Form
    {
        public FormOrderHistory()
        {
            InitializeComponent();

            // 1. ตรวจสอบสถานะการล็อกอิน
            if (Program.CurrentUserID <= 0)
            {
                MessageBox.Show("กรุณาเข้าสู่ระบบก่อนเพื่อดูประวัติการสั่งซื้อ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // 2. โหลดรายการคำสั่งซื้อหลักทันทีเมื่อ Form เปิด
            LoadOrderHistory();

            // 3. ผูก Event CellClick ของ dgvOrders เพื่อโหลดรายละเอียดสินค้า
            dgvOrders.CellClick += dgvOrders_CellClick;
        }

        private void LoadOrderHistory()
        {
            int currentUserId = Program.CurrentUserID;

            // ดึงข้อมูลหลักจากตาราง Orders
            string sql = @"
                SELECT 
                    order_id AS 'รหัสสั่งซื้อ',
                    order_time AS 'วันที่สั่งซื้อ',
                    total_price AS 'ยอดรวมสุทธิ (รวม VAT)',
                    total_vat AS 'VAT 7%',
                    status AS 'สถานะ'
                FROM Orders 
                WHERE user_id = @userId
                ORDER BY order_time DESC";

            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@userId", currentUserId);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvOrders.DataSource = dt;

                    // ปรับขนาดตารางให้สวยงาม
                    if (dgvOrders.Columns.Contains("ยอดรวมสุทธิ (รวม VAT)"))
                    {
                        dgvOrders.Columns["ยอดรวมสุทธิ (รวม VAT)"].DefaultCellStyle.Format = "N2";
                    }
                    if (dgvOrders.Columns.Contains("VAT 7%"))
                    {
                        dgvOrders.Columns["VAT 7%"].DefaultCellStyle.Format = "N2";
                    }
                    dgvOrders.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการโหลดประวัติการสั่งซื้อ: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ===================================================================
        // II. การโหลดรายละเอียดเมื่อคลิกที่รายการ
        // ===================================================================

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ตรวจสอบว่าคลิกที่แถวข้อมูลและมีข้อมูล
            if (e.RowIndex < 0 || dgvOrders.CurrentRow == null) return;

            // ดึง Order ID จากแถวที่เลือก
            // คอลัมน์ "รหัสสั่งซื้อ" คือคอลัมน์แรก (Index 0)
            if (dgvOrders.CurrentRow.Cells["รหัสสั่งซื้อ"].Value == DBNull.Value) return;

            long orderId = Convert.ToInt64(dgvOrders.CurrentRow.Cells["รหัสสั่งซื้อ"].Value);

            LoadOrderDetails(orderId);
        }

        private void LoadOrderDetails(long orderId)
        {
            // ดึงข้อมูลรายละเอียดสินค้าจากตาราง OrderDetails
            string sql = @"
                SELECT 
                    product_name AS 'สินค้า',
                    quantity AS 'จำนวน',
                    price_at_sale AS 'ราคาต่อหน่วย (รวม VAT)',
                    custom_details AS 'รายละเอียดวัตถุดิบเสริม'
                FROM OrderDetails 
                WHERE order_id = @orderId";

            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@orderId", orderId);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvOrderDetails.DataSource = dt;

                    // ปรับขนาดตารางให้สวยงาม
                    if (dgvOrderDetails.Columns.Contains("ราคาต่อหน่วย (รวม VAT)"))
                    {
                        dgvOrderDetails.Columns["ราคาต่อหน่วย (รวม VAT)"].DefaultCellStyle.Format = "N2";
                    }
                    dgvOrderDetails.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการโหลดรายละเอียดคำสั่งซื้อ: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
