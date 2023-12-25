using Crypto.Domain.Models.EntityModels;
using Crypto.Domain.Models.Enums;
using Crypto.Domain.Repository;
using Crypto.Infrastructure.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Infrastructure.Repository
{
    public class OrderBookRepository : BaseRepository<OrderBook>, IOrderBookRepository
    {
        public OrderBookRepository(CryptoContext cryptoContext) : base(cryptoContext)
        {
        }

        public async Task<IQueryable<OrderBook>> GetOrderBooksAsync(TradeType tradeType,int? buyCurrencyID,int? sellCurrencyID)
        {
            var result = GetAll().Where(x => x.TradeType == (int)tradeType
            && x.BuyCurrencyID == (buyCurrencyID ?? x.BuyCurrencyID)
            && x.SellCurrencyID == (sellCurrencyID ?? x.SellCurrencyID)
            && x.Status == false);
            return result;
        }
    }
}
