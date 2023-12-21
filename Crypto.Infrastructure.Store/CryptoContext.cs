using Crypto.Domain.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Crypto.Infrastructure.Store
{
    public class CryptoContext:DbContext
    {
        public CryptoContext(DbContextOptions<CryptoContext> options)
    : base(options)
        {
        }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<OrderBook> Orders { get; set; }
        public DbSet<ClientAccount> ClientAccounts { get; set; }

    }
}
