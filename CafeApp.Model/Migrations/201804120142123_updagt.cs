namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updagt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NhanVien", "GioiTinh", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanVien", "GioiTinh", c => c.Boolean(nullable: false));
        }
    }
}
