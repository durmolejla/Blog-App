using Blog2.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog2.Data
{

        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<TblLajkovi> TblLajkovi { get; set; }
            public DbSet<TblObjave> TblObjave { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Configure entity mappings and relationships here if needed

                // Example: Configuring relationships for TblLajkovi
                modelBuilder.Entity<TblLajkovi>()
                    .HasKey(l => l.IdLike);

                modelBuilder.Entity<TblLajkovi>()
                    .HasOne(l => l.IdObjaveNavigation)
                    .WithMany()
                    .HasForeignKey(l => l.IdObjave)
                    .OnDelete(DeleteBehavior.ClientCascade); // Adjust cascade behavior as per your requirements

                base.OnModelCreating(modelBuilder);
            }
        }
    }

    
    

