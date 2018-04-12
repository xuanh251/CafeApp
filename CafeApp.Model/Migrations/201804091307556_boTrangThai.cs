namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boTrangThai : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PhieuNhapKho", "TrangThaiPhieu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhieuNhapKho", "TrangThaiPhieu", c => c.Boolean(nullable: false));
        }
    }
}
