﻿using AkademiPlus.Order.Core.Application.Dtos.OrderingDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlus.Order.Core.Application.Features.CQRS.Commands
{
    public class CreateOrderingCommandRequest : IRequest<CreateOrderingDto>
    {

        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
