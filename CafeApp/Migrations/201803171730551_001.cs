namespace CafeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenBan = c.String(maxLength: 50),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bans");
        }
    }
}
