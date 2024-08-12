using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServe.Models;
using Microsoft.EntityFrameworkCore;

namespace DataServe.Context
{
    public class ApplicationDbContext:DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        

        public DbSet<Hotel> Hotels { get; set;}

        public DbSet<Review> Reviews { get; set;}

        public DbSet<TravelPackages> TravelPackages{ get; set;}  
         public DbSet<User> Users { get; set; }

         public DbSet<Booking> Bookings { get; set; }

         public DbSet<TravelPackages> TravelPackage{ get; set; }


          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId);


            // modelBuilder.Entity<Review>()
            // .HasOne(r => r.Hotel)
            // .WithMany(h => h.Reviews)
            // .HasForeignKey(r => r.HotelId);

              modelBuilder.Entity<Booking>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId);

            // modelBuilder.Entity<Booking>()
            // .HasOne(b => b.Hotel)
            // .WithMany(h => h.Bookings)
            // .HasForeignKey(b => b.HotelId);

             



        // Configure the one-to-many relationship
        // modelBuilder.Entity<Hotel>()
        //     .HasMany(h => h.Reviews)
        //     .WithOne(r => r.Hotel)
        //     .HasForeignKey(r => r.HotelId)
        //     .OnDelete(DeleteBehavior.Cascade); // Optional: Configure cascade delete


        }

        
    }
}
