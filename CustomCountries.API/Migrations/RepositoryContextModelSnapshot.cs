﻿// <auto-generated />
using CustomCountries.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CustomCountries.API.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CustomCountries.API.Models.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<float>("Area")
                        .HasColumnType("numeric")
                        .HasColumnName("area");

                    b.Property<string>("Capital")
                        .HasColumnType("text")
                        .HasColumnName("capital");

                    b.Property<float>("Population")
                        .HasColumnType("numeric")
                        .HasColumnName("population");

                    b.Property<float>("PopulationDensity")
                        .HasColumnType("numeric")
                        .HasColumnName("populationdensity");

                    b.HasKey("Id");

                    b.ToTable("country");
                });
#pragma warning restore 612, 618
        }
    }
}
