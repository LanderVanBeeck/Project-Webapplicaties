using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Webapplicaties.Areas.Identity.Data;
using Project_Webapplicaties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Data
{
    public class ProjectContext : IdentityDbContext<CustomUser>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<LineUp> LineUp { get; set; }
        public DbSet<Artiest> Artiesten { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruiker");
            modelBuilder.Entity<Ticket>().ToTable("Ticket").Property(p => p.Prijs).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<LineUp>().ToTable("LineUp");
            modelBuilder.Entity<Artiest>().ToTable("Artiest");
            modelBuilder.Entity<Bestelling>().ToTable("Bestelling").Property(p => p.TotaalBedrag).HasColumnType("decimal(18,2)");
        }
    }
}
