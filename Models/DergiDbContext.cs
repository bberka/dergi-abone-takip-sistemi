using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DergiAboneProje.Models
{
    public class DergiDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-F9KH9U2\\SQLEXPRESS;database=DAboneTakipProje; integrated security= true;");
        }
        public DbSet<Dergiler> Dergilers { get; set; }
        public DbSet<Uyeler> Uyelers { get; set; }
        public DbSet<Kategoriler> Kategorilers { get; set; }
        public DbSet<Abonelikler> Aboneliklers { get; set; }
        
    }
}
