﻿// <auto-generated />
using GestioneSagre.Domain.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestioneSagre.Web.Migrations.Migrations
{
    [DbContext(typeof(GestioneSagreDbContext))]
    [Migration("20220814163607_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("GestioneSagre.Core.Models.Entities.FestaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataFine")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataInizio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Edizione")
                        .HasColumnType("TEXT");

                    b.Property<bool>("GestioneCoperti")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("GestioneMenu")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GuidFesta")
                        .HasColumnType("TEXT");

                    b.Property<string>("Logo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Luogo")
                        .HasColumnType("TEXT");

                    b.Property<bool>("StampaCarta")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("StampaLogo")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("StampaRicevuta")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusFesta")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titolo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Festa", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
