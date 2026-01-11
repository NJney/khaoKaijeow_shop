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
using System.IO;

namespace khaokaijeow_shop
{
    public partial class FormAdminSalesRecords : Form
    {

        private string currentTimeFilter = "All"; // เก็บตัวกรองเวลาปัจจุบัน
        private string currentItemFilter = "All"; // เก็บตัวกรองประเภทสินค้าปัจจุบัน
        private string currentRankingType = "Data"; // เก็บสถานะว่ากำลังแสดง Data/Best/Worst

        public FormAdminSalesRecords()
        {
            InitializeComponent();

            
            cmbFilterMonth.DataSource = Enumerable.Range(1, 12)
                                                  .Select(m => new { Value = m, Name = DateTime.Parse($"2000-{m}-01").ToString("MMMM") }) // ใช้ชื่อเดือนเต็ม
                                                  .ToList();
            cmbFilterMonth.DisplayMember = "Name";
            cmbFilterMonth.ValueMember = "Value";

            // ตั้งค่าปีเริ่มต้นเป็นปีปัจจุบัน
            txtFilterYear.Text = DateTime.Now.Year.ToString();
            cmbFilterMonth.SelectedValue = DateTime.Now.Month; 

            

            LoadSalesDataGrid();

        }

        // ====================================================================
        // I. โหลดข้อมูล (Data Loading)
        // ====================================================================

