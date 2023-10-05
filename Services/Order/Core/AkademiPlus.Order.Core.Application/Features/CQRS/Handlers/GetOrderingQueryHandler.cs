using AkademiPlus.Order.Core.Application.Dtos.OrderingDtos;
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
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQueryRequest, ResultOrderingDto>
    {
        private readonly IRepository<Ordering> _repository;

        private readonly IMapper _mapper;

        public GetOrderingQueryHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultOrderingDto> Handle(GetOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<ResultOrderingDto>(value);
        }
    }
}
