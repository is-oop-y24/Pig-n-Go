using AutoMapper;
using Pig_n_Go.Core.Driver;
using Pig_n_Go.Core.DTO.Driver;

namespace Pig_n_Go.Mappers.Order
{
    public class DriverMapper : Profile
    {
        public DriverMapper()
        {
            CreateMap<DriverCreateArguments, DriverModel>();
            CreateMap<DriverDTO, DriverModel>();
            CreateMap<DriverModel, DriverDTO>();
        }
    }
}