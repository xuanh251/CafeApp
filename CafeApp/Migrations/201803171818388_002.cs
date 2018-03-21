namespace CafeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhieuBanHangs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdBan = c.Int(nullable: false),
                        NgayLapPhieu = c.DateTime(nullable: false),
                        GhiChu = c.String(),
                        TrangThaiPhieu = c.Boolean(nullable: false),
                        CaLamViec = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bans", t => t.IdBan)
                .Index(t => t.IdBan);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhieuBanHangs", "IdBan", "dbo.Bans");
            DropIndex("dbo.PhieuBanHangs", new[] { "IdBan" });
            DropTable("dbo.PhieuBanHangs");
        }
    }
}
