using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //DbSet
        public DbSet<HoSo> Hosos { get; set; }
        public DbSet<DatLich> DatLichs { get; set; }
        public DbSet<PhongKham> PhongKhams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //1..n giữa HoSo và DatLich
            modelBuilder.Entity<DatLich>()
               .HasOne(dl => dl.HoSo)
               .WithMany(hs => hs.DatLichs)
               .HasForeignKey(dl => dl.MaHoSo);

            //1..1 giữa PhongKham và DatLich
            modelBuilder.Entity<PhongKham>()
                .HasOne(pk => pk.DatLich)
                .WithOne(dl => dl.PhongKham)
                .HasForeignKey<DatLich>(dl => dl.IdPhong)
                .OnDelete(DeleteBehavior.Restrict);// Khi có liên kết không xóa PhongKham
        }
    }
}
