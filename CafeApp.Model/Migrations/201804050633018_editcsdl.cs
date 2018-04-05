namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editcsdl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NguyenLieu", "SoLuongQuyDoi", c => c.Double(nullable: false));
            DropColumn("dbo.NguyenLieu", "SoLuongTonQuyDoi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NguyenLieu", "SoLuongTonQuyDoi", c => c.Double(nullable: false));
            DropColumn("dbo.NguyenLieu", "SoLuongQuyDoi");
        }
    }
}
