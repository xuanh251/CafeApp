namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePhaChe : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PhaChe", newName: "DinhLuong");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DinhLuong", newName: "PhaChe");
        }
    }
}
