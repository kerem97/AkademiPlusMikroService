using AkademiPlus.Order.Core.Application.Dtos.AddressDtos;
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
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQueryRequest, ResultAddressDto>
    {
        private readonly IRepository<Address> _repository;

        private readonly IMapper _mapper;

        public GetAddressQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultAddressDto> Handle(GetAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<ResultAddressDto>(value);
        }
    }
}
