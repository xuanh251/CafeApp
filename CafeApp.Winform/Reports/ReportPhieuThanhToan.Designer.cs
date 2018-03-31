namespace CafeApp.Winform.Reports
{
    partial class ReportPhieuThanhToan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportPhieuThanhToan));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrRichTextTenDonVi = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichTextDiaChi = new DevExpress.XtraReports.UI.XRRichText();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichTextTenDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichTextDiaChi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.HeightF = 100F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichTextTenDonVi,
            this.xrRichTextDiaChi});
            this.TopMargin.HeightF = 100F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrRichTextTenDonVi
            // 
            this.xrRichTextTenDonVi.Font = new System.Drawing.Font("Viner Hand ITC", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrRichTextTenDonVi.LocationFloat = new DevExpress.Utils.PointFloat(222.9167F, 10.00001F);
            this.xrRichTextTenDonVi.Name = "xrRichTextTenDonVi";
            this.xrRichTextTenDonVi.SerializableRtfString = resources.GetString("xrRichTextTenDonVi.SerializableRtfString");
            this.xrRichTextTenDonVi.SizeF = new System.Drawing.SizeF(222.9167F, 55.6979F);
            this.xrRichTextTenDonVi.StylePriority.UseFont = false;
            // 
            // xrRichTextDiaChi
            // 
            this.xrRichTextDiaChi.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrRichTextDiaChi.LocationFloat = new DevExpress.Utils.PointFloat(127.0834F, 65.69791F);
            this.xrRichTextDiaChi.Name = "xrRichTextDiaChi";
            this.xrRichTextDiaChi.SerializableRtfString = resources.GetString("xrRichTextDiaChi.SerializableRtfString");
            this.xrRichTextDiaChi.SizeF = new System.Drawing.SizeF(400.7813F, 23.00001F);
            this.xrRichTextDiaChi.StylePriority.UseFont = false;
            // 
            // ReportPhieuThanhToan
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Version = "17.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrRichTextTenDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichTextDiaChi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRRichText xrRichTextTenDonVi;
        private DevExpress.XtraReports.UI.XRRichText xrRichTextDiaChi;
    }
}
