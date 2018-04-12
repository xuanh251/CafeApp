namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suabang1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhieuNhapKho", "NgayLapPhieu", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhieuNhapKho", "NgayLapPhieu", c => c.DateTime(nullable: false));
        }
    }
}
