using Microsoft.EntityFrameworkCore;
using ArtistService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistService.Data.Database
{
    public class ArtistContext : DbContext
    {
        public ArtistContext()
        {

        }
        public virtual DbSet<Artist> Artist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=ArtistMicroService; Integrated Security=SSPI");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.ArtistID);

                entity.Property(e => e.ArtistName).IsRequired();
            });
        }
    }
}
