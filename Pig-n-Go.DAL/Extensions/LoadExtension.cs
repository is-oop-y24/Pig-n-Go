﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.Order;
using Pig_n_Go.Core.Tariffs;

namespace Pig_n_Go.DAL.Extensions
{
    public static class LoadExtension
    {
        public static IIncludableQueryable<DriverModel, Tariff> LoadDriverDependencies(
            this DbSet<DriverModel> drivers)
        {
            return drivers
                   .Include(model => model.CarInfo)
                   .Include(model => model.Location)
                   .Include(model => model.DriverRating)
                   .Include(model => model.Tariff);
        }

        public static IIncludableQueryable<OrderModel, Tariff> LoadOrderDependencies(
            this DbSet<OrderModel> orders)
        {
            return orders
                   .Include(model => model.Route)
                   .Include(model => model.Passenger)
                   .Include(model => model.Driver)
                   .Include(model => model.Rating)
                   .Include(model => model.Tariff);
        }
    }
}