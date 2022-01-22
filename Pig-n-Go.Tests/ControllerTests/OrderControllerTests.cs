using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Pig_n_Go.Controllers;
using Pig_n_Go.Core.Services;
using Pig_n_Go.Core.Tools;
using Pig_n_Go.DAL.DatabaseContexts;
using Pig_n_Go.Mappers.Order;

namespace Pig_n_Go.Tests.ControllerTests
{
    public class OrderControllerTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void Test1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaxiDbContext>();
            DbContextOptions<TaxiDbContext> options = optionsBuilder.UseSqlite($"Filename=Taxi.Database").Options;
            var taxiDbContext = new TaxiDbContext(options);

            var distanceCalculator = new NativeDistanceCalculator();
            var maxDriverDistance = new DriverDistanceLimit { MaxValue = 10.0m };

            IOrderService orderService = new OrderService(
                distanceCalculator,
                maxDriverDistance);

            IPassengerService passengerService = new PassengerService();

            var mapperConfig = new MapperConfiguration(
                mc =>
                {
                    mc.AddProfile(new OrderMapper());
                    mc.AddProfile(new DriverMapper());
                });

            IMapper mapper = mapperConfig.CreateMapper();

            var orderController = new OrderController(orderService, passengerService, mapper);
        }
    }
}
