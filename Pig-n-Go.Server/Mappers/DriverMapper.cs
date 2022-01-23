using AutoMapper;
using Pig_n_Go.BLL.Driver;
using Pig_n_Go.Common.Driver;

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