namespace CafeApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editKhoaNgoai : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DinhLuong", "IdNguyenLieu", "dbo.NhomNguyenLieu");
            AddForeignKey("dbo.DinhLuong", "IdNguyenLieu", "dbo.NguyenLieu", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DinhLuong", "IdNguyenLieu", "dbo.NguyenLieu");
            AddForeignKey("dbo.DinhLuong", "IdNguyenLieu", "dbo.NhomNguyenLieu", "Id");
        }
    }
}
