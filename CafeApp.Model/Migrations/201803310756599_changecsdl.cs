namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecsdl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HoaDon", "ChietKhau", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HoaDon", "ChietKhau", c => c.Double());
        }
    }
}
