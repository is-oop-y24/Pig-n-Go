using Microsoft.EntityFrameworkCore;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Order;
using Pig_n_Go.Core.Passenger;
using Pig_n_Go.Core.Tariffs;

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

        public DbSet<DriverModel> ActiveDrivers { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tariff>();
            modelBuilder.Entity<BusinessTariff>();
            modelBuilder.Entity<ComfortTariff>();
            modelBuilder.Entity<EconomyTariff>();
            modelBuilder.Entity<EliteTariff>();
            modelBuilder.Entity<PassengerModel>().OwnsOne<PassengerInfo>("PassengerInfo");
        }
    }
}
