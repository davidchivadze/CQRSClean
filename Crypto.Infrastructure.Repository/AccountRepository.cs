using Crypto.Domain.Models.EntityModels;
using Crypto.Domain.Repository;
using Crypto.Infrastructure.Store;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Infrastructure.Repository
{
    public class AccountRepository : BaseRepository<ClientAccount>, IAccountRepository
    {
        public AccountRepository(CryptoContext cryptoContext) : base(cryptoContext)
        {
        }

        public async Task<ClientAccount> GetClientAccountByCurrency(int clientID, int currencyID)
        {
            var result=await _DbSet.Where(m=>m.ClientId==clientID&&m.CurrencyID==currencyID).FirstOrDefaultAsync();
            return result;

        }
    }
}
