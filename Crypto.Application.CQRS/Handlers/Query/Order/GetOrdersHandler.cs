
using AutoMapper;
using Crypto.Application.CQRS.Query.Order;
using Crypto.Domain.Models.Response;
using Crypto.Domain.Repository.UnitOfWork;
using Crypto.Infrastructure.Shared.Exceptions;
using MediatR;

namespace Crypto.Application.CQRS.Handlers.Query.Order
{
    public class GetOrdersHandler : BaseHandler, IRequestHandler<GetOrdersQuery, List<GetOrdersResponse>>
    {
        public GetOrdersHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public async Task<List<GetOrdersResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.OrderBookRepository
                .GetOrderBooksAsync(request.TradeType, request.CurrencyID, request.SellCurrencyID);
            if (result == null || result.Count() == 0)
            {
                throw new DataNotFoundException("Data Not Found");
            }
            else
            {
                return result.Select(m => _mapper.Map<GetOrdersResponse>(m)).ToList();
            }
        }
    }

}

