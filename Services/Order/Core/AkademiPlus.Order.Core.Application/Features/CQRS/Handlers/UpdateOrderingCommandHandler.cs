using AkademiPlus.Order.Core.Application.Dtos.OrderingDtos;
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
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommandRequest, UpdateOrderingDto>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateOrderingDto> Handle(UpdateOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            var values = new Ordering
            {
                OrderDate = request.OrderDate,
                OrderingId = request.OrderingId,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,
            };

            await _repository.UpdateAsync(values);

            return _mapper.Map<UpdateOrderingDto>(values);
        }
    }
}
