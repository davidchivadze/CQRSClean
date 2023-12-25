using Crypto.Domain.Models.EntityModels;
using Crypto.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Domain.Repository
{
    public interface IOrderBookRepository:IBaseRepository<OrderBook>
    {
        Task<IQueryable<OrderBook>> GetOrderBooksAsync(TradeType tradeType, int? buyCurrencyID, int? sellCurrencyID);
    }
}
