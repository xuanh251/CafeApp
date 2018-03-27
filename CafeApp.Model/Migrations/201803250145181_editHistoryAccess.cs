namespace CafeApp.Model.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class editHistoryAccess : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LichSuTruyCap", "ThoiDiemDangNhap", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.LichSuTruyCap", "ThoiDiemDangNhap", c => c.DateTime());
        }
    }
}