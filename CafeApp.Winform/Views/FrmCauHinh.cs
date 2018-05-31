using CafeApp.Winform.Properties;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace CafeApp.Winform.Views
{
    public partial class FrmCauHinh : DevExpress.XtraEditors.XtraForm
    {
        public FrmCauHinh()
        {
            InitializeComponent();
            NapDuLieu();
        }

        private void BtnNapDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NapDuLieu();
        }

        private SettingsPropertyValueCollection listSettings = null;

        private void NapDuLieu()
        {
            try
            {
                listSettings = Settings.Default.PropertyValues;
                gridControlCauHinh.DataSource = listSettings;
                foreach (GridColumn item in gridViewCauHinh.Columns)
                {
                    if (item.FieldName == nameof(SettingsPropertyValue.Name) || item.FieldName == nameof(SettingsPropertyValue.PropertyValue))
                    {
                        item.Visible = true;
                    }
                    else
                    {
                        item.Visible = false;
                    }
                }
                gridViewCauHinh.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void Luu()
        {
            try
            {
                gridViewCauHinh.FocusedColumn = gridViewCauHinh.Columns[nameof(SettingsPropertyValue.Name)];
                if (listSettings == null) return;
                Settings.Default.Save();
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Settings.Default.Skin;
                XtraMessageBox.Show("Đã lưu thay đổi!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Lưu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridViewCauHinh_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == nameof(SettingsPropertyValue.PropertyValue) && gridViewCauHinh.GetRowCellValue(e.RowHandle, nameof(SettingsPropertyValue.Name)).ToString() == nameof(Settings.Default.Skin))
                {
                    var r = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                    foreach (SkinContainer cnt in SkinManager.Default.Skins)
                    {
                        r.Items.Add(cnt.SkinName);
                    }
                    r.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    e.RepositoryItem = r;
                    return;
                }

                e.RepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            }
            catch (Exception)
            {
            }
        }

        private void BtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Luu();
        }
    }
}