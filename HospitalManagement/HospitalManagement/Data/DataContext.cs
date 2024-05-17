using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //DbSet
        #region DbSet
        public DbSet<HoSo> Hosos { get; set; }
        public DbSet<DatLich> DatLichs { get; set; }
        public DbSet<PhongKham> PhongKhams { get; set; }
        public DbSet<QuocTich> QuocTichs { get; set; }
        public DbSet<DanToc> DanTocs { get; set; }
        public DbSet<NgheNghiep> NgheNghieps { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1..n giữa HoSo và DatLich
            modelBuilder.Entity<HoSo>()
                .HasMany(h => h.DatLichs)
                .WithOne(d => d.HoSo)
                .HasForeignKey(d => d.MaHoSo);


            //1..1 giữa PhongKham và DatLich
            //modelBuilder.Entity<PhongKham>()
            //    .HasOne(pk => pk.DatLich)
            //    .WithOne(dl => dl.PhongKham)
            //    .HasForeignKey<DatLich>(dl => dl.IdPhong)
            //    .OnDelete(DeleteBehavior.Restrict);// Khi có liên kết không xóa PhongKham

            modelBuilder.Entity<PhongKham>()
                .HasMany(pk => pk.DatLichs)
                .WithOne(dl => dl.PhongKham)
                .HasForeignKey(dl => dl.IdPhong);

            //1..1 giữa DanToc và DatLich
            //modelBuilder.Entity<DanToc>()
            //    .HasOne(dl => dl.DatLich)
            //    .WithOne(dt => dt.DanToc)
            //    .HasForeignKey<DatLich>(dl => dl.IdDanToc)
            //    .OnDelete(DeleteBehavior.Restrict);// Khi có liên kết không xóa DanToc

            //1..1 giữa NgheNghiep và DatLich
            //modelBuilder.Entity<PhongKham>()
            //    .HasOne(pk => pk.DatLich)
            //    .WithOne(dl => dl.PhongKham)
            //    .HasForeignKey<DatLich>(dl => dl.IdNgheNghiep)
            //    .OnDelete(DeleteBehavior.Restrict);// Khi có liên kết không xóa DanToc

            base.OnModelCreating(modelBuilder);
        }
    }
}
