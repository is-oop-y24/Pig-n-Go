using AutoMapper;
using Pig_n_Go.BLL.Tariffs;
using Pig_n_Go.Common.Tariff;

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
