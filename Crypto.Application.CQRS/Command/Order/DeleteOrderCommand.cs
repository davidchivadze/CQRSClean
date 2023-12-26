﻿using Crypto.Domain.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Application.CQRS.Command.Order
{
    public class DeleteOrderCommand:IRequest<DeleteOrderResponse>
    {
        public int OrderID { get; set; }
    }
}
