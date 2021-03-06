﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketReservationSystem.Server.Context;

namespace TicketReservationSystem.Server.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            AdminId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.Cinema", b =>
                {
                    b.Property<int>("CinemaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("GatewayApiKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GatewayApiSecretKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsObsolete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SendGridApiKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TicketPriceAdult")
                        .HasColumnType("TEXT");

                    b.Property<string>("TicketPriceChild")
                        .HasColumnType("TEXT");

                    b.Property<string>("TicketPriceSenior")
                        .HasColumnType("TEXT");

                    b.Property<string>("TicketPriceStudent")
                        .HasColumnType("TEXT");

                    b.HasKey("CinemaId");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.Hall", b =>
                {
                    b.Property<int>("HallId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CinemaId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsObsolete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rows")
                        .HasColumnType("INTEGER");

                    b.HasKey("HallId");

                    b.HasIndex("CinemaId");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .HasColumnType("TEXT");

                    b.Property<string>("Length")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Released")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Subtitles")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubtitlesLanguage")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.MovieShow", b =>
                {
                    b.Property<int>("MovieShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("HallId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.HasKey("MovieShowId");

                    b.HasIndex("HallId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieShows");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("SessionId")
                        .HasColumnType("TEXT");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("REAL");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailForTickets")
                        .HasColumnType("TEXT");

                    b.Property<int>("MovieShowId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReservationId");

                    b.HasIndex("MovieShowId");

                    b.HasIndex("PaymentId")
                        .IsUnique();

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HallId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Row")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SeatReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("SeatId");

                    b.HasIndex("HallId");

                    b.HasIndex("SeatReservationId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.SeatReservation", b =>
                {
                    b.Property<int>("SeatReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieShowId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ReservationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SeatReservationId");

                    b.HasIndex("MovieShowId");

                    b.HasIndex("ReservationId");

                    b.ToTable("ReservationSeats");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdminId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AdminId1")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Salt")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("AdminId1");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            AdminId = 1,
                            Deleted = false,
                            Email = "admin@admin.com",
                            Password = "$2b$10$4RJtYU6aF26yIJDW5IttC.9A75rUUhWrfePFcwuhL6A11.4sD31iS",
                            Salt = "$2b$06$3qS4FYOiAl.r6JH5VzWjne"
                        });
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.Hall", b =>
                {
                    b.HasOne("TicketReservationSystem.Shared.Domain.Cinema", "Cinema")
                        .WithMany("Halls")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.MovieShow", b =>
                {
                    b.HasOne("TicketReservationSystem.Shared.Domain.Hall", "Hall")
                        .WithMany("Shows")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketReservationSystem.Shared.Domain.Movie", "Movie")
                        .WithMany("Shows")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.Reservation", b =>
                {
                    b.HasOne("TicketReservationSystem.Shared.Domain.MovieShow", "MovieShow")
                        .WithMany("Reservations")
                        .HasForeignKey("MovieShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketReservationSystem.Shared.Domain.Payment", "Payment")
                        .WithOne("Reservation")
                        .HasForeignKey("TicketReservationSystem.Shared.Domain.Reservation", "PaymentId");

                    b.Navigation("MovieShow");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.Seat", b =>
                {
                    b.HasOne("TicketReservationSystem.Shared.Domain.Hall", "Hall")
                        .WithMany("Seats")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketReservationSystem.Shared.Domain.SeatReservation", "SeatReservation")
                        .WithMany("Seats")
                        .HasForeignKey("SeatReservationId");

                    b.Navigation("Hall");

                    b.Navigation("SeatReservation");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.SeatReservation", b =>
                {
                    b.HasOne("TicketReservationSystem.Shared.Domain.MovieShow", "Show")
                        .WithMany("ReservationSeats")
                        .HasForeignKey("MovieShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketReservationSystem.Shared.Domain.Reservation", "Reservation")
                        .WithMany("ReservationSeats")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("Show");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.User", b =>
                {
                    b.HasOne("TicketReservationSystem.Shared.Domain.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId1");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.Cinema", b =>
                {
                    b.Navigation("Halls");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.Hall", b =>
                {
                    b.Navigation("Seats");

                    b.Navigation("Shows");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.Movie", b =>
                {
                    b.Navigation("Shows");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.MovieShow", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("ReservationSeats");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.Payment", b =>
                {
                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.Reservation", b =>
                {
                    b.Navigation("ReservationSeats");
                });

            modelBuilder.Entity("TicketReservationSystem.Shared.Domain.SeatReservation", b =>
                {
                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}
