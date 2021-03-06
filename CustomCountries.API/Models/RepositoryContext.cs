using Microsoft.EntityFrameworkCore;

namespace CustomCountries.API.Models
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.Area).HasColumnName("area");
                entity.Property(x => x.Population).HasColumnName("population");
                entity.Property(x => x.PopulationDensity).HasColumnName("populationdensity");
                entity.Property(x => x.Capital).HasColumnName("capital");

                entity.HasKey(x => x.Id);
            });
        }
    }
}
