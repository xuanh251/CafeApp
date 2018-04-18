namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upadtetk : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaiKhoan", "SoDienThoai", c => c.String(maxLength: 11));
            AlterColumn("dbo.NhanVien", "SoDienThoai", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanVien", "SoDienThoai", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.TaiKhoan", "SoDienThoai", c => c.String(maxLength: 50));
        }
    }
}
