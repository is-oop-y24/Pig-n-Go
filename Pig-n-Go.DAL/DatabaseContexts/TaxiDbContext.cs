using Microsoft.EntityFrameworkCore;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Order;
using Pig_n_Go.Core.Passenger;

namespace Pig_n_Go.DAL.DatabaseContexts
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
