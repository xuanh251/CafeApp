namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NguyenLieu", "SoLuong", c => c.Int(nullable: false));
            AddColumn("dbo.NguyenLieu", "DonGia", c => c.Double(nullable: false));
            DropColumn("dbo.NguyenLieu", "Gia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NguyenLieu", "Gia", c => c.Double(nullable: false));
            DropColumn("dbo.NguyenLieu", "DonGia");
            DropColumn("dbo.NguyenLieu", "SoLuong");
        }
    }
}
