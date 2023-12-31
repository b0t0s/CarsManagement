﻿// <auto-generated />
using System;
using CarsManagement.Server.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarsManagement.Server.Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarsManagement.Server.Domain.Entities.LotModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LotLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LotName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("ParkingLots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LotLocation = "Rock",
                            LotName = "Garage California",
                            ManagerId = 1
                        },
                        new
                        {
                            Id = 2,
                            LotLocation = "Rock",
                            LotName = "Garage of the Rising Sun",
                            ManagerId = 2
                        });
                });

            modelBuilder.Entity("CarsManagement.Server.Domain.Entities.ManagerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Managers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountName = "Mick Jagger",
                            PasswordHash = "$2a$11$gZt2uSBLfWIDlfp.lGu8Y.9j5EpzTa9ZuG.IwMFRBakHQt0Jxym7."
                        },
                        new
                        {
                            Id = 2,
                            AccountName = "Jimi Hendrix",
                            PasswordHash = "$2a$11$gZt2uSBLfWIDlfp.lGu8Y.9j5EpzTa9ZuG.IwMFRBakHQt0Jxym7."
                        });
                });

            modelBuilder.Entity("CarsManagement.Server.Domain.Entities.SpotModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("bit");

                    b.Property<int>("LotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LotId");

                    b.ToTable("ParkingSpots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsOccupied = false,
                            LotId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsOccupied = false,
                            LotId = 1
                        },
                        new
                        {
                            Id = 3,
                            IsOccupied = false,
                            LotId = 1
                        },
                        new
                        {
                            Id = 4,
                            IsOccupied = false,
                            LotId = 1
                        },
                        new
                        {
                            Id = 5,
                            IsOccupied = false,
                            LotId = 1
                        },
                        new
                        {
                            Id = 6,
                            IsOccupied = false,
                            LotId = 1
                        },
                        new
                        {
                            Id = 7,
                            IsOccupied = false,
                            LotId = 1
                        },
                        new
                        {
                            Id = 8,
                            IsOccupied = false,
                            LotId = 1
                        },
                        new
                        {
                            Id = 9,
                            IsOccupied = false,
                            LotId = 1
                        },
                        new
                        {
                            Id = 10,
                            IsOccupied = false,
                            LotId = 1
                        },
                        new
                        {
                            Id = 11,
                            IsOccupied = false,
                            LotId = 1
                        },
                        new
                        {
                            Id = 12,
                            IsOccupied = false,
                            LotId = 1
                        },
                        new
                        {
                            Id = 13,
                            IsOccupied = false,
                            LotId = 2
                        },
                        new
                        {
                            Id = 14,
                            IsOccupied = false,
                            LotId = 2
                        },
                        new
                        {
                            Id = 15,
                            IsOccupied = false,
                            LotId = 2
                        },
                        new
                        {
                            Id = 16,
                            IsOccupied = false,
                            LotId = 2
                        },
                        new
                        {
                            Id = 17,
                            IsOccupied = false,
                            LotId = 2
                        },
                        new
                        {
                            Id = 18,
                            IsOccupied = false,
                            LotId = 2
                        },
                        new
                        {
                            Id = 19,
                            IsOccupied = false,
                            LotId = 2
                        },
                        new
                        {
                            Id = 20,
                            IsOccupied = false,
                            LotId = 2
                        },
                        new
                        {
                            Id = 21,
                            IsOccupied = false,
                            LotId = 2
                        },
                        new
                        {
                            Id = 22,
                            IsOccupied = false,
                            LotId = 2
                        },
                        new
                        {
                            Id = 23,
                            IsOccupied = false,
                            LotId = 2
                        },
                        new
                        {
                            Id = 24,
                            IsOccupied = false,
                            LotId = 2
                        });
                });

            modelBuilder.Entity("CarsManagement.Server.Domain.Entities.LotModel", b =>
                {
                    b.HasOne("CarsManagement.Server.Domain.Entities.ManagerModel", null)
                        .WithMany("ManagedParkingLots")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarsManagement.Server.Domain.Entities.SpotModel", b =>
                {
                    b.HasOne("CarsManagement.Server.Domain.Entities.LotModel", null)
                        .WithMany("ParkingSpots")
                        .HasForeignKey("LotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CarsManagement.Server.Domain.Entities.CarModel", "ParkedCar", b1 =>
                        {
                            b1.Property<int>("SpotModelId")
                                .HasColumnType("int");

                            b1.Property<string>("Brand")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LicensePlate")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Model")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SpotModelId");

                            b1.ToTable("ParkingSpots");

                            b1.WithOwner()
                                .HasForeignKey("SpotModelId");
                        });

                    b.OwnsOne("CarsManagement.Server.Domain.Entities.TicketModel", "Ticket", b1 =>
                        {
                            b1.Property<int>("SpotModelId")
                                .HasColumnType("int");

                            b1.Property<decimal>("AmountPaid")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<DateTime>("EntryTime")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime?>("ExitTime")
                                .HasColumnType("datetime2");

                            b1.HasKey("SpotModelId");

                            b1.ToTable("ParkingSpots");

                            b1.WithOwner()
                                .HasForeignKey("SpotModelId");
                        });

                    b.Navigation("ParkedCar");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("CarsManagement.Server.Domain.Entities.LotModel", b =>
                {
                    b.Navigation("ParkingSpots");
                });

            modelBuilder.Entity("CarsManagement.Server.Domain.Entities.ManagerModel", b =>
                {
                    b.Navigation("ManagedParkingLots");
                });
#pragma warning restore 612, 618
        }
    }
}
