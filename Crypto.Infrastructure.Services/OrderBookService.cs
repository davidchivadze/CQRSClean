using Crypto.Domain.Repository.UnitOfWork;
using Crypto.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Infrastructure.Services
{
    public class OrderBookService : BaseService,IOrderBookService
    {
        public OrderBookService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
