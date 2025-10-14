using System;
using System.Windows.Forms;

namespace CNPM_Project
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
       
            // Khởi chạy form menu chính
            Application.Run(new frmMenuChinh());
        }
    }
}