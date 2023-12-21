using Crypto.Domain.Models.Request;
using Crypto.Domain.Models.Response;
using MediatR;

namespace Crypto.Application.CQRS.Query
{
    public class GetOrderQuery : IRequest<List<GetOrderResponse>>
    {
        public GetOrderRequest Request { get; set; }

        public GetOrderQuery(GetOrderRequest request)
        {
            Request = request;
        }
    }
}
