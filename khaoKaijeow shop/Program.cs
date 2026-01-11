using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using khaokaijeow_shop;

namespace khaokaijeow_shop
{
    internal static class Program
    {
        // 1. สร้าง DBConnector เป็นตัวแปร Static
        public static DBConnector DbGlobalConnector;
        public static int CurrentUserID { get; set; } = 0;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 2. สร้าง Object DBConnector เพียงครั้งเดียวเมื่อโปรแกรมเริ่ม
            DbGlobalConnector = new DBConnector();

            // 3. เริ่มต้นด้วย FormLogin
            Application.Run(new FormLogin());
        }
    }
}
