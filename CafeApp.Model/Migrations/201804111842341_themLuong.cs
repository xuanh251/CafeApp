namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themLuong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanVien", "Luong", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanVien", "Luong");
        }
    }
}
