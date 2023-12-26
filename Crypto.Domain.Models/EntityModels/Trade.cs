using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Domain.Models.EntityModels
{
    public class Trade:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        [ForeignKey("MatchOrder")]
        public int MathchOrderID { get; set; }
        public DateTime CreateDate { get; set; }     
        public OrderBook Order { get; set; }    
        public OrderBook MatchOrder { get; set; }
    }
}
