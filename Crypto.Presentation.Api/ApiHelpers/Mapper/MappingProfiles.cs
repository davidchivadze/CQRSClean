using AutoMapper;
using Crypto.Application.CQRS.Command.Order;
using Crypto.Application.CQRS.Query.Order;
using Crypto.Domain.Models.EntityModels;
using Crypto.Domain.Models.Request;
using Crypto.Domain.Models.Response;

namespace Crypto.Presentation.Api.ApiHelpers.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GetOrdersRequest, GetOrdersQuery>();
            CreateMap<OrderBook, GetOrdersResponse>();
            CreateMap<CreateOrderRequest, CreateOrderCommand>();
            CreateMap<OrderBook, CreateOrderResponse>();
            CreateMap<CreateOrderResponse, GetOrderQuery>().ForMember(dest => dest.OrderID,
                opt => opt.MapFrom(src => src.OrderID));
            CreateMap<CreateOrderCommand, OrderBook>().ForMember(dest => dest.LastUpdateDate, opt => opt.MapFrom(src => DateTime.Now.ToUniversalTime()))
              .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.Now.ToUniversalTime()));
            CreateMap<UpdateOrderRequest, UpdateOrderCommand>();
            CreateMap<UpdateOrderCommand, OrderBook>().
                ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderID));
            CreateMap<OrderBook, OrderBook>().ForMember(dest => dest.LastUpdateDate, opt => opt.MapFrom(src => DateTime.Now.ToUniversalTime()));
            CreateMap<OrderBook, UpdateOrderResponse>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id));
            CreateMap<OrderBook, GetOrderResponse>();
            CreateMap<UpdateOrderResponse, GetOrderQuery>().ForMember(dest => dest.OrderID, opt => opt.MapFrom(src => src.OrderId));
            CreateMap<GetOrderQuery, ProcessOrderCommand>();
            CreateMap<ProcessOrderCommand, ProcessOrderRequest>();

        }
    }
}
