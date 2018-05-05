namespace CafeApp.Model.Models
{
    using System.Data.Entity;

    public partial class ModelQuanLiCafeDbContext : DbContext
    {
        public ModelQuanLiCafeDbContext()
            : base("CafeApp.Winform.Properties.Settings.ModelQuanLiCafe")
        {
        }

        public virtual DbSet<Ban> Bans { get; set; }

        public virtual DbSet<DoiTac> DoiTacs { get; set; }
        public virtual DbSet<DonViTinh> DonViTinhs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual DbSet<LichSuTruyCap> LichSuTruyCaps { get; set; }
        public virtual DbSet<NhomTaiKhoan> NhomTaiKhoans { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieux { get; set; }
        public virtual DbSet<NhomNguyenLieu> NhomNguyenLieux { get; set; }
        public virtual DbSet<NhomMon> NhomMons { get; set; }
        public virtual DbSet<DinhLuong> DinhLuongs { get; set; }
        public virtual DbSet<PhieuNhapKho> PhieuNhapKhoes { get; set; }
        public virtual DbSet<PhieuNhapKhoChiTiet> PhieuNhapKhoChiTiets { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<Mon> Mons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ban>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.Ban)
                .HasForeignKey(e => e.IdBan)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<DoiTac>()
                .HasMany(e => e.PhieuNhapKhoes)
                .WithRequired(e => e.DoiTac)
                .HasForeignKey(e => e.IdDoiTac)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<DonViTinh>()
                .HasMany(e => e.NguyenLieux)
                .WithRequired(e => e.DonViTinh)
                .HasForeignKey(e => e.IdDVTQuyDoi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonViTinh>()
                .HasMany(e => e.Mons)
                .WithRequired(e => e.DonViTinh)
                .HasForeignKey(e => e.IdDVT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.HoaDonChiTiets)
                .WithRequired(e => e.HoaDon)
                .HasForeignKey(e => e.IdHoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhomTaiKhoan>()
                .HasMany(e => e.TaiKhoans)
                .WithRequired(e => e.NhomTaiKhoan)
                .HasForeignKey(e => e.IdNhom)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguyenLieu>()
                .HasMany(e => e.PhieuNhapKhoChiTiets)
                .WithRequired(e => e.NguyenLieu)
                .HasForeignKey(e => e.IdNguyenLieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhomNguyenLieu>()
                .HasMany(e => e.NguyenLieux)
                .WithRequired(e => e.NhomNguyenLieu)
                .HasForeignKey(e => e.IdNhom)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguyenLieu>()
                .HasMany(e => e.DinhLuongs)
                .WithRequired(e => e.NguyenLieu)
                .HasForeignKey(e => e.IdNguyenLieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhomMon>()
                .HasMany(e => e.Mons)
                .WithRequired(e => e.NhomMon)
                .HasForeignKey(e => e.IdNhom)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuNhapKho>()
                .HasMany(e => e.PhieuNhapKhoChiTiets)
                .WithRequired(e => e.PhieuNhapKho)
                .HasForeignKey(e => e.SoHoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.NguoiTao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.LichSuTruyCaps)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.IdTaiKhoan);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.PhieuNhapKhoes)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.NguoiTao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mon>()
                .HasMany(e => e.HoaDonChiTiets)
                .WithRequired(e => e.Mon)
                .HasForeignKey(e => e.IdMon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mon>()
                .HasMany(e => e.DinhLuongs)
                .WithRequired(e => e.Mon)
                .HasForeignKey(e => e.IdMon)
                .WillCascadeOnDelete(false);
        }
    }
}