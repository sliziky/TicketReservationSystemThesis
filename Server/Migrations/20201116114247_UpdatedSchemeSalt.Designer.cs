﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketReservationSystem.Server.Context;

namespace TicketReservationSystem.Server.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20201116114247_UpdatedSchemeSalt")]
    partial class UpdatedSchemeSalt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SeatSeatReservation", b =>
                {
                    b.Property<int>("ReservationSeatsSeatReservationID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeatsSeatID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReservationSeatsSeatReservationID", "SeatsSeatID");

                    b.HasIndex("SeatsSeatID");

                    b.ToTable("SeatSeatReservation");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("AdminID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Cinema", b =>
                {
                    b.Property<int>("CinemaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("CinemaID");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Hall", b =>
                {
                    b.Property<int>("HallID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CinemaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("HallID");

                    b.HasIndex("CinemaID");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Length")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Released")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Subtitles")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SubtitlesLanguage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("MovieID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.MovieShow", b =>
                {
                    b.Property<int>("MovieShowID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<int?>("HallID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MovieID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.HasKey("MovieShowID");

                    b.HasIndex("HallID");

                    b.HasIndex("MovieID");

                    b.ToTable("MovieShows");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("ReservationID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("INTEGER");

                    b.HasKey("PaymentID");

                    b.HasIndex("ReservationID")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MovieShowID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReservationID");

                    b.HasIndex("MovieShowID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Seat", b =>
                {
                    b.Property<int>("SeatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HallID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("SeatID");

                    b.HasIndex("HallID");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.SeatReservation", b =>
                {
                    b.Property<int>("SeatReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ReservationID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ShowMovieShowID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("SeatReservationID");

                    b.HasIndex("ReservationID");

                    b.HasIndex("ShowMovieShowID");

                    b.ToTable("ReservationSeats");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
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

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SeatSeatReservation", b =>
                {
                    b.HasOne("TicketReservationSystem.Server.Models.SeatReservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationSeatsSeatReservationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketReservationSystem.Server.Models.Seat", null)
                        .WithMany()
                        .HasForeignKey("SeatsSeatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Admin", b =>
                {
                    b.HasOne("TicketReservationSystem.Server.Models.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("TicketReservationSystem.Server.Models.Admin", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Hall", b =>
                {
                    b.HasOne("TicketReservationSystem.Server.Models.Cinema", "Cinema")
                        .WithMany("Halls")
                        .HasForeignKey("CinemaID");

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.MovieShow", b =>
                {
                    b.HasOne("TicketReservationSystem.Server.Models.Hall", "Hall")
                        .WithMany("Shows")
                        .HasForeignKey("HallID");

                    b.HasOne("TicketReservationSystem.Server.Models.Movie", "Movie")
                        .WithMany("Shows")
                        .HasForeignKey("MovieID");

                    b.Navigation("Hall");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Payment", b =>
                {
                    b.HasOne("TicketReservationSystem.Server.Models.Reservation", "Reservation")
                        .WithOne("Payment")
                        .HasForeignKey("TicketReservationSystem.Server.Models.Payment", "ReservationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Reservation", b =>
                {
                    b.HasOne("TicketReservationSystem.Server.Models.MovieShow", "MovieShow")
                        .WithMany("Reservations")
                        .HasForeignKey("MovieShowID");

                    b.Navigation("MovieShow");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Seat", b =>
                {
                    b.HasOne("TicketReservationSystem.Server.Models.Hall", "Hall")
                        .WithMany("Seats")
                        .HasForeignKey("HallID");

                    b.Navigation("Hall");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.SeatReservation", b =>
                {
                    b.HasOne("TicketReservationSystem.Server.Models.Reservation", "Reservation")
                        .WithMany("ReservationSeats")
                        .HasForeignKey("ReservationID");

                    b.HasOne("TicketReservationSystem.Server.Models.MovieShow", "Show")
                        .WithMany("ReservationSeats")
                        .HasForeignKey("ShowMovieShowID");

                    b.Navigation("Reservation");

                    b.Navigation("Show");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Cinema", b =>
                {
                    b.Navigation("Halls");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Hall", b =>
                {
                    b.Navigation("Seats");

                    b.Navigation("Shows");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Movie", b =>
                {
                    b.Navigation("Shows");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.MovieShow", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("ReservationSeats");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.Reservation", b =>
                {
                    b.Navigation("Payment");

                    b.Navigation("ReservationSeats");
                });

            modelBuilder.Entity("TicketReservationSystem.Server.Models.User", b =>
                {
                    b.Navigation("Admin");
                });
#pragma warning restore 612, 618
        }
    }
}
