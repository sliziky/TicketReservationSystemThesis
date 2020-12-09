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
        {  }
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
=> options.UseSqlite("Data Source = cinemasystem.db");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      var salt = BCrypt.Net.BCrypt.GenerateSalt(6);
            var pw = BCrypt.Net.BCrypt.HashPassword("admin" + salt);
            var user = new User()
            {
                Email = "admin@admin.com",
                Password = pw,
                Salt = salt,
                UserId = 1,
                AdminId = 1,
            };
            var admin = new Admin() { AdminId = 1, UserId = user.UserId, };
            modelBuilder.Entity<User>().HasData(user);
            modelBuilder.Entity<Admin>().HasData(admin);
      base.OnModelCreating(modelBuilder);
    }
  }
}
