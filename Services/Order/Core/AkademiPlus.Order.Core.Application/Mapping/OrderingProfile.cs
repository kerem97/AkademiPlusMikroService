using AkademiPlus.Order.Core.Application.Dtos.OrderingDtos;
using AkademiPlus.Order.Core.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlus.Order.Core.Application.Mapping
{
    public class OrderingProfile : Profile
    {
        public OrderingProfile()
        {
            CreateMap<ResultOrderingDto, Ordering>().ReverseMap();
            CreateMap<CreateOrderingDto, Ordering>().ReverseMap();
            CreateMap<UpdateOrderingDto, Ordering>().ReverseMap();
        }
    }
}
