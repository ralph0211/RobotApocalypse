﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RobotApocalypse.Data;

#nullable disable

namespace RobotApocalypse.Migrations
{
    [DbContext(typeof(RobotContext))]
    [Migration("20230423063029_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("ResourceSurvivor", b =>
                {
                    b.Property<int>("ResourcesId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SurvivorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ResourcesId", "SurvivorId");

                    b.HasIndex("SurvivorId");

                    b.ToTable("ResourceSurvivor");
                });

            modelBuilder.Entity("RobotApocalypse.Models.ReportedInfection", b =>
                {
                    b.Property<long>("ReporterId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("InfectedSurvivorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReporterId", "InfectedSurvivorId");

                    b.HasIndex("InfectedSurvivorId");

                    b.ToTable("ReportedInfections");
                });

            modelBuilder.Entity("RobotApocalypse.Models.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Resources");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Water"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Medication"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ammunition"
                        });
                });

            modelBuilder.Entity("RobotApocalypse.Models.Survivor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsInfected")
                        .HasColumnType("INTEGER");

                    b.Property<double>("LastLocationLatitude")
                        .HasColumnType("REAL");

                    b.Property<double>("LastLocationLongitude")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Survivors");
                });

            modelBuilder.Entity("ResourceSurvivor", b =>
                {
                    b.HasOne("RobotApocalypse.Models.Resource", null)
                        .WithMany()
                        .HasForeignKey("ResourcesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RobotApocalypse.Models.Survivor", null)
                        .WithMany()
                        .HasForeignKey("SurvivorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RobotApocalypse.Models.ReportedInfection", b =>
                {
                    b.HasOne("RobotApocalypse.Models.Survivor", "InfectedSurvivor")
                        .WithMany()
                        .HasForeignKey("InfectedSurvivorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RobotApocalypse.Models.Survivor", "Reporter")
                        .WithMany("InfectionReports")
                        .HasForeignKey("ReporterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InfectedSurvivor");

                    b.Navigation("Reporter");
                });

            modelBuilder.Entity("RobotApocalypse.Models.Survivor", b =>
                {
                    b.Navigation("InfectionReports");
                });
#pragma warning restore 612, 618
        }
    }
}
