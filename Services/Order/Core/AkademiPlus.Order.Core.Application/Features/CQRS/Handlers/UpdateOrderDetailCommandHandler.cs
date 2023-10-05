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
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommandRequest, UpdateOrderDetailDto>
    {
        private readonly IRepository<OrderDetail> _repository;

        private readonly IMapper _mapper;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateOrderDetailDto> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var value = new OrderDetail
            {
                OrderDetailId = request.OrderDetailId,
                OrderingId = request.OrderingId,
                ProductAmount = request.ProductAmount,
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
            };

            await _repository.UpdateAsync(value);

            return _mapper.Map<UpdateOrderDetailDto>(value);
        }
    }
}
