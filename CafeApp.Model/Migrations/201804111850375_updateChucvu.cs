namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateChucvu : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.NhanVien", name: "ChucVu", newName: "IdChucVu");
            RenameIndex(table: "dbo.NhanVien", name: "IX_ChucVu", newName: "IX_IdChucVu");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.NhanVien", name: "IX_IdChucVu", newName: "IX_ChucVu");
            RenameColumn(table: "dbo.NhanVien", name: "IdChucVu", newName: "ChucVu");
        }
    }
}
