using Crypto.Domain.Models.Response;
using Crypto.Domain.Models.EntityModels;

namespace Crypto.Infrastructure.Shared
{
    public static class OrderBookMapper
    {
        public static GetOrderResponse AsGetOrderResponse(this OrderBook model)
        {
            return new GetOrderResponse
            {
                Id = model.Id,
                BuyAmount = model.BuyAmount,
                BuyCurrencyID = model.BuyCurrencyID,
                ClientID = model.ClientID,
                CreateDate = model.CreateDate,
                ExchangeRate = model.ExchangeRate,
                Fee = model.Fee,
                FeeAmount = model.FeeAmount,
                LastUpdateDate = model.LastUpdateDate,
                SellAmount = model.SellAmount,
                SellCurrencyID = model.SellCurrencyID,
                Status = model.Status,
                TradeType = model.TradeType,

            };
        }
    }
}
