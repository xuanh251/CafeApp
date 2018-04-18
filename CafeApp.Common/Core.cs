using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CafeApp.Model.Models;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;

namespace CafeApp.Common
{
    public class Core
    {
        public static List<string> CaLamViecs = new List<string> { "Sáng", "Chiều", "Tối" };
        public const string MatKhauMacDinh = "123456";
        public const string NullData = "Không có dữ liệu";
        private static readonly string PasswordHash = "P@@Sw0rd";
        private static readonly string SaltKey = "S@LT&KEY";
        private static readonly string VIKey = "@1B2c3D4e5F6g7H8";
        public static int Admin = 1;
        public static int Seller = 2;
        public static string SetCaLamViec()
        {
            if (DateTime.Now.Hour<=11) return CaLamViecs[0];
            if (DateTime.Now.Hour <= 17) return CaLamViecs[1];
            else return CaLamViecs[2];
        }
        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
        public static void SaoLuuDuLieu()
        {
            try
            {
                var folder = new FolderBrowserDialog();
                if (folder.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                using (ModelQuanLiCafeDbContext tempDb = new ModelQuanLiCafeDbContext())
                {
                    string dbName = tempDb.Database.Connection.Database;
                    string backupPath = string.Concat(folder.SelectedPath, "\\", dbName, "_", DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss"), ".bak");
                    string sql = string.Concat(@"BACKUP DATABASE ", dbName, @" TO DISK = '", backupPath, "' WITH NOFORMAT, COMPRESSION,NOINIT, NAME = N'", dbName, "-Full Database Backup', SKIP, STATS = 10;");
                    int count = tempDb.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sql);
                    XtraMessageBox.Show("Đã sao lưu thành công dữ liệu " + dbName + " tại đường dẫn " + backupPath, "Sao lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(folder.SelectedPath);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Sao lưu dữ liệu",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public static void XuatHinhAnh(ChartControl chartControl)
        {
            var folder = new FolderBrowserDialog();
            if (folder.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var fileName = string.Concat(Guid.NewGuid().ToString(), ".jpg");
            string exportFilePath = string.Concat(folder.SelectedPath, "\\", Guid.NewGuid().ToString(), "_", DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss"), ".jpg");
            //string exportFilePath = string.Concat(Application.StartupPath, @"\", fileName);
            ImageFormat image = ImageFormat.Jpeg;
            chartControl.ExportToImage(exportFilePath, image);
            if (File.Exists(exportFilePath))
            {
                XtraMessageBox.Show("Xuất hình ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(folder.SelectedPath);
            }
        }

    }
    public class VNCurrency
    {
        public static string ToString(decimal number)
        {
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;
            string str = " ";
            bool booAm = false;
            decimal decS = 0;
            //Tung addnew
            try
            {
                decS = Convert.ToDecimal(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    str = " " + str;
                }
            }
            if (booAm) str = "Âm " + str;
            return str + "đồng chẵn";
        }

        public static string ToString(double number)
        {
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;
            string str = "";
            bool booAm = false;
            double decS = 0;
            //Tung addnew
            try
            {
                decS = Convert.ToDouble(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;

            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;

                    if (i > 0)
                    {
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    }
                    else
                        tram = -1;
                    i--;

                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        //str = hang[j] + str;

                        //Mới thêm để phân dấu phẩy giữa các hàng chục, nghìn, đơn vị...
                        if (i < s.Length - 3)
                        {
                            if (Convert.ToInt32(s.Substring(i + 3, 1)) > 0 || Convert.ToInt32(s.Substring(i + 4, 1)) > 0 || Convert.ToInt32(s.Substring(i + 5, 1)) > 0)
                                str = hang[j] + "," + str;
                            else
                                str = hang[j] + str;
                        }
                        else str = hang[j] + str;
                    else if ((donvi == 0) && (chuc == 0) && (tram == 0) && (j > 0))
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                            if (str.Substring(0, 2) != " ,")
                                str = "," + str;
                    }
                    //Kết thúc đoạn mới thêm

                    j++;

                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "mốt " + str;

                    else if ((donvi == 1) && (chuc == 1))
                    {
                        str = "một " + str;
                    }
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }

                    str = " " + str;

                }
            }
            if (booAm) str = "Âm " + str;

            Regex reg = new Regex(@"\s+");
            str = reg.Replace(str.Replace(" ,", ",").TrimStart(), @" ");

            return VNString.UppercaseFirst(str) + "đồng chẵn";
        }
    }
    public class VNString
    {
        public static string boDauTiengViet(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            str = str.Replace(" ", "");
            //Agile tôn trọng bản quyền của tác giả
            //code by phoenix - www.laptrinh.vn - 09-10-2014
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = str.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty)
                        .Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public static string UppercaseFirst(string s)
        {

            char[] array = s.ToCharArray();

            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsUpper(array[i]))
                    {
                        array[i] = char.ToLower(array[i]);
                    }
                }
            }
            return new string(array);
        }

        public static string DateToString(DateTime d)
        {
            return (string.Concat("ngày ", d.Day.ToString(), " tháng ", d.Month.ToString(), " năm ", d.Year.ToString()));
        }
    }
}