namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _000 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NguyenLieu", "GhiChu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NguyenLieu", "GhiChu", c => c.String(maxLength: 200));
        }
    }
}
