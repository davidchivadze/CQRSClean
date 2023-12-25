using Crypto.Domain.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Application.CQRS.Query.Order
{
    public class GetOrderQuery : IRequest<GetOrderResponse>
    {
        public int OrderID { get; set; }
    }
}
