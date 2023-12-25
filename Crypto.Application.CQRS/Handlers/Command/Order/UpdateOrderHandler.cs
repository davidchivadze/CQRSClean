using AutoMapper;
using Crypto.Application.CQRS.Command.Order;
using Crypto.Domain.Models.EntityModels;
using Crypto.Domain.Models.Response;
using Crypto.Domain.Repository.UnitOfWork;
using Crypto.Infrastructure.Shared.Exceptions;
using MediatR;
namespace Crypto.Application.CQRS.Handlers.Command.Order
{
    public class UpdateOrderHandler : BaseHandler, IRequestHandler<UpdateOrderCommand, UpdateOrderResponse>
    {
        public UpdateOrderHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<UpdateOrderResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var oldOrder = await _unitOfWork.OrderBookRepository.GetById(request.OrderID);
                    if (oldOrder == null)
                    {
                        throw new DataNotFoundException($"Data Not Found for ID:{request.OrderID}");
                    }
                    else
                    {
                        var updateEntity = _mapper.Map(_mapper.Map<OrderBook>(request), oldOrder);
                        _unitOfWork.OrderBookRepository.Update(updateEntity);
                        await _unitOfWork.SaveAsync();
                        _unitOfWork.CommitTransaction();
                        return _mapper.Map<UpdateOrderResponse>(updateEntity);
                    }
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw;
                }
            }
        }
    }
}
