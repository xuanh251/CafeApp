using System;
using System.Windows.Forms;
using CafeApp.Winform.Properties;

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
            Application.Run(new Views.FrmDangNhap());
            //KhoiTaoDonVi();
        }
        //public static void KhoiTaoDonVi()
        //{
        //    Settings.Default.TenDonVi = "Osaka Coffee";
        //    Settings.Default.DiaChi = "Lê Lợi, p.An Mỹ, tp.Tam Kỳ";
        //    Settings.Default.Slogan = "Rót cả tâm hồn vào đáy cốc!";
        //    Settings.Default.LienHe = " 098 751 77 75";
        //    Settings.Default.Save();
        //}
    }
}