using Crypto.Domain.Models.Response;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crypto.Application.CQRS.Command.Order
{
    public class CreateOrderCommand : IRequest<CreateOrderResponse>
    {
        public int ClientID { get; set; }
        public int BuyCurrencyID { get; set; }
        public int SellCurrencyID { get; set; }
        public decimal BuyAmount { get; set; }
        public decimal SellAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Fee { get; set; }
        public decimal FeeAmount { get; set; }
        public bool Status { get; set; }
    }
}
