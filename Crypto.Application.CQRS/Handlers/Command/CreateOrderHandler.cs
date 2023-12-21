using Crypto.Application.CQRS.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Application.CQRS.Handlers.Command
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand>
    {
        public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Test Command");
            return Task.CompletedTask;
        }
    }
}
