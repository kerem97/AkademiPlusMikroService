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
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommandRequest, CreateOrderingDto>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateOrderingDto> Handle(CreateOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            var values = new Ordering
            {
                OrderDate = request.OrderDate,
                UserId = request.UserId,
                TotalPrice = request.TotalPrice,
            };

            var result = await _repository.CreateAsync(values);

            return _mapper.Map<CreateOrderingDto>(result);
        }
    }
}
