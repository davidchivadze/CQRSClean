using Crypto.Application.CQRS.Response;
using MediatR;

namespace Crypto.Application.CQRS.Query
{
    public class GetOrderQuery : IRequest<GetOrderResponse>
    {
        public string? Id { get; set; }
    }
}
