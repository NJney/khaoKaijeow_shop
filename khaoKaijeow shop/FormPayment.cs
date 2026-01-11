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
    public partial class FormPayment : Form
    {
        private decimal AmountDue;
        private string uploadedSlipPath = ""; // Path ชั่วคราวของไฟล์สลิปที่เลือก
        private string savedSlipFileName = ""; // Path/Name ของไฟล์ที่ถูกบันทึกถาวร (สำหรับส่งกลับ FormMyCart)

        // -----------------------------------------------------------
        // 1. Constructor
        // -----------------------------------------------------------

        public FormPayment(decimal totalAmount)
        {
            InitializeComponent();
            AmountDue = totalAmount;

            // แสดงยอดเงินที่ต้องชำระ (สมมติว่า Label ชื่อ lblPaymentDetails)
            lblPaymentDetails.Text = AmountDue.ToString("N2") + " บาท";

            btnConfirmPayment.Enabled = false;
            txtSlipFileName.ReadOnly = true;
        }

        // -----------------------------------------------------------
        // 2. Event Handler: อัปโหลดสลิป (btnUploadSlip_Click)
        // -----------------------------------------------------------

        private void btnUploadSlip_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            openFileDialog.Title = "เลือกไฟล์สลิปการโอนเงิน";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                uploadedSlipPath = openFileDialog.FileName;
                txtSlipFileName.Text = Path.GetFileName(uploadedSlipPath);

                btnConfirmPayment.Enabled = true;

                MessageBox.Show("อัปโหลดไฟล์สลิปสำเร็จ! กรุณากดยืนยันการชำระเงิน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // -----------------------------------------------------------
        // 3. Event Handler: ยืนยันการชำระเงิน (btnConfirmPayment_Click)
        // -----------------------------------------------------------

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uploadedSlipPath))
            {
                MessageBox.Show("กรุณาอัปโหลดไฟล์สลิปเพื่อยืนยันการชำระเงิน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("คุณแน่ใจหรือไม่ว่าได้ตรวจสอบยอดเงินและไฟล์สลิปแล้ว?", "ยืนยันการรับเงิน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // ** 1. บันทึกไฟล์สลิปก่อนดำเนินการต่อ **
                if (!SaveSlipFile())
                {
                    // ถ้าบันทึกไฟล์สลิปไม่สำเร็จ ให้หยุดการดำเนินการ
                    return;
                }

                // 2. ส่งสัญญาณ "ชำระเงินสำเร็จ" กลับไป FormMyCart
                // FormMyCart จะเรียกใช้ Property SavedSlipFileName ต่อไป
                this.DialogResult = DialogResult.OK;

                // 3. ปิด FormPayment
                this.Close();
            }
        }

        // -----------------------------------------------------------
        // 4. เมธอดสำหรับบันทึกไฟล์สลิป (SaveSlipFile)
        // -----------------------------------------------------------

        private bool SaveSlipFile()
        {
            try
            {
                // 1. สร้างโฟลเดอร์ OrderSlips ถ้ายังไม่มี (จะสร้างในระดับเดียวกับไฟล์ .exe)
                string targetDirectory = "OrderSlips";
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                // 2. สร้างชื่อไฟล์ใหม่ เพื่อป้องกันชื่อซ้ำ และแสดงเวลาที่อัปโหลด
                string extension = Path.GetExtension(uploadedSlipPath);
                // เช่น: Slip_Order_20251104134530.png
                savedSlipFileName = $"Slip_Order_{DateTime.Now.ToString("yyyyMMddHHmmss")}{extension}";
                string targetPath = Path.Combine(targetDirectory, savedSlipFileName);

                // 3. คัดลอกไฟล์จาก Path ชั่วคราว ไปยัง Path ถาวร
                File.Copy(uploadedSlipPath, targetPath, true);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกไฟล์สลิป: " + ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // -----------------------------------------------------------
        // 5. Public Property สำหรับให้ FormMyCart เข้าถึงชื่อไฟล์ที่บันทึก
        // -----------------------------------------------------------

        public string SavedSlipFileName
        {
            get { return savedSlipFileName; }
        }
    }
}

