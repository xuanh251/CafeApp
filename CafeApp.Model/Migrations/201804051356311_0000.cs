namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0000 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NguyenLieu", "GhiChu", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NguyenLieu", "GhiChu");
        }
    }
}
