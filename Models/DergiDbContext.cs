using DAboneTakip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace DergiAboneProje.Models
{
    public class DergiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json")
             .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DergiDbContext"));
        }
        public DbSet<Dergiler> Dergilers { get; set; }
        public DbSet<Uyeler> Uyelers { get; set; }
        public DbSet<Kategoriler> Kategorilers { get; set; }
        public DbSet<Abonelikler> Aboneliklers { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
