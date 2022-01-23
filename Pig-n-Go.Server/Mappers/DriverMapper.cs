using AutoMapper;
using Pig_n_Go.Common.Driver;
using Pig_n_Go.Core.Driver;

namespace Pig_n_Go.Server.Mappers
{
    public class DriverMapper : Profile
    {
        public DriverMapper()
        {
            CreateMap<DriverCreationArguments, DriverDto>();
            CreateMap<DriverDto, DriverModel>();
            CreateMap<DriverModel, DriverDto>();
        }
    }
}