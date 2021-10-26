﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnTheSceneWebApp.Data;

namespace OnTheSceneWebApp.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    partial class MoviesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnTheSceneWebApp.Models.ActorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MovieModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieModelId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("OnTheSceneWebApp.Models.AvailableBookingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CinemaHallId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AvailableBookings");
                });

            modelBuilder.Entity("OnTheSceneWebApp.Models.ChairModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("ReservationModelId")
                        .HasColumnType("int");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservationModelId");

                    b.ToTable("ChairModel");
                });

            modelBuilder.Entity("OnTheSceneWebApp.Models.CinemaHall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfColumns")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRows")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CinemaHalls");
                });

            modelBuilder.Entity("OnTheSceneWebApp.Models.HoursModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AvailableBookingModelId")
                        .HasColumnType("int");

                    b.Property<string>("Hour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Minutes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AvailableBookingModelId");

                    b.ToTable("Hours");
                });

            modelBuilder.Entity("OnTheSceneWebApp.Models.MovieModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateReleased")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Plot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Runtime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("OnTheSceneWebApp.Models.ReservationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableBookingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OnlineReservation")
                        .HasColumnType("bit");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniqueCodeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("OnTheSceneWebApp.Models.UniqueCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UniqueCodes");
                });

            modelBuilder.Entity("OnTheSceneWebApp.Models.ActorModel", b =>
                {
                    b.HasOne("OnTheSceneWebApp.Models.MovieModel", null)
                        .WithMany("Actors")
                        .HasForeignKey("MovieModelId");
                });

            modelBuilder.Entity("OnTheSceneWebApp.Models.ChairModel", b =>
                {
                    b.HasOne("OnTheSceneWebApp.Models.ReservationModel", null)
                        .WithMany("Chairs")
                        .HasForeignKey("ReservationModelId");
                });

            modelBuilder.Entity("OnTheSceneWebApp.Models.HoursModel", b =>
                {
                    b.HasOne("OnTheSceneWebApp.Models.AvailableBookingModel", null)
                        .WithMany("HoursAvailable")
                        .HasForeignKey("AvailableBookingModelId");
                });

            modelBuilder.Entity("OnTheSceneWebApp.Models.AvailableBookingModel", b =>
                {
                    b.Navigation("HoursAvailable");
                });

            modelBuilder.Entity("OnTheSceneWebApp.Models.MovieModel", b =>
                {
                    b.Navigation("Actors");
                });

            modelBuilder.Entity("OnTheSceneWebApp.Models.ReservationModel", b =>
                {
                    b.Navigation("Chairs");
                });
#pragma warning restore 612, 618
        }
    }
}