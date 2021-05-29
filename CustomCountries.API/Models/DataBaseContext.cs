using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;

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
            options.UseNpgsql(new NpgsqlConnection(GetConnectionString()));
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

        private string GetConnectionString()
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString_CustomCountries", EnvironmentVariableTarget.Machine);

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("String de conexão não informada (Variável de ambiente: ConnectionString_CustomCountries).");

            return connectionString;
        }
    }
}
