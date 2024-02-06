using FribergsCarRental.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergsCarRental.Data
{
    public class ApplicationDbContext : DbContext
        {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {

            }
        }
    }

