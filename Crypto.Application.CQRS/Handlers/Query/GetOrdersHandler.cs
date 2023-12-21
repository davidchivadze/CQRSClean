
using Crypto.Application.CQRS.Query;
using Crypto.Domain.Models.Response;
using Crypto.Domain.Services;
using MediatR;

namespace Crypto.Application.CQRS.Handlers.Query
{
    public class GetOrdersHandler :  IRequestHandler<GetOrderQuery, List<GetOrderResponse>>
    {
        private readonly IClientService _clientService;
        public GetOrdersHandler(IClientService clientService) {
            _clientService=clientService;
        }
        public async Task<List<GetOrderResponse>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            return await _clientService.GetOrders(request.Request);
        }
    }

}

