namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suacsdl_hoang : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NhanVien", "IdChucVu", "dbo.ChucVu");
            DropIndex("dbo.NhanVien", new[] { "IdChucVu" });
            DropColumn("dbo.HoaDonChiTiet", "DonGia");
            DropTable("dbo.ChucVu");
            DropTable("dbo.NhanVien");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        IdNhanVien = c.Int(nullable: false, identity: true),
                        HoDem = c.String(nullable: false, maxLength: 100),
                        Ten = c.String(nullable: false, maxLength: 100),
                        NgaySinh = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        GioiTinh = c.String(maxLength: 10),
                        DiaChi = c.String(maxLength: 200),
                        SoDienThoai = c.String(nullable: false, maxLength: 11),
                        Luong = c.Double(nullable: false),
                        IdChucVu = c.Int(nullable: false),
                        GhiChu = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.IdNhanVien);
            
            CreateTable(
                "dbo.ChucVu",
                c => new
                    {
                        IdChucVu = c.Int(nullable: false, identity: true),
                        Ten = c.String(maxLength: 100),
                        GhiChu = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.IdChucVu);
            
            AddColumn("dbo.HoaDonChiTiet", "DonGia", c => c.Double(nullable: false));
            CreateIndex("dbo.NhanVien", "IdChucVu");
            AddForeignKey("dbo.NhanVien", "IdChucVu", "dbo.ChucVu", "IdChucVu");
        }
    }
}
