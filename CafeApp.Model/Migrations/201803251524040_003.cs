namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TaiKhoan", name: "LoaiTaiKhoan", newName: "QuyenSuDung");
            RenameIndex(table: "dbo.TaiKhoan", name: "IX_LoaiTaiKhoan", newName: "IX_QuyenSuDung");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TaiKhoan", name: "IX_QuyenSuDung", newName: "IX_LoaiTaiKhoan");
            RenameColumn(table: "dbo.TaiKhoan", name: "QuyenSuDung", newName: "LoaiTaiKhoan");
        }
    }
}
