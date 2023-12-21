
using Crypto.Application.CQRS.Query;
using Crypto.Application.CQRS.Response;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Application.CQRS.Handlers.Query
{
    public class GetOrdersHandler :  IRequestHandler<GetOrderQuery, GetOrderResponse>
    {
        public Task<GetOrderResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetOrderResponse()
            {
                Id = request.Id
            });
        }
    }

}

