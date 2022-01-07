﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_Webapplicaties.Data;

namespace Project_Webapplicaties.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20220107082424_migration3")]
    partial class migration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project_Webapplicaties.Models.Artiest", b =>
                {
                    b.Property<int>("ArtiestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LineUpID")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtiestID");

                    b.HasIndex("LineUpID");

                    b.ToTable("Artiest");
                });

            modelBuilder.Entity("Project_Webapplicaties.Models.Bestelling", b =>
                {
                    b.Property<int>("BestellingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GebruikerID")
                        .HasColumnType("int");

                    b.Property<int>("TicketID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotaalBedrag")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BestellingID");

                    b.HasIndex("GebruikerID");

                    b.ToTable("Bestelling");
                });

            modelBuilder.Entity("Project_Webapplicaties.Models.Gebruiker", b =>
                {
                    b.Property<int>("GebruikerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("GeboorteDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("Huisnr")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Straat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wachtwoord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Woonplaats")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GebruikerID");

                    b.ToTable("Gebruiker");
                });

            modelBuilder.Entity("Project_Webapplicaties.Models.LineUp", b =>
                {
                    b.Property<int>("LineUpID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Tijd")
                        .HasColumnType("datetime2");

                    b.HasKey("LineUpID");

                    b.ToTable("LineUp");
                });

            modelBuilder.Entity("Project_Webapplicaties.Models.Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BestellingID")
                        .HasColumnType("int");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Vip")
                        .HasColumnType("bit");

                    b.HasKey("TicketID");

                    b.HasIndex("BestellingID");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Project_Webapplicaties.Models.Artiest", b =>
                {
                    b.HasOne("Project_Webapplicaties.Models.LineUp", "LineUp")
                        .WithMany("Artiesten")
                        .HasForeignKey("LineUpID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project_Webapplicaties.Models.Bestelling", b =>
                {
                    b.HasOne("Project_Webapplicaties.Models.Gebruiker", "Gebruiker")
                        .WithMany("Bestellingen")
                        .HasForeignKey("GebruikerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project_Webapplicaties.Models.Ticket", b =>
                {
                    b.HasOne("Project_Webapplicaties.Models.Bestelling", "Bestelling")
                        .WithMany("Tickets")
                        .HasForeignKey("BestellingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
