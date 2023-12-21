using Crypto.Application.CQRS.Query;
using Crypto.Domain.Models.Request;
using Crypto.Domain.Models.Response;
using Crypto.Presentation.Api.SignalRHub.Crypto.Application.CQRS.Handlers.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Crypto.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IHubContext<Orders> _hubContext;

        public OrderController(IMediator mediator,IHubContext<Orders> handler) { 
            _mediator = mediator;
            _hubContext=handler;
        }
        [HttpGet("GetOrders")]
        public async Task<List<GetOrderResponse>> Index([FromQuery]GetOrderRequest query)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", query);
            return await _mediator.Send(new GetOrderQuery(query));
        }
    }
}
