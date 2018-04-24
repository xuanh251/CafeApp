namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suasdt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DoiTac", "SoDienThoai", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DoiTac", "SoDienThoai", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
