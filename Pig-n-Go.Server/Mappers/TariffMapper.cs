using AutoMapper;
using Pig_n_Go.Common.Tariff;
using Pig_n_Go.Core.Tariffs;

namespace Pig_n_Go.Server.Mappers
{
    public class TariffMapper : Profile
    {
        public TariffMapper()
        {
            CreateMap<TariffCreationArguments, TariffDto>();
            CreateMap<TariffDto, TariffModel>();
            CreateMap<TariffModel, TariffDto>();
        }
    }
}
