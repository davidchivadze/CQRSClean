using AutoMapper;
using Crypto.Application.CQRS.Command.Order;
using Crypto.Domain.Models.Response;
using Crypto.Domain.Repository.UnitOfWork;
using Crypto.Infrastructure.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Application.CQRS.Handlers.Command.Order
{
    public class DeleteOrderHandler : BaseHandler, IRequestHandler<DeleteOrderCommand,DeleteOrderResponse>
    {
        public DeleteOrderHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<DeleteOrderResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var deleteObject = await _unitOfWork.OrderBookRepository.GetById(request.OrderID);
                    if (deleteObject == null)
                    {
                        throw new DataNotFoundException($"Data not Found For OrderID:{request.OrderID}");
                    }
                    _unitOfWork.OrderBookRepository.DeleteOrder(deleteObject);
                    await _unitOfWork.SaveAsync();
                    _unitOfWork.CommitTransaction();
                    return _mapper.Map<DeleteOrderResponse>(deleteObject);
                }
                catch
                {
                    _unitOfWork.RollbackTransaction();
                    throw;
                }
            }
        }
    }
}
