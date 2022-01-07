using Microsoft.EntityFrameworkCore;
using Pig_n_Go.Driver;
using Pig_n_Go.Order;
using Pig_n_Go.Passenger;

namespace Pig_n_Go
{
    public sealed class TaxiDbContext : DbContext
    {
        public TaxiDbContext(DbContextOptions<TaxiDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<DriverModel> Drivers { get; private set; }
        public DbSet<PassengerModel> Passengers { get; private set; }
        public DbSet<OrderModel> Orders { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
