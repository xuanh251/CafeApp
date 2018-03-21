namespace CafeApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class cafeDbContext : DbContext
    {
        public cafeDbContext()
            : base("name=cafeDbContext")
        {
        }
        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<PhieuBanHang> PhieuBanHangs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ban>()
                .HasMany(e => e.PhieuBanHangs)
                .WithRequired(e => e.Ban)
                .HasForeignKey(e => e.IdBan).WillCascadeOnDelete(false);
        }
    }
}
