namespace CafeApp.Model.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updatecsdl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ban",
                c => new
                {
                    IdBan = c.Int(nullable: false, identity: true),
                    TenBan = c.String(nullable: false, maxLength: 50),
                    GhiChu = c.String(maxLength: 100),
                })
                .PrimaryKey(t => t.IdBan);

            CreateTable(
                "dbo.HoaDon",
                c => new
                {
                    IdHoaDon = c.Int(nullable: false, identity: true),
                    IdBan = c.Int(nullable: false),
                    NguoiTao = c.Int(nullable: false),
                    NgayTao = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    TrangThai = c.Boolean(nullable: false),
                    CaLamViec = c.String(nullable: false, maxLength: 50),
                    ChietKhau = c.Double(nullable: false),
                    GhiChu = c.String(maxLength: 200),
                })
                .PrimaryKey(t => t.IdHoaDon)
                .ForeignKey("dbo.TaiKhoan", t => t.NguoiTao)
                .ForeignKey("dbo.Ban", t => t.IdBan)
                .Index(t => t.IdBan)
                .Index(t => t.NguoiTao);

            CreateTable(
                "dbo.HoaDonChiTiet",
                c => new
                {
                    IdHoaDon = c.Int(nullable: false),
                    IdMon = c.Int(nullable: false),
                    SoLuong = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.IdHoaDon, t.IdMon })
                .ForeignKey("dbo.Mon", t => t.IdMon)
                .ForeignKey("dbo.HoaDon", t => t.IdHoaDon)
                .Index(t => t.IdHoaDon)
                .Index(t => t.IdMon);

            CreateTable(
                "dbo.Mon",
                c => new
                {
                    IdMon = c.Int(nullable: false, identity: true),
                    TenMon = c.String(nullable: false, maxLength: 100),
                    IdNhom = c.Int(nullable: false),
                    IdDVT = c.Int(nullable: false),
                    DonGia = c.Double(nullable: false),
                    GhiChu = c.String(maxLength: 100),
                })
                .PrimaryKey(t => t.IdMon)
                .ForeignKey("dbo.DonViTinh", t => t.IdDVT)
                .ForeignKey("dbo.NhomMon", t => t.IdNhom)
                .Index(t => t.IdNhom)
                .Index(t => t.IdDVT);

            CreateTable(
                "dbo.DinhLuong",
                c => new
                {
                    IdNguyenLieu = c.Int(nullable: false),
                    IdMon = c.Int(nullable: false),
                    SoLuongNguyenLieu = c.Double(nullable: false),
                })
                .PrimaryKey(t => new { t.IdNguyenLieu, t.IdMon })
                .ForeignKey("dbo.NguyenLieu", t => t.IdNguyenLieu)
                .ForeignKey("dbo.Mon", t => t.IdMon)
                .Index(t => t.IdNguyenLieu)
                .Index(t => t.IdMon);

            CreateTable(
                "dbo.NguyenLieu",
                c => new
                {
                    IdNguyenLieu = c.Int(nullable: false, identity: true),
                    TenNguyenLieu = c.String(nullable: false, maxLength: 100),
                    IdNhom = c.Int(nullable: false),
                    IdDVT = c.Int(nullable: false),
                    SoLuongTon = c.Double(nullable: false),
                    IdDVTQuyDoi = c.Int(nullable: false),
                    SoLuongQuyDoi = c.Double(nullable: false),
                    DonGia = c.Double(nullable: false),
                    GhiChu = c.String(maxLength: 200),
                })
                .PrimaryKey(t => t.IdNguyenLieu)
                .ForeignKey("dbo.DonViTinh", t => t.IdDVTQuyDoi)
                .ForeignKey("dbo.NhomNguyenLieu", t => t.IdNhom)
                .Index(t => t.IdNhom)
                .Index(t => t.IdDVTQuyDoi);

            CreateTable(
                "dbo.DonViTinh",
                c => new
                {
                    IdDVT = c.Int(nullable: false, identity: true),
                    TenDVT = c.String(maxLength: 100),
                    GhiChu = c.String(maxLength: 100),
                })
                .PrimaryKey(t => t.IdDVT);

            CreateTable(
                "dbo.NhomNguyenLieu",
                c => new
                {
                    IdNhom = c.Int(nullable: false, identity: true),
                    TenNhom = c.String(nullable: false, maxLength: 100),
                    GhiChu = c.String(maxLength: 100),
                })
                .PrimaryKey(t => t.IdNhom);

            CreateTable(
                "dbo.PhieuNhapKhoChiTiet",
                c => new
                {
                    SoHoaDon = c.String(nullable: false, maxLength: 200),
                    IdNguyenLieu = c.Int(nullable: false),
                    SoLuong = c.Int(nullable: false),
                    GhiChu = c.String(),
                })
                .PrimaryKey(t => new { t.SoHoaDon, t.IdNguyenLieu })
                .ForeignKey("dbo.PhieuNhapKho", t => t.SoHoaDon)
                .ForeignKey("dbo.NguyenLieu", t => t.IdNguyenLieu)
                .Index(t => t.SoHoaDon)
                .Index(t => t.IdNguyenLieu);

            CreateTable(
                "dbo.PhieuNhapKho",
                c => new
                {
                    SoHoaDon = c.String(nullable: false, maxLength: 200),
                    IdDoiTac = c.Int(nullable: false),
                    NgayLapPhieu = c.DateTime(nullable: false, storeType: "date"),
                    NguoiTao = c.Int(nullable: false),
                    ChietKhau = c.Double(nullable: false),
                    GhiChu = c.String(maxLength: 500),
                })
                .PrimaryKey(t => t.SoHoaDon)
                .ForeignKey("dbo.DoiTac", t => t.IdDoiTac)
                .ForeignKey("dbo.TaiKhoan", t => t.NguoiTao)
                .Index(t => t.IdDoiTac)
                .Index(t => t.NguoiTao);

            CreateTable(
                "dbo.DoiTac",
                c => new
                {
                    IdDoiTac = c.Int(nullable: false, identity: true),
                    TenDoiTac = c.String(nullable: false, maxLength: 200),
                    DiaChi = c.String(nullable: false, maxLength: 200),
                    SoDienThoai = c.String(nullable: false, maxLength: 11),
                    Email = c.String(maxLength: 100),
                    GhiChu = c.String(maxLength: 200),
                })
                .PrimaryKey(t => t.IdDoiTac);

            CreateTable(
                "dbo.TaiKhoan",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TenDangNhap = c.String(nullable: false, maxLength: 50, unicode: false),
                    MatKhau = c.String(nullable: false, maxLength: 50, unicode: false),
                    IdNhom = c.Int(nullable: false),
                    HoTen = c.String(nullable: false, maxLength: 100),
                    Email = c.String(maxLength: 100),
                    SoDienThoai = c.String(maxLength: 11),
                    GhiChu = c.String(maxLength: 200),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NhomTaiKhoan", t => t.IdNhom)
                .Index(t => t.IdNhom);

            CreateTable(
                "dbo.LichSuTruyCap",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    IdTaiKhoan = c.Int(),
                    ThoiDiemDangNhap = c.DateTime(nullable: false),
                    TrangThai = c.Boolean(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaiKhoan", t => t.IdTaiKhoan)
                .Index(t => t.IdTaiKhoan);

            CreateTable(
                "dbo.NhomTaiKhoan",
                c => new
                {
                    IdNhom = c.Int(nullable: false, identity: true),
                    TenNhom = c.String(nullable: false, maxLength: 100),
                    GhiChu = c.String(maxLength: 200),
                })
                .PrimaryKey(t => t.IdNhom);

            CreateTable(
                "dbo.NhomMon",
                c => new
                {
                    IdNhom = c.Int(nullable: false, identity: true),
                    TenNhom = c.String(nullable: false, maxLength: 100),
                    GhiChu = c.String(maxLength: 100),
                })
                .PrimaryKey(t => t.IdNhom);
        }

        public override void Down()
        {
            DropForeignKey("dbo.HoaDon", "IdBan", "dbo.Ban");
            DropForeignKey("dbo.HoaDonChiTiet", "IdHoaDon", "dbo.HoaDon");
            DropForeignKey("dbo.Mon", "IdNhom", "dbo.NhomMon");
            DropForeignKey("dbo.HoaDonChiTiet", "IdMon", "dbo.Mon");
            DropForeignKey("dbo.DinhLuong", "IdMon", "dbo.Mon");
            DropForeignKey("dbo.PhieuNhapKhoChiTiet", "IdNguyenLieu", "dbo.NguyenLieu");
            DropForeignKey("dbo.PhieuNhapKho", "NguoiTao", "dbo.TaiKhoan");
            DropForeignKey("dbo.TaiKhoan", "IdNhom", "dbo.NhomTaiKhoan");
            DropForeignKey("dbo.LichSuTruyCap", "IdTaiKhoan", "dbo.TaiKhoan");
            DropForeignKey("dbo.HoaDon", "NguoiTao", "dbo.TaiKhoan");
            DropForeignKey("dbo.PhieuNhapKhoChiTiet", "SoHoaDon", "dbo.PhieuNhapKho");
            DropForeignKey("dbo.PhieuNhapKho", "IdDoiTac", "dbo.DoiTac");
            DropForeignKey("dbo.NguyenLieu", "IdNhom", "dbo.NhomNguyenLieu");
            DropForeignKey("dbo.NguyenLieu", "IdDVTQuyDoi", "dbo.DonViTinh");
            DropForeignKey("dbo.Mon", "IdDVT", "dbo.DonViTinh");
            DropForeignKey("dbo.DinhLuong", "IdNguyenLieu", "dbo.NguyenLieu");
            DropIndex("dbo.LichSuTruyCap", new[] { "IdTaiKhoan" });
            DropIndex("dbo.TaiKhoan", new[] { "IdNhom" });
            DropIndex("dbo.PhieuNhapKho", new[] { "NguoiTao" });
            DropIndex("dbo.PhieuNhapKho", new[] { "IdDoiTac" });
            DropIndex("dbo.PhieuNhapKhoChiTiet", new[] { "IdNguyenLieu" });
            DropIndex("dbo.PhieuNhapKhoChiTiet", new[] { "SoHoaDon" });
            DropIndex("dbo.NguyenLieu", new[] { "IdDVTQuyDoi" });
            DropIndex("dbo.NguyenLieu", new[] { "IdNhom" });
            DropIndex("dbo.DinhLuong", new[] { "IdMon" });
            DropIndex("dbo.DinhLuong", new[] { "IdNguyenLieu" });
            DropIndex("dbo.Mon", new[] { "IdDVT" });
            DropIndex("dbo.Mon", new[] { "IdNhom" });
            DropIndex("dbo.HoaDonChiTiet", new[] { "IdMon" });
            DropIndex("dbo.HoaDonChiTiet", new[] { "IdHoaDon" });
            DropIndex("dbo.HoaDon", new[] { "NguoiTao" });
            DropIndex("dbo.HoaDon", new[] { "IdBan" });
            DropTable("dbo.NhomMon");
            DropTable("dbo.NhomTaiKhoan");
            DropTable("dbo.LichSuTruyCap");
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.DoiTac");
            DropTable("dbo.PhieuNhapKho");
            DropTable("dbo.PhieuNhapKhoChiTiet");
            DropTable("dbo.NhomNguyenLieu");
            DropTable("dbo.DonViTinh");
            DropTable("dbo.NguyenLieu");
            DropTable("dbo.DinhLuong");
            DropTable("dbo.Mon");
            DropTable("dbo.HoaDonChiTiet");
            DropTable("dbo.HoaDon");
            DropTable("dbo.Ban");
        }
    }
}