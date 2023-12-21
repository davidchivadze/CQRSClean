using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crypto.Domain.Models.EntityModels
{
    public class ClientAccount: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Currency")]
        public int CurrencyID { get;set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }  
        public Currency Currency { get; set; }
    }
}
