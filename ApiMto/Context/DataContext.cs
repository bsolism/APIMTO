using ApiMto.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMto.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-460R51L\SQLEXPRESS;Initial Catalog=app-mtoDb;Trusted_Connection=true; ConnectRetryCount=0");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ServerMapping());
            modelBuilder.ApplyConfiguration(new CameraMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
