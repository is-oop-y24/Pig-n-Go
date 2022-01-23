using AutoMapper;
using Pig_n_Go.BLL.Passenger;
using Pig_n_Go.Common.Passenger;

namespace Pig_n_Go.Server.Mappers
{
    public class PassengerMapper : Profile
    {
        public PassengerMapper()
        {
            CreateMap<PassengerCreationArguments, PassengerDto>();
            CreateMap<PassengerDto, PassengerModel>();
            CreateMap<PassengerModel, PassengerDto>();
        }
    }
}