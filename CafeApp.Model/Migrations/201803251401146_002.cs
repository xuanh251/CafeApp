namespace CafeApp.Model.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LichSuTruyCap", "ThoiDiemDangNhap", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.LichSuTruyCap", "ThoiDiemDangNhap", c => c.String());
        }
    }
}