        public void LoadSalesDataGrid(string timeFilter = "All", string itemTypeFilter = "All", int selectedMonth = 0, int selectedYear = 0)
        {
            // กำหนดค่าให้กับตัวแปรระดับ Class
            currentTimeFilter = timeFilter;
            currentItemFilter = itemTypeFilter;

            string timeCondition = "";
            string itemCondition = "";
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Logic การกรองเวลา
            if (timeFilter == "Week")
            {
                // 1. สัปดาห์: ย้อนหลัง 7 วันจากวันปัจจุบัน
                timeCondition = $"AND o.order_time >= DATE_SUB('{now}', INTERVAL 7 DAY)";
            }
            else if (timeFilter == "MonthSelected" && selectedMonth > 0 && selectedYear > 0)
            {
                // 2. เดือนที่เลือก: กรองตั้งแต่ต้นเดือนจนถึงสิ้นเดือนของปีที่เลือก
                string firstDayOfMonth = $"{selectedYear}-{selectedMonth}-01 00:00:00";
                // คำนวณวันสุดท้ายของเดือน (MySQL DATE_ADD)
                timeCondition = $"AND o.order_time >= '{firstDayOfMonth}' AND o.order_time < DATE_ADD('{firstDayOfMonth}', INTERVAL 1 MONTH)";
            }
            else if (timeFilter == "YearSelected" && selectedYear > 0)
            {
                // 3. ปีที่เลือก: กรองตั้งแต่ต้นปีจนถึงสิ้นปี
                string firstDayOfYear = $"{selectedYear}-01-01 00:00:00";
                timeCondition = $"AND o.order_time >= '{firstDayOfYear}' AND o.order_time < DATE_ADD('{firstDayOfYear}', INTERVAL 1 YEAR)";
            }

            // Logic การกรองประเภทสินค้า
            if (itemTypeFilter == "Menu")
            {
                // โชว์เฉพาะเมนูสำเร็จ (ไม่เอาวัตถุดิบ)
                itemCondition = "AND od.item_type IN ('Menu', 'CustomizedMenu', 'CustomNew')";
            }
            else if (itemTypeFilter == "Ingredient") // ปุ่มวัตถุดิบ
            {
                // โชว์เฉพาะวัตถุดิบ 
                itemCondition = "AND od.item_type = 'Ingredient'";
            }
            else 
            {
                itemCondition = "AND od.item_type != 'Ingredient'";
            }

            // SQL Query หลัก: ดึงรายละเอียดการสั่งซื้อทั้งหมด (OrderDetails)
            string sql = $@"
            SELECT 
            o.order_id, o.order_time, u.username, od.product_name, od.custom_details, 
            od.quantity, od.price_at_sale, 
            (od.quantity * od.price_at_sale) AS total_item_price
            FROM Orders o
            INNER JOIN Users u ON o.user_id = u.id
            INNER JOIN OrderDetails od ON o.order_id = od.order_id
            WHERE o.status = 'Completed' {timeCondition} {itemCondition}
            ORDER BY o.order_time DESC";

            // 2. ดึง Connection Object
            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataTable salesTable = new DataTable();
                    adapter.Fill(salesTable);

                    // 3. ผูกข้อมูลเข้ากับ DataGridView
                    dgvSalesRecords.DataSource = salesTable;

                    // 4. คำนวณราคารวมทั้งหมด
                    decimal totalRevenue = 0;
                    foreach (DataRow row in salesTable.Rows)
                    {
                        totalRevenue += Convert.ToDecimal(row["total_item_price"]);
                    }

                    // 5. แสดงผลราคารวม
                    lblTotalPriceSummary.Text = $"ราคารวมทั้งหมด: {totalRevenue.ToString("N0")} บาท";

                    // 6. *** ปรับแต่ง Header Text คอลัมน์ทั้งหมด ***
                    if (dgvSalesRecords.Columns.Contains("order_id"))
                        dgvSalesRecords.Columns["order_id"].HeaderText = "ID ออเดอร์";
                    if (dgvSalesRecords.Columns.Contains("order_time"))
                    {
                        dgvSalesRecords.Columns["order_time"].HeaderText = "วันที่/เวลา";
                        
                        dgvSalesRecords.Columns["order_time"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    }
                    if (dgvSalesRecords.Columns.Contains("username"))
                        dgvSalesRecords.Columns["username"].HeaderText = "ชื่อผู้ใช้";
                    if (dgvSalesRecords.Columns.Contains("product_name"))
                        dgvSalesRecords.Columns["product_name"].HeaderText = "สินค้า/เมนู";
                    if (dgvSalesRecords.Columns.Contains("custom_details"))
                        dgvSalesRecords.Columns["custom_details"].HeaderText = "รายละเอียดเสริม"; 
                    if (dgvSalesRecords.Columns.Contains("quantity"))
                        dgvSalesRecords.Columns["quantity"].HeaderText = "จำนวน";
                    if (dgvSalesRecords.Columns.Contains("price_at_sale"))
                    {
                        dgvSalesRecords.Columns["price_at_sale"].HeaderText = "ราคาต่อหน่วย";
                        dgvSalesRecords.Columns["price_at_sale"].DefaultCellStyle.Format = "N2";
                    }
                    if (dgvSalesRecords.Columns.Contains("total_item_price"))
                    {
                        dgvSalesRecords.Columns["total_item_price"].HeaderText = "ราคารวม";
                        dgvSalesRecords.Columns["total_item_price"].DefaultCellStyle.Format = "N2";
                    }
                    // *** สิ้นสุดการปรับแต่ง Header Text ***

                    // ปรับขนาดตาราง
                    dgvSalesRecords.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

                    // ให้คอลัมน์ชื่อสินค้าและรายละเอียดเสริมยืดเต็มพื้นที่
                    if (dgvSalesRecords.Columns.Contains("product_name"))
                        dgvSalesRecords.Columns["product_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (dgvSalesRecords.Columns.Contains("custom_details"))
                        dgvSalesRecords.Columns["custom_details"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading sales data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ====================================================================
        // II. การวิเคราะห์ (Ranking Logic)
        // ====================================================================

        public void LoadProductRanking(string rankingType = "Best", string itemTypeFilter = "All")
        {
            string orderBy = (rankingType == "Best") ? "DESC" : "ASC";
            string itemCondition = "";

            // === [จุดที่แก้ไข] Logic การกรองประเภทสินค้าสำหรับจัดอันดับ ===
            if (itemTypeFilter == "Menu")
            {
                // จัดอันดับเฉพาะเมนูหลัก
                itemCondition = "AND od.item_type IN ('Menu', 'CustomizedMenu', 'CustomNew')";
            }
            else if (itemTypeFilter == "Ingredient")
            {
                // จัดอันดับเฉพาะวัตถุดิบยอดฮิต
                itemCondition = "AND od.item_type = 'Ingredient'";
            }

            string sql = $@"
            SELECT 
            od.product_name, 
            SUM(od.quantity) AS total_sold 
            FROM OrderDetails od
            INNER JOIN Orders o ON od.order_id = o.order_id
            WHERE o.status = 'Completed' {itemCondition} 
            GROUP BY od.product_name
            ORDER BY total_sold {orderBy}
            LIMIT 10";

            using (MySqlConnection connection = Program.DbGlobalConnector.GetConnection())
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                    DataTable rankingTable = new DataTable();
                    adapter.Fill(rankingTable);

                    // แสดงผลลัพธ์ใน DataGridView 
                    dgvRanking.DataSource = rankingTable;

                    // [เรียกใช้ Logic วาดกราฟ pnlChartArea ที่นี่ ถ้ามี Library]

                    // ปรับชื่อคอลัมน์
                    dgvRanking.Columns["product_name"].HeaderText = "สินค้า/วัตถุดิบ";
                    dgvRanking.Columns["total_sold"].HeaderText = "จำนวนขาย";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading product ranking: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ====================================================================
        // III. Event Handlers (ปุ่มกด)
        // ====================================================================

        // 1. ปุ่มสลับประเภทสินค้า (Menu, Custom, All)
        private void btnFilterAll_Click(object sender, EventArgs e)
        {
            LoadSalesDataGrid(currentTimeFilter, "All");

            currentRankingType = "Data";
            dgvSalesRecords.Visible = true;
            dgvRanking.Visible = false;
        }

        private void btnFilterMenu_Click(object sender, EventArgs e)
        {
            LoadSalesDataGrid(currentTimeFilter, "Menu");

            currentRankingType = "Data";
            dgvSalesRecords.Visible = true;
            dgvRanking.Visible = false;
        }

        private void btnFilterIngredient_Click_1(object sender, EventArgs e)
        {
            LoadSalesDataGrid(currentTimeFilter, "Ingredient");

            currentRankingType = "Data";
            dgvSalesRecords.Visible = true;
            dgvRanking.Visible = false;
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            DataGridView dgvToExport = null;
            string fileName = "";

            // 1. ตรวจสอบว่ากำลังแสดงตารางไหนอยู่ (ใช้ currentRankingType)
            if (currentRankingType == "Data")
            {
                // กำลังแสดงข้อมูลยอดขายดิบ
                dgvToExport = dgvSalesRecords;
                fileName = "Sales_Records";
            }
            else if (currentRankingType == "Best" || currentRankingType == "Worst")
            {
                // กำลังแสดงข้อมูลจัดอันดับ
                dgvToExport = dgvRanking;
                fileName = currentRankingType + "_Ranking";
            }
            else
            {
                MessageBox.Show("ไม่สามารถ Export ข้อมูลได้: กรุณาเลือกโหมดแสดงข้อมูล (ข้อมูลดิบ หรือ จัดอันดับ)", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. เรียกใช้ Method ExportToCsv
            ExportToCsv(dgvToExport, fileName);
        }

        // 2. ปุ่มจัดอันดับ (ขายดี/ขายแย่)
        private void btnRankBest_Click(object sender, EventArgs e)
        {
            LoadProductRanking("Best", currentItemFilter); 
            currentRankingType = "Best";

            // === โค้ดที่เพิ่ม/ตรวจสอบ: สลับไปโหมดจัดอันดับ ===
            dgvSalesRecords.Visible = false;
            dgvRanking.Visible = true;
        }

        private void btnRankWorst_Click(object sender, EventArgs e)
        {
            LoadProductRanking("Worst", currentItemFilter); 
            currentRankingType = "Worst";

            dgvSalesRecords.Visible = false;
            dgvRanking.Visible = true;
        }

        private void ExportToCsv(DataGridView dgv, string fileName)
        {
            // ใช้ SaveFileDialog เพื่อให้ Admin เลือกตำแหน่งบันทึกไฟล์
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            sfd.FileName = fileName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // ใช้ System.Text.UTF8Encoding(true) เพื่อสร้าง BOM แก้ปัญหาภาษาไทย
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, new System.Text.UTF8Encoding(true)))
                    {
                        // 1. เขียน Header (ชื่อคอลัมน์)
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            if (dgv.Columns[i].Visible)
                            {
                                sw.Write(dgv.Columns[i].HeaderText + (i == dgv.Columns.Count - 1 ? "" : ","));
                            }
                        }
                        sw.WriteLine(); // ขึ้นบรรทัดใหม่

                        // 2. เขียน Data Rows
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            if (!dgv.Rows[i].IsNewRow)
                            {
                                for (int j = 0; j < dgv.Columns.Count; j++)
                                {
                                    if (dgv.Columns[j].Visible)
                                    {
                                        object cellValueObject = dgv.Rows[i].Cells[j].Value;
                                        string cellValue = "";

                                        // *** การตรวจสอบ DateTime ที่แข็งแกร่ง ***
                                        if (cellValueObject != null && cellValueObject != DBNull.Value)
                                        {
                                            if (cellValueObject is DateTime dateValue)
                                            {
                                                // Case 1: เป็น DateTime object แท้ๆ
                                                cellValue = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                                            }
                                            else if (DateTime.TryParse(cellValueObject.ToString(), out DateTime parsedDate))
                                            {
                                                // Case 2: เป็น String ที่สามารถ Parse กลับเป็น DateTime ได้
                                                cellValue = parsedDate.ToString("yyyy-MM-dd HH:mm:ss");
                                            }
                                            else
                                            {
                                                // Case 3: เป็น String หรือตัวเลขอื่นๆ
                                                cellValue = cellValueObject.ToString().Replace(",", "") ?? "";
                                            }
                                        }
                                        // ****************************************

                                        // เขียนค่าตามด้วยเครื่องหมายคอมม่า
                                        sw.Write(cellValue + (j == dgv.Columns.Count - 1 ? "" : ","));
                                    }
                                }
                                sw.WriteLine(); // ขึ้นบรรทัดใหม่เมื่อจบบรรทัดข้อมูล
                            }
                        }
                    }
                    MessageBox.Show("Export ข้อมูลสำเร็จ!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการ Export: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNavMenu_Click(object sender, EventArgs e)
        {
            // สร้าง Form Admin Dashboard ใหม่
            FormAdminDashboard adminForm = new FormAdminDashboard();

            //  ซ่อน Form Sales Records ปัจจุบัน
            this.Hide();

            //  เปิด Form Admin Dashboard
            adminForm.Show();
        }

        private void btnNavUser_Click(object sender, EventArgs e)
        {
            //  สร้าง Form จัดการผู้ใช้ใหม่
            FormAdminManageUser userForm = new FormAdminManageUser();

            //  ซ่อน Form Sales Records ปัจจุบัน
            this.Hide();

            //  เปิด Form จัดการผู้ใช้
            userForm.ShowDialog();

            //  เปิด Form Sales Records ปัจจุบัน
            this.Show();
        }

        private void btnFilterWeek_Click(object sender, EventArgs e)
        {
            // *** แก้ไข: ส่ง currentItemFilter เข้าไปในเมธอดด้วย ***
            LoadSalesDataGrid("All", currentItemFilter);

            currentRankingType = "Data";
            dgvSalesRecords.Visible = true;
            dgvRanking.Visible = false;
            lblTotalPriceSummary.Visible = true;
        }

        private void btnApplyDateFilter_Click(object sender, EventArgs e)
        {
            int year = 0;
            int month = 0;
            string filterMode = "";

            // 1. ตรวจสอบและดึงค่าปี
            if (!int.TryParse(txtFilterYear.Text.Trim(), out year) || year < 2000 || year > 2100)
            {
                MessageBox.Show("กรุณากรอกปีให้ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. ตรวจสอบว่าต้องการกรองเดือนหรือแค่ปี
            if (cmbFilterMonth.SelectedValue != null)
            {
                month = Convert.ToInt32(cmbFilterMonth.SelectedValue);
                filterMode = "MonthSelected";
            }
            else
            {
                filterMode = "YearSelected";
            }

            // 3. โหลดข้อมูลโดยใช้ Month และ Year ที่เลือก
            LoadSalesDataGrid(filterMode, currentItemFilter, month, year);

            currentRankingType = "Data";
            dgvSalesRecords.Visible = true;
            dgvRanking.Visible = false;
            lblTotalPriceSummary.Visible = true;
        }

        private void txtSearchSales_TextChanged(object sender, EventArgs e)
        {
            if (dgvSalesRecords.DataSource is DataTable dt)
            {
                string searchText = txtSearchSales.Text.Trim();
                DataView dv = dt.DefaultView;

                // 2. ถ้าช่องค้นหาว่าง -> ให้เคลียร์ตัวกรอง (แสดงทั้งหมดตามที่โหลดมา)
                if (string.IsNullOrEmpty(searchText))
                {
                    dv.RowFilter = string.Empty;
                }
                else
                {
                    // 3. กรองข้อมูล (Filter)
                    // ค้นหาใน 3 คอลัมน์: order_id, username, product_name
                    // ใช้ CONVERT เพื่อแปลงตัวเลข (order_id) เป็น string ก่อนเทียบ

                    try
                    {
                        // หมายเหตุ: syntax ของ RowFilter คล้าย SQL แต่ใช้ใน C#
                        dv.RowFilter = string.Format(
                            "CONVERT(order_id, 'System.String') LIKE '%{0}%' OR " +
                            "username LIKE '%{0}%' OR " +
                            "product_name LIKE '%{0}%'",
                            searchText);
                    }
                    catch (Exception ex)
                    {
                        // กันเหนียวเผื่อพิมพ์ตัวอักษรแปลกๆ
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}

