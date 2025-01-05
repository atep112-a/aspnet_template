using ApiBarang.Model;
using ApiUsers.Data.Configurations;
using ApiUsers.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiUsers.Data
{
    public class AppDbContext : DbContext
    {
     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UsersModel> Users { get; set; }
        public DbSet<BarangModel> Barangs { get; set; }
        public DbSet<TransaksiModel> Transaksi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransaksiConfiguration());
        }
    }
}
