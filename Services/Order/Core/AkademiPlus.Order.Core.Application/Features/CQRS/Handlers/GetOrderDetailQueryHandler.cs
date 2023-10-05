using AkademiPlus.Order.Core.Application.Dtos.OrderDetailDtos;
using AkademiPlus.Order.Core.Application.Features.CQRS.Queries;
using AkademiPlus.Order.Core.Application.Interfaces;
using AkademiPlus.Order.Core.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlus.Order.Core.Application.Features.CQRS.Handlers
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQueryRequest, ResultOrderDetailDto>
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultOrderDetailDto> Handle(GetOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<ResultOrderDetailDto>(value);
        }
    }
}
