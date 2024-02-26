using System;
using _16_Eylul_Kariyet_net.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _16_Eylul_Kariyet_net.Concrete
{
	public class Context:IdentityDbContext<Kullanici>
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=localhost;Database=16_EYLUL_KARIYERDB;Uid=sa;password=reallyStrongPwd123;TrustServerCertificate=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Jobs>( b =>
            {
                b.HasOne(C=>C.Firma)
                    .WithMany(f=>f.Jobses)
                    .HasForeignKey(j=>j.FirmaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(); 
            }); 
        }

        public DbSet<CalismaTuru> CalismaTurus { get; set; }

        public DbSet<Firma> Firmas { get; set; }
        
        public DbSet<IsArayan> IsArayans { get; set; }
        public DbSet<Jobs> Jobses { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Sehir> Sehirs { get; set; }
        public DbSet<Ulke> Ulkes { get; set; }
        public DbSet<Carousel> Carousels { get; set; }

        public DbSet<BasvuruLog> BasvuruLogs { get; set; }
    }
}

