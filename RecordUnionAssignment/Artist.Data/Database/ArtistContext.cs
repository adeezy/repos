using Microsoft.EntityFrameworkCore;
using Artist.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artist.Data.Database
{
    public class ArtistContext : DbContext
    {
        public ArtistContext()
        {

        }
        public virtual DbSet<Domain.Artist> Artist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=ArtistMicroService; Integrated Security=SSPI");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Domain.Artist>(entity =>
            {
                entity.Property(e => e.ArtistID);

                entity.Property(e => e.ArtistName).IsRequired();
            });
        }
    }
}
