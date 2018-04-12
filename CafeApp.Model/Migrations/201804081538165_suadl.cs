namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suadl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhieuNhapKhoChiTiet", "GhiChu", c => c.String());
            AlterColumn("dbo.PhieuNhapKho", "ChietKhau", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhieuNhapKho", "ChietKhau", c => c.Double());
            DropColumn("dbo.PhieuNhapKhoChiTiet", "GhiChu");
        }
    }
}
