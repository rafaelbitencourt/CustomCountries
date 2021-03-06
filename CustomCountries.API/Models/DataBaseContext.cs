using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace CustomCountries.API.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        private const string StringConnection = "Host=ec2-54-90-13-87.compute-1.amazonaws.com;Port=5432;Database=dcjrgssurdame0;User Id=rjbvdhzkqpeqci;Password=b5255cfce087f217907f291058cca98c4770e877ecb7032a76b2f6c8838e7a3b;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(new NpgsqlConnection(StringConnection));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(x => x.NumericCode).HasColumnName("id");
                entity.Property(x => x.Area).HasColumnName("area");
                entity.Property(x => x.Population).HasColumnName("population");
                entity.Property(x => x.PopulationDensity).HasColumnName("populationdensity");
                entity.Property(x => x.Capital).HasColumnName("capital");

                entity.HasKey(x => x.NumericCode);
            });
        }
    }
}
