namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _000 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DinhLuong", "SoLuongMon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DinhLuong", "SoLuongMon", c => c.Double(nullable: false));
        }
    }
}
