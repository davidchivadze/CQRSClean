using AutoMapper;
using Crypto.Application.CQRS.Command.Order;
using Crypto.Application.CQRS.Query.Order;
using Crypto.Domain.Models.Request;
using Crypto.Domain.Models.Response;
using Crypto.Presentation.Api.ActionBase.TbcTask.Domain.Models.Responses;
using Crypto.Presentation.Api.SignalRHub.Crypto.Application.CQRS.Handlers.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Crypto.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IHubContext<Orders> _hubContext;

        public OrderController(IMediator mediator, IHubContext<Orders> handler, IMapper mapper)
        {
            _mediator = mediator;
            _hubContext = handler;
            _mapper = mapper;
        }
        [HttpGet("GetOrders")]
        public async Task<Result<List<GetOrdersResponse>>> GetOrders([FromQuery] GetOrdersRequest query)
        {
            var result = await _mediator.Send(_mapper.Map<GetOrdersRequest, GetOrdersQuery>(query));
            return Result<List<GetOrdersResponse>>.Ok(result);
        }
        [HttpGet("GetOrder")]
        public async Task<Result<GetOrderResponse>> GetOrder([Required] int Id)
        {
            var result = await _mediator.Send(new GetOrderQuery() { OrderID = Id });
            return Result<GetOrderResponse>.Ok(_mapper.Map<GetOrderResponse>(result));
        }
        [HttpPost("CreateOrder")]
        public async Task<Result<CreateOrderResponse>> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var result = await _mediator.Send(_mapper.Map<CreateOrderCommand>(request));
            await _hubContext.Clients.All.SendAsync("SendOrderUpdate", _mapper.Map<ProcessOrderCommand>(result));
            return Result<CreateOrderResponse>.Ok(result);
        }
        [HttpPost("UpdateOrder")]
        public async Task<Result<UpdateOrderResponse>> UpdateOrder([FromBody] UpdateOrderRequest request)
        {
            var result = await _mediator.Send(_mapper.Map<UpdateOrderRequest, UpdateOrderCommand>(request));
            await _hubContext.Clients.All.SendAsync("SendOrderUpdate", _mapper.Map<ProcessOrderCommand>(result));
            return Result<UpdateOrderResponse>.Ok(result);
        }
        [HttpPost("ProcessOrder")]
        public async Task<Result<ProcessOrderResponse>> ProcessOrder([FromBody] ProcessOrderRequest request)
        {
            var result = await _mediator.Send(_mapper.Map<ProcessOrderCommand>(request));
            return Result<ProcessOrderResponse>.Ok(result);
        }
        [HttpDelete("DeleteOrder")]
        public async Task<Result<DeleteOrderResponse>> DeleteOrder([FromQuery] DeleteOrderRequest request)
        {
            var result = await _mediator.Send(_mapper.Map<DeleteOrderCommand>(request));
            await _hubContext.Clients.All.SendAsync("SendOrderUpdate", _mapper.Map<ProcessOrderCommand>(result));
            return Result<DeleteOrderResponse>.Ok(result);
        }
    }
}
