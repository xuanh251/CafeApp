namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suaCsdl_lann : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhieuNhapKhoChiTiet", "IdPhieuNhapKho", "dbo.PhieuNhapKho");
            DropIndex("dbo.PhieuNhapKhoChiTiet", new[] { "IdPhieuNhapKho" });
            RenameColumn(table: "dbo.PhieuNhapKhoChiTiet", name: "IdPhieuNhapKho", newName: "SoHoaDon");
            DropPrimaryKey("dbo.PhieuNhapKhoChiTiet");
            DropPrimaryKey("dbo.PhieuNhapKho");
            AddColumn("dbo.PhieuNhapKhoChiTiet", "DonGia", c => c.Double(nullable: false));
            AlterColumn("dbo.PhieuNhapKhoChiTiet", "SoHoaDon", c => c.String(nullable: false, maxLength: 200));
            AddPrimaryKey("dbo.PhieuNhapKhoChiTiet", new[] { "SoHoaDon", "IdNguyenLieu" });
            AddPrimaryKey("dbo.PhieuNhapKho", "SoHoaDon");
            CreateIndex("dbo.PhieuNhapKhoChiTiet", "SoHoaDon");
            AddForeignKey("dbo.PhieuNhapKhoChiTiet", "SoHoaDon", "dbo.PhieuNhapKho", "SoHoaDon");
            DropColumn("dbo.PhieuNhapKhoChiTiet", "ChietKhau");
            DropColumn("dbo.PhieuNhapKho", "IdPhieu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhieuNhapKho", "IdPhieu", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.PhieuNhapKhoChiTiet", "ChietKhau", c => c.Double());
            DropForeignKey("dbo.PhieuNhapKhoChiTiet", "SoHoaDon", "dbo.PhieuNhapKho");
            DropIndex("dbo.PhieuNhapKhoChiTiet", new[] { "SoHoaDon" });
            DropPrimaryKey("dbo.PhieuNhapKho");
            DropPrimaryKey("dbo.PhieuNhapKhoChiTiet");
            AlterColumn("dbo.PhieuNhapKhoChiTiet", "SoHoaDon", c => c.Int(nullable: false));
            DropColumn("dbo.PhieuNhapKhoChiTiet", "DonGia");
            AddPrimaryKey("dbo.PhieuNhapKho", "IdPhieu");
            AddPrimaryKey("dbo.PhieuNhapKhoChiTiet", new[] { "IdPhieuNhapKho", "IdNguyenLieu" });
            RenameColumn(table: "dbo.PhieuNhapKhoChiTiet", name: "SoHoaDon", newName: "IdPhieuNhapKho");
            CreateIndex("dbo.PhieuNhapKhoChiTiet", "IdPhieuNhapKho");
            AddForeignKey("dbo.PhieuNhapKhoChiTiet", "IdPhieuNhapKho", "dbo.PhieuNhapKho", "IdPhieu");
        }
    }
}
