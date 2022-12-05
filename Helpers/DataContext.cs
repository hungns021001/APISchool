using APISchool.Entity;
using Microsoft.EntityFrameworkCore;

namespace APISchool.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {}

        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<Diem> Diems { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<Khoa> Khoas { get; set; }
    }
}
