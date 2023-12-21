using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Domain.Models.EntityModels
{
    public class OrderBook
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Client")]
        public int ClientID {  get; set; }
        public int TradeType { get; set; }
        [ForeignKey("BuyCurrency")]
        public int BuyCurrencyID { get;set; }
        [ForeignKey("SellCurrency")]
        public int SellCurrencyID { get; set; }
        public decimal BuyAmount  { get; set; }
        public decimal SellAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Fee { get; set; }
        public decimal FeeAmount { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;
        public DateTime LastUpdateDate { get; set; }=DateTime.Now;
        public Client Client { get; set; }
        public Currency BuyCurrency { get; set; }
        public Currency SellCurrency { get; set; }
    }
}
