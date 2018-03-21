namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ban",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenBan = c.String(nullable: false, maxLength: 50),
                        GhiChu = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdBan = c.Int(nullable: false),
                        NguoiTao = c.Int(nullable: false),
                        NgayTao = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        TrangThai = c.Boolean(nullable: false),
                        CaLamViec = c.String(nullable: false, maxLength: 50),
                        ChietKhau = c.Double(),
                        GhiChu = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaiKhoan", t => t.NguoiTao)
                .ForeignKey("dbo.Ban", t => t.IdBan)
                .Index(t => t.IdBan)
                .Index(t => t.NguoiTao);
            
            CreateTable(
                "dbo.HoaDonChiTiet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdHoaDon = c.Int(nullable: false),
                        IdMon = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ThucDon", t => t.IdMon)
                .ForeignKey("dbo.HoaDon", t => t.IdHoaDon)
                .Index(t => t.IdHoaDon)
                .Index(t => t.IdMon);
            
            CreateTable(
                "dbo.ThucDon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 100),
                        IdNhom = c.Int(nullable: false),
                        IdDVT = c.Int(nullable: false),
                        Gia = c.Double(nullable: false),
                        GhiChu = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DonViTinh", t => t.IdDVT)
                .ForeignKey("dbo.NhomThucDon", t => t.IdNhom)
                .Index(t => t.IdNhom)
                .Index(t => t.IdDVT);
            
            CreateTable(
                "dbo.DonViTinh",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(maxLength: 100),
                        GhiChu = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NguyenLieu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 100),
                        IdNhom = c.Int(nullable: false),
                        IdDVT = c.Int(nullable: false),
                        Gia = c.Double(nullable: false),
                        GhiChu = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NhomNguyenLieu", t => t.IdNhom)
                .ForeignKey("dbo.DonViTinh", t => t.IdDVT)
                .Index(t => t.IdNhom)
                .Index(t => t.IdDVT);
            
            CreateTable(
                "dbo.NhomNguyenLieu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 100),
                        GhiChu = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhaChe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdNguyenLieu = c.Int(nullable: false),
                        TiLeNguyenLieu = c.Int(nullable: false),
                        IdMon = c.Int(nullable: false),
                        TiLeMon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NhomNguyenLieu", t => t.IdNguyenLieu)
                .ForeignKey("dbo.ThucDon", t => t.IdMon)
                .Index(t => t.IdNguyenLieu)
                .Index(t => t.IdMon);
            
            CreateTable(
                "dbo.PhieuNhapKhoChiTiet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPhieuNhapKho = c.Int(nullable: false),
                        IdNguyenLieu = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        ChietKhau = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhieuNhapKho", t => t.IdPhieuNhapKho)
                .ForeignKey("dbo.NguyenLieu", t => t.IdNguyenLieu)
                .Index(t => t.IdPhieuNhapKho)
                .Index(t => t.IdNguyenLieu);
            
            CreateTable(
                "dbo.PhieuNhapKho",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdDoiTac = c.Int(nullable: false),
                        SoHoaDon = c.String(nullable: false, maxLength: 200),
                        NgayLapPhieu = c.DateTime(nullable: false, storeType: "date"),
                        NguoiTao = c.Int(nullable: false),
                        TrangThaiPhieu = c.Boolean(nullable: false),
                        ChietKhau = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoiTac", t => t.IdDoiTac)
                .ForeignKey("dbo.TaiKhoan", t => t.NguoiTao)
                .Index(t => t.IdDoiTac)
                .Index(t => t.NguoiTao);
            
            CreateTable(
                "dbo.DoiTac",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 200),
                        DiaChi = c.String(nullable: false, maxLength: 200),
                        SoDienThoai = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 100),
                        GhiChu = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaiKhoan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenDangNhap = c.String(nullable: false, maxLength: 50, unicode: false),
                        MatKhau = c.String(nullable: false, maxLength: 50, unicode: false),
                        LoaiTaiKhoan = c.Int(nullable: false),
                        HoTen = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 100),
                        SoDienThoai = c.String(maxLength: 50),
                        GhiChu = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoaiTaiKhoan", t => t.LoaiTaiKhoan)
                .Index(t => t.LoaiTaiKhoan);
            
            CreateTable(
                "dbo.LichSuTruyCap",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTaiKhoan = c.Int(),
                        ThoiDiemDangNhap = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaiKhoan", t => t.IdTaiKhoan)
                .Index(t => t.IdTaiKhoan);
            
            CreateTable(
                "dbo.LoaiTaiKhoan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 100),
                        GhiChu = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NhomThucDon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 100),
                        GhiChu = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChucVu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(maxLength: 100),
                        GhiChu = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoDem = c.String(nullable: false, maxLength: 100),
                        Ten = c.String(nullable: false, maxLength: 100),
                        NgaySinh = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        GioiTinh = c.Boolean(nullable: false),
                        DiaChi = c.String(maxLength: 200),
                        SoDienThoai = c.String(nullable: false, maxLength: 50),
                        ChucVu = c.Int(nullable: false),
                        GhiChu = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChucVu", t => t.ChucVu)
                .Index(t => t.ChucVu);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NhanVien", "ChucVu", "dbo.ChucVu");
            DropForeignKey("dbo.HoaDon", "IdBan", "dbo.Ban");
            DropForeignKey("dbo.HoaDonChiTiet", "IdHoaDon", "dbo.HoaDon");
            DropForeignKey("dbo.PhaChe", "IdMon", "dbo.ThucDon");
            DropForeignKey("dbo.ThucDon", "IdNhom", "dbo.NhomThucDon");
            DropForeignKey("dbo.HoaDonChiTiet", "IdMon", "dbo.ThucDon");
            DropForeignKey("dbo.ThucDon", "IdDVT", "dbo.DonViTinh");
            DropForeignKey("dbo.NguyenLieu", "IdDVT", "dbo.DonViTinh");
            DropForeignKey("dbo.PhieuNhapKhoChiTiet", "IdNguyenLieu", "dbo.NguyenLieu");
            DropForeignKey("dbo.PhieuNhapKho", "NguoiTao", "dbo.TaiKhoan");
            DropForeignKey("dbo.TaiKhoan", "LoaiTaiKhoan", "dbo.LoaiTaiKhoan");
            DropForeignKey("dbo.LichSuTruyCap", "IdTaiKhoan", "dbo.TaiKhoan");
            DropForeignKey("dbo.HoaDon", "NguoiTao", "dbo.TaiKhoan");
            DropForeignKey("dbo.PhieuNhapKhoChiTiet", "IdPhieuNhapKho", "dbo.PhieuNhapKho");
            DropForeignKey("dbo.PhieuNhapKho", "IdDoiTac", "dbo.DoiTac");
            DropForeignKey("dbo.PhaChe", "IdNguyenLieu", "dbo.NhomNguyenLieu");
            DropForeignKey("dbo.NguyenLieu", "IdNhom", "dbo.NhomNguyenLieu");
            DropIndex("dbo.NhanVien", new[] { "ChucVu" });
            DropIndex("dbo.LichSuTruyCap", new[] { "IdTaiKhoan" });
            DropIndex("dbo.TaiKhoan", new[] { "LoaiTaiKhoan" });
            DropIndex("dbo.PhieuNhapKho", new[] { "NguoiTao" });
            DropIndex("dbo.PhieuNhapKho", new[] { "IdDoiTac" });
            DropIndex("dbo.PhieuNhapKhoChiTiet", new[] { "IdNguyenLieu" });
            DropIndex("dbo.PhieuNhapKhoChiTiet", new[] { "IdPhieuNhapKho" });
            DropIndex("dbo.PhaChe", new[] { "IdMon" });
            DropIndex("dbo.PhaChe", new[] { "IdNguyenLieu" });
            DropIndex("dbo.NguyenLieu", new[] { "IdDVT" });
            DropIndex("dbo.NguyenLieu", new[] { "IdNhom" });
            DropIndex("dbo.ThucDon", new[] { "IdDVT" });
            DropIndex("dbo.ThucDon", new[] { "IdNhom" });
            DropIndex("dbo.HoaDonChiTiet", new[] { "IdMon" });
            DropIndex("dbo.HoaDonChiTiet", new[] { "IdHoaDon" });
            DropIndex("dbo.HoaDon", new[] { "NguoiTao" });
            DropIndex("dbo.HoaDon", new[] { "IdBan" });
            DropTable("dbo.NhanVien");
            DropTable("dbo.ChucVu");
            DropTable("dbo.NhomThucDon");
            DropTable("dbo.LoaiTaiKhoan");
            DropTable("dbo.LichSuTruyCap");
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.DoiTac");
            DropTable("dbo.PhieuNhapKho");
            DropTable("dbo.PhieuNhapKhoChiTiet");
            DropTable("dbo.PhaChe");
            DropTable("dbo.NhomNguyenLieu");
            DropTable("dbo.NguyenLieu");
            DropTable("dbo.DonViTinh");
            DropTable("dbo.ThucDon");
            DropTable("dbo.HoaDonChiTiet");
            DropTable("dbo.HoaDon");
            DropTable("dbo.Ban");
        }
    }
}
