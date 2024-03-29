﻿using ApiMto.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMto.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<SrvAg> SrvAgs { get; set; }
        public DbSet<User> Users { get; set; }  
        public DbSet<Log> Logs { get; set; }
        public DbSet<DataSheet> DataSheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-460R51L\SQLEXPRESS;Initial Catalog=DeviceMtoV2; User Id=mto; Password=mto123;Trusted_Connection=false; ConnectRetryCount=0");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Server>().Ignore(c=> c.Cameras);
            modelBuilder.ApplyConfiguration(new ServerMapping());
            modelBuilder.ApplyConfiguration(new CameraMapping());
            modelBuilder.ApplyConfiguration(new LogMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
