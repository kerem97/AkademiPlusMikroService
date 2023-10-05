using AkademiPlus.Order.Core.Application.Dtos.OrderDetailDtos;
using AkademiPlus.Order.Core.Application.Features.CQRS.Commands;
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
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommandRequest, CreateOrderDetailDto>
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateOrderDetailDto> Handle(CreateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var values = new OrderDetail
            {
                OrderingId = request.OrderingId,
                ProductAmount = request.ProductAmount,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                ProductId = request.ProductId,
            };

            var result = await _repository.CreateAsync(values);

            return _mapper.Map<CreateOrderDetailDto>(result);
        }
    }
}
