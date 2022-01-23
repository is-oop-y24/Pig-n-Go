using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pig_n_Go.BLL.Driver;
using Pig_n_Go.BLL.Order;
using Pig_n_Go.BLL.Passenger;
using Pig_n_Go.BLL.Tariffs;

namespace Pig_n_Go.DAL.Extensions
{
    public static class SeedExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PassengerModel>()
                        .OwnsOne(model => model.PassengerInfo)
                        .HasData(
                            new
                            {
                                PassengerModelId = Guid.Parse("58D5CA6C-B77C-4E4C-B4DE-DB383801AC6D"),
                                Name = "Ivan",
                                Surname = "Ivanov",
                            },
                            new
                            {
                                PassengerModelId = Guid.Parse("7DE47CEA-A6E5-454B-BB40-998C6380E00E"),
                                Name = "Michael",
                                Surname = "Stevens",
                            });

            modelBuilder.Entity<PassengerModel>()
                        .HasData(
                            new PassengerModel { Id = Guid.Parse("58D5CA6C-B77C-4E4C-B4DE-DB383801AC6D") },
                            new PassengerModel { Id = Guid.Parse("7DE47CEA-A6E5-454B-BB40-998C6380E00E") });

            modelBuilder.Entity<DriverModel>()
                        .OwnsOne(model => model.DriverInfo)
                        .HasData(
                            new
                            {
                                DriverModelId = Guid.Parse("445A9C5D-3A23-448E-BB0E-B9941B503599"),
                                Name = "Petr", Surname = "Petrov",
                            },
                            new
                            {
                                DriverModelId = Guid.Parse("75630FC0-C658-4118-96D0-3250D1BAAB97"),
                                Name = "Sidor", Surname = "Sidorov",
                            });

            modelBuilder.Entity<DriverModel>()
                        .OwnsOne(model => model.CarInfo)
                        .HasData(
                            new
                            {
                                DriverModelId = Guid.Parse("445A9C5D-3A23-448E-BB0E-B9941B503599"),
                                ModelName = "Volvo", CarNumber = "A123BC", Color = "white",
                            },
                            new
                            {
                                DriverModelId = Guid.Parse("75630FC0-C658-4118-96D0-3250D1BAAB97"),
                                ModelName = "Renault", CarNumber = "D456EF", Color = "black",
                            });

            modelBuilder.Entity<DriverModel>()
                        .OwnsOne(model => model.Location)
                        .HasData(
                            new
                            {
                                DriverModelId = Guid.Parse("445A9C5D-3A23-448E-BB0E-B9941B503599"),
                                Abscissa = 0.0m, Ordinate = 0.0m,
                            },
                            new
                            {
                                DriverModelId = Guid.Parse("75630FC0-C658-4118-96D0-3250D1BAAB97"),
                                Abscissa = 5.0m, Ordinate = -5.0m,
                            });

            modelBuilder.Entity<DriverRating>()
                        .HasData(
                            new DriverRating
                            {
                                Id = Guid.Parse("7CDD0E3B-8A16-4AC8-9334-1CA9EB25EFEC"),
                                RatingHistory = new List<OrderRating>(),
                            },
                            new DriverRating
                            {
                                Id = Guid.Parse("279C0C12-B9CC-4589-8B24-BEB6E21689B8"),
                                RatingHistory = new List<OrderRating>(),
                            });

            modelBuilder.Entity<DriverModel>()
                        .HasData(
                            new
                            {
                                Id = Guid.Parse("445A9C5D-3A23-448E-BB0E-B9941B503599"),
                                DriverRatingId = Guid.Parse("7CDD0E3B-8A16-4AC8-9334-1CA9EB25EFEC"),
                                IsOnline = false,
                            },
                            new
                            {
                                Id = Guid.Parse("75630FC0-C658-4118-96D0-3250D1BAAB97"),
                                DriverRatingId = Guid.Parse("279C0C12-B9CC-4589-8B24-BEB6E21689B8"),
                                IsOnline = false,
                            });

            modelBuilder.Entity<TariffModel>()
                        .HasData(
                            new TariffModel
                            {
                                Id = Guid.Parse("166f1c96-dafc-4199-9a0d-477ed407c0db"), Name = "Economy", ChargePerLocationUnit = 2.0m,
                            },
                            new TariffModel
                            {
                                Id = Guid.Parse("09b6a985-e067-44b4-bbb7-e6c382fcbcad"), Name = "Comfort", ChargePerLocationUnit = 3.0m,
                            },
                            new TariffModel
                            {
                                Id = Guid.Parse("ebd82d23-3124-411b-aebd-e770b611d3ad"), Name = "Business", ChargePerLocationUnit = 5.0m,
                            },
                            new TariffModel
                            {
                                Id = Guid.Parse("2f47f467-d9eb-41bc-ae90-3cd570d6fed7"), Name = "Elite", ChargePerLocationUnit = 7.0m,
                            });
        }
    }
}
