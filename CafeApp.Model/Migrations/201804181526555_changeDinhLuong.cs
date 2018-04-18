namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDinhLuong : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DinhLuong", "SoLuongNguyenLieu", c => c.Double(nullable: false));
            AlterColumn("dbo.DinhLuong", "SoLuongMon", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DinhLuong", "SoLuongMon", c => c.Int(nullable: false));
            AlterColumn("dbo.DinhLuong", "SoLuongNguyenLieu", c => c.Int(nullable: false));
        }
    }
}
