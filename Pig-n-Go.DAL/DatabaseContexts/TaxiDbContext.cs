using Microsoft.EntityFrameworkCore;
using Pig_n_Go.BLL.Driver;
using Pig_n_Go.BLL.Order;
using Pig_n_Go.BLL.Passenger;
using Pig_n_Go.BLL.Tariffs;

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
        public DbSet<TariffModel> Tariffs { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PassengerModel>().OwnsOne(model => model.PassengerInfo);

            modelBuilder.Entity<DriverModel>().OwnsOne(model => model.DriverInfo);
            modelBuilder.Entity<DriverModel>().OwnsOne(model => model.Location);

            modelBuilder.Entity<DriverModel>().OwnsOne(model => model.CarInfo);

            modelBuilder.Entity<Route>()
                        .OwnsMany(
                            route => route.LocationUnits,
                            builder =>
                            {
                                builder.Property<int>("Id");
                                builder.HasKey("Id");
                            });
        }
    }
}
