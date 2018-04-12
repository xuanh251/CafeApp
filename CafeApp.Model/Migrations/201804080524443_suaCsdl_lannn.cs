namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suaCsdl_lannn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhieuNhapKho", "GhiChu", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhieuNhapKho", "GhiChu");
        }
    }
}
