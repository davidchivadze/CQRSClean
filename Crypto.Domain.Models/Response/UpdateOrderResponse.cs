using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Domain.Models.Response
{
    public class UpdateOrderResponse
    {
        public int OrderId { get; set; }
        public int ClientID { get; set; }
        public int BuyCurrencyID { get; set; }
        public int SellCurrencyID { get; set; }
        public decimal BuyAmount { get; set; }
        public decimal SellAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Fee { get; set; }
        public decimal FeeAmount { get; set; }
    }
}
