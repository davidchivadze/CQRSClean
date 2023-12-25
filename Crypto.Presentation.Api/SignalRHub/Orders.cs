namespace Crypto.Presentation.Api.SignalRHub
{
    using AutoMapper;
    using global::Crypto.Application.CQRS.Query;
    using global::Crypto.Application.CQRS.Query.Order;
    using global::Crypto.Domain.Models.Response;
    using MediatR;
    using Microsoft.AspNetCore.SignalR;
    using SignalRSwaggerGen.Attributes;
    using System;
    using System.Threading.Tasks;

    namespace Crypto.Application.CQRS.Handlers.Query
    {
        /// <summary>
        /// Represents a SignalR hub for handling order-related operations.
        /// </summary>
        [SignalRHub("/orders/GetOrder")]
        public class Orders : Hub
        {
            private readonly IMediator _mediator;
            public Orders(IMediator mediator)
            {
                _mediator = mediator;
            }


            public async Task SendOrderUpdate(GetOrderQuery data)
            {
                var result = await _mediator.Send(data);

                if (result != null)
                {
                    // Assuming GetOrderQuery returns Result<GetOrderResponse>
                    var updateOrderResponse = result;
                    await Clients.All.SendAsync("SendOrderUpdate", updateOrderResponse);
                }
            }

        }
    }

}
