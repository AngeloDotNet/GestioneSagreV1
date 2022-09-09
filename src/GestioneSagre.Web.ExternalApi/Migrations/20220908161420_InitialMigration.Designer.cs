﻿// <auto-generated />
using GestioneSagre.Domain.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestioneSagre.Web.ExternalApi.Migrations
{
    [DbContext(typeof(GestioneSagreExternalDbContext))]
    [Migration("20220908161420_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("GestioneSagre.Core.Models.Entities.PrenotazioneDettaglioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrenotazioneId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Prodotto")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantita")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PrenotazioneDettaglio", (string)null);
                });

            modelBuilder.Entity("GestioneSagre.Core.Models.Entities.PrenotazioneEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataPrenotazione")
                        .HasColumnType("TEXT");

                    b.Property<string>("GuidFesta")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nominativo")
                        .HasColumnType("TEXT");

                    b.Property<string>("OraPrenotazione")
                        .HasColumnType("TEXT");

                    b.Property<string>("Riferimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("StatoPrenotazione")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Prenotazione", (string)null);
                });

            modelBuilder.Entity("GestioneSagre.Core.Models.Entities.PrenotazioneDettaglioEntity", b =>
                {
                    b.OwnsOne("GestioneSagre.Tools.ValueObjects.Money", "Prezzo", b1 =>
                        {
                            b1.Property<int>("PrenotazioneDettaglioEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<float>("Amount")
                                .HasColumnType("REAL");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("PrenotazioneDettaglioEntityId");

                            b1.ToTable("PrenotazioneDettaglio");

                            b1.WithOwner()
                                .HasForeignKey("PrenotazioneDettaglioEntityId");
                        });

                    b.OwnsOne("GestioneSagre.Tools.ValueObjects.Money", "Totale", b1 =>
                        {
                            b1.Property<int>("PrenotazioneDettaglioEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<float>("Amount")
                                .HasColumnType("REAL");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("PrenotazioneDettaglioEntityId");

                            b1.ToTable("PrenotazioneDettaglio");

                            b1.WithOwner()
                                .HasForeignKey("PrenotazioneDettaglioEntityId");
                        });

                    b.Navigation("Prezzo");

                    b.Navigation("Totale");
                });
#pragma warning restore 612, 618
        }
    }
}
