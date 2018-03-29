namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _005 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ThucDon", "DonGia", c => c.Double(nullable: false));
            DropColumn("dbo.ThucDon", "Gia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ThucDon", "Gia", c => c.Double(nullable: false));
            DropColumn("dbo.ThucDon", "DonGia");
        }
    }
}
