using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace CustomCountries.API.Models
{
    public class DataBaseContext : DbContext
    {
        IConfiguration _configuration;
        public DbSet<Country> Countries { get; set; }

        public DataBaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(new NpgsqlConnection(_configuration.GetConnectionString("CustomCountriesDB")));
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
