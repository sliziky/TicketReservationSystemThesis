using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
    : base(options)
        { }
        public DbSet<Admin> Admins { get; set; } 
        public DbSet<Cinema> Cinemas { get; set; } 
        public DbSet<Hall> Halls { get; set; } 
        public DbSet<Movie> Movies { get; set; } 
        public DbSet<MovieShow> MovieShows { get; set; } 
        public DbSet<Payment> Payments { get; set; } 
        public DbSet<Reservation> Reservations { get; set; } 
        public DbSet<SeatReservation> ReservationSeats { get; set; } 
        public DbSet<Seat> Seats { get; set; } 
        public DbSet<User> Users { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite("Data Source=blogging.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Movie>().HasData(new Movie
      {
        MovieID = 1,
        Title = "MovieTitle",
        Country = "Country",
        Description = "Desc",
        Genre = "Genre",
        Language = "en",
        Length = new DateTime(),
        Released = new DateTime(),
        Shows = new List<MovieShow>(),
        Subtitles = false,
        SubtitlesLanguage = null
      });
      base.OnModelCreating(modelBuilder);
    }
  }
}
