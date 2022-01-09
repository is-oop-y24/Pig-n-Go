using AutoMapper;
using Pig_n_Go.Common.DTO.Passenger;
using Pig_n_Go.Core.Passenger;

namespace Pig_n_Go.Mappers.Order
{
    public class PassengerMapper : Profile
    {
        public PassengerMapper()
        {
            CreateMap<PassengerCreationArguments, PassengerModel>();
            CreateMap<PassengerDTO, PassengerModel>();
            CreateMap<PassengerModel, PassengerDTO>();
        }
    }
}