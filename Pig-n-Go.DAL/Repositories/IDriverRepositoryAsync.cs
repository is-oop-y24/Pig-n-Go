﻿using System.Threading.Tasks;
using Pig_n_Go.Core.Driver;

namespace Pig_n_Go.DAL.Repositories
{
    public interface IDriverRepositoryAsync : IRepositoryAsync<DriverModel>
    {
        Task GoOnline(DriverModel driver);
        Task GoOffline(DriverModel driver);
    }
}