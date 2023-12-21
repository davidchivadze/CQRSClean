using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crypto.Application.CQRS.Command
{
    public class CreateOrderCommand : IRequest
    {
        public int ClientID { get; set; }
        public int TradeType { get; set; }
        [ForeignKey("BuyCurrency")]
        public int BuyCurrencyID { get; set; }
        [ForeignKey("SellCurrency")]
        public int SellCurrencyID { get; set; }
        public decimal BuyAmount { get; set; }
        public decimal SellAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Fee { get; set; }
        public decimal FeeAmount { get; set; }
        public bool Status { get; set; }
    }
}
