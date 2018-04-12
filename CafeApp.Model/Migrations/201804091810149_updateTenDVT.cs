namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTenDVT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonViTinh", "TenDVT", c => c.String(maxLength: 100));
            DropColumn("dbo.DonViTinh", "Ten");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DonViTinh", "Ten", c => c.String(maxLength: 100));
            DropColumn("dbo.DonViTinh", "TenDVT");
        }
    }
}
