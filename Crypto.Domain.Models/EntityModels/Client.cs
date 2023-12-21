using System.ComponentModel.DataAnnotations;

namespace Crypto.Domain.Models.EntityModels
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<ClientAccount> Accounts { get; set; }
        public List<OrderBook> Trades { get; set; }

    }
}
