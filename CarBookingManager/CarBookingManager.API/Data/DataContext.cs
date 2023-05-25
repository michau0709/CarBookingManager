using CarBookingManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CarBookingManager.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().Property(c => c.Price).HasPrecision(6, 2);
            base.OnModelCreating(modelBuilder);
        }
    }
}
