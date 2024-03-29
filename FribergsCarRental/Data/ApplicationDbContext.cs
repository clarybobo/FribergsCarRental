﻿using FribergsCarRental.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergsCarRental.Data
{
    public class ApplicationDbContext : DbContext
        {
        public DbSet<Car> Cars { get; set; }      

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<TheUser> TheUsers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {

            }
        }
    }

