﻿// <auto-generated />
using GestioneSagre.Domain.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestioneSagre.Web.InternalApi.Migrations
{
    [DbContext(typeof(GestioneSagreInternalDbContext))]
    [Migration("20220827131853_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("GestioneSagre.Core.Models.Entities.VersioneEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CodiceVersione")
                        .HasColumnType("TEXT");

                    b.Property<string>("TestoVersione")
                        .HasColumnType("TEXT");

                    b.Property<string>("VersioneStato")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Versione", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
