using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Domain.Models.EntityModels
{
    public class PriceMonitor:BaseEntity
    {
        public int ID { get; set; }
        [ForeignKey("FromCurrency")]
        public int FromCurrencyID { get; set; }
        [ForeignKey("ToCurrency")]
        public int ToCurrencyID { get; set;}
        public Currency FromCurrency { get;set; }
        public Currency ToCurrency { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
