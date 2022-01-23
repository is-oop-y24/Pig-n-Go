using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Pig_n_Go.Application.Services;
using Pig_n_Go.Core.Services;
using Pig_n_Go.Core.Tools;
using Pig_n_Go.DAL.DatabaseContexts;
using Pig_n_Go.Server.Controllers;
using Pig_n_Go.Server.Mappers;

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

            var mapperConfig = new MapperConfiguration(
                mc =>
                {
                    mc.AddProfile(new OrderMapper());
                    mc.AddProfile(new DriverMapper());
                });

            IMapper mapper = mapperConfig.CreateMapper();

            var orderService = new OrderApplication(
                taxiDbContext,
                mapper,
                new OrderService(
                    distanceCalculator,
                    maxDriverDistance));

            var orderController = new OrderController(orderService, mapper);
        }
    }
}
