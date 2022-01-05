using Microsoft.EntityFrameworkCore;
using Pig_n_Go.Driver;
using Pig_n_Go.Order;
using Pig_n_Go.Passenger;

namespace Pig_n_Go
{
    public class TaxiContext : DbContext
    {
        public DbSet<DriverModel> DriversModels;
        public DbSet<PassengerModel> PassengerModels;
        public DbSet<OrderModel> OrderModels;

        public TaxiContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}