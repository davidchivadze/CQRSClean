using AutoMapper;
using Crypto.Application.CQRS.Command.Order;
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
    public class ProcessOrderCommandHandler : BaseHandler, IRequestHandler<ProcessOrderCommand, ProcessOrderResponse>
    {
         public ProcessOrderCommandHandler(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork,mapper) { }

        public async Task<ProcessOrderResponse> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
