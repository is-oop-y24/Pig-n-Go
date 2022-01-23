using AutoMapper;
using Pig_n_Go.BLL.Order;
using Pig_n_Go.Common.Order;

namespace Pig_n_Go.Server.Mappers
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<OrderCreationArguments, OrderDto>();
            CreateMap<OrderDto, OrderModel>();
            CreateMap<OrderModel, OrderDto>();
        }
    }
}