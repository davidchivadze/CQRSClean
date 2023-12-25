using AutoMapper;
using Crypto.Application.CQRS.Query.Order;
using Crypto.Domain.Models.Response;
using Crypto.Domain.Repository.UnitOfWork;
using Crypto.Infrastructure.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Application.CQRS.Handlers.Query.Order
{
    public class GetOrderHandler : BaseHandler, IRequestHandler<GetOrderQuery, GetOrderResponse>
    {
        public GetOrderHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<GetOrderResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.OrderBookRepository.GetById(request.OrderID);
            if (result == null)
            {
                throw new DataNotFoundException($"Data Not Found for OrderID:{request.OrderID}");
            }
            return _mapper.Map<GetOrderResponse>(result);
        
        }
    }
}
