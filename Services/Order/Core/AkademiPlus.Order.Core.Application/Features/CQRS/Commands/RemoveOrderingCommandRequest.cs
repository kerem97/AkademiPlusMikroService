﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlus.Order.Core.Application.Features.CQRS.Commands
{
    public class RemoveOrderingCommandRequest : IRequest
    {
        public RemoveOrderingCommandRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
