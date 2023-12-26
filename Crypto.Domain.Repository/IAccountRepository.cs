using Crypto.Domain.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Domain.Repository
{
    public interface IAccountRepository:IBaseRepository<ClientAccount>
    {
        public Task<ClientAccount> GetClientAccountByCurrency(int clientID,int currencyID);
    }
}
