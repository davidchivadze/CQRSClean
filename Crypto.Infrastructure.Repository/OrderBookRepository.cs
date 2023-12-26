using Crypto.Domain.Models.EntityModels;
using Crypto.Domain.Models.Enums;
using Crypto.Domain.Repository;
using Crypto.Infrastructure.Store;
using Microsoft.EntityFrameworkCore;
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

        public void DeleteOrder(OrderBook orderBook)
        {
            orderBook.State=(int)State.Deleted;
            Update(orderBook);
            
        }

        public async Task<OrderBook> GetAvailableOrderForTrade(OrderBook order)
        {
            var result=await _DbSet.Where(m=>m.BuyCurrencyID==order.SellCurrencyID
            &&m.SellCurrencyID==order.BuyCurrencyID
            &&m.BuyAmount==order.SellAmount
            &&m.SellAmount==order.BuyAmount
            ).OrderBy(m=>m.CreateDate).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IQueryable<OrderBook>> GetOrderBooksAsync(TradeType tradeType,int? buyCurrencyID,int? sellCurrencyID)
        {
            var result = GetAll().Where(x => 
            x.BuyCurrencyID == (buyCurrencyID ?? x.BuyCurrencyID)
            && x.SellCurrencyID == (sellCurrencyID ?? x.SellCurrencyID)
            && x.State ==(int)State.Registrated);
            return result;
        }
    }
}
