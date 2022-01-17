﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Pig_n_Go.BLL.Services;
using Pig_n_Go.BLL.Services.Tools;
using Pig_n_Go.Controllers;
using Pig_n_Go.DAL.DatabaseContexts;
using Pig_n_Go.DAL.Repositories;
using Pig_n_Go.Mappers.Order;

namespace Pig_n_Go.Tests.ControllerTests
{
    public class OrderControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaxiDbContext>();
            DbContextOptions<TaxiDbContext> options = optionsBuilder.UseSqlite($"Filename=Taxi.Database").Options;
            var taxiDbContext = new TaxiDbContext(options);

            var dbOrderRepository = new DbOrderRepositoryAsync(taxiDbContext);
            var dbDriverRepository = new DbDriverRepositoryAsync(taxiDbContext);
            IDistanceCalculator calculator = new NativeDistanceCalculator();
            // TODO: adequate value for maxDriverDistance
            decimal maxDriverDistance = decimal.MaxValue;

            IOrderServiceAsync orderServiceAsync = new OrderServiceAsync(dbOrderRepository, dbDriverRepository, calculator, maxDriverDistance);
            
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new OrderMapper());
                mc.AddProfile(new DriverMapper());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            var orderController = new OrderController(orderServiceAsync, mapper);
        }
    }
}