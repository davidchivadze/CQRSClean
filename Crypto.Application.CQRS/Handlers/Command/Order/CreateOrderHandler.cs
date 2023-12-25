using AutoMapper;
using Crypto.Application.CQRS.Command.Order;
using Crypto.Domain.Models.EntityModels;
using Crypto.Domain.Models.Response;
using Crypto.Domain.Repository.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Application.CQRS.Handlers.Command.Order
{
    public class CreateOrderHandler : BaseHandler, IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        public CreateOrderHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreateOrderCommand, OrderBook>(request);
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var result = await _unitOfWork.OrderBookRepository.AddAsync(entity);
                    await _unitOfWork.SaveAsync();

                    _unitOfWork.CommitTransaction();
                    return _mapper.Map<CreateOrderResponse>(result);
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
