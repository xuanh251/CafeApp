namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PhieuNhapKhoChiTiet", "DonGia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhieuNhapKhoChiTiet", "DonGia", c => c.Double(nullable: false));
        }
    }
}
