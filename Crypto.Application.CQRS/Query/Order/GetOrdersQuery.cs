using Crypto.Domain.Models.Enums;
using Crypto.Domain.Models.Request;
using Crypto.Domain.Models.Response;
using MediatR;

namespace Crypto.Application.CQRS.Query.Order
{
    public class GetOrdersQuery : IRequest<List<GetOrdersResponse>>
    {
        public TradeType TradeType { get; set; }
        public int? CurrencyID { get; set; }
        public int? SellCurrencyID { get; internal set; }
    }
}
