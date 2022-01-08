﻿using AutoMapper;
using Pig_n_Go.Common.DTO.Order;
using Pig_n_Go.Core.Order;

namespace Pig_n_Go.Mappers.Order
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<OrderCreateArguments, OrderModel>();
            CreateMap<OrderDTO, OrderModel>();
            CreateMap<OrderModel, OrderDTO>();
        }
    }
}