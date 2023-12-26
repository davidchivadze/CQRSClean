using Crypto.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Domain.Models.Request
{
    public class GetOrdersRequest
    {
        [Required(ErrorMessage="TradeType is Required")]
        public int? BuyCurrencyID { get; set; } 
        public int? SellCurrencyID { get; set; }
    }
}
