using AkademiPlus.Order.Core.Application.Dtos.AddressDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlus.Order.Core.Application.Features.CQRS.Queries
{
    public class GetAddressQueryRequest : IRequest<ResultAddressDto>
    {
        public GetAddressQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
