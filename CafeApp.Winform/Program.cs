using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CafeApp.Winform
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            Application.Run(new Views.FrmDangNhap());
            //KhoiTaoDonVi();
        }

        //public static void KhoiTaoDonVi()
        //{
        //    Settings.Default.TenDonVi = "OSAKA COFFEE";
        //    Settings.Default.DiaChi = "Lê Lợi, p.An Mỹ, tp.Tam Kỳ";
        //    Settings.Default.Slogan = "Rót cả tâm hồn vào đáy cốc!";
        //    Settings.Default.LienHe = "0987.517.775 - 0969.291.744";
        //    Settings.Default.Save();
        //}
    }
}