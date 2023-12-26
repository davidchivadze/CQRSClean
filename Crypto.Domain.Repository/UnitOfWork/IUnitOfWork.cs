using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Domain.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository ClientRepository { get; }
        IOrderBookRepository OrderBookRepository { get; }
        IAccountRepository AccountRepository { get; }
        ITradeRepository TradeRepository { get; }
        IPriceMonitorRepository PriceMonitorRepository { get; }
        Task<IDisposable> BeginTransactionAsync();
        IDisposable BeginTransaction();
        void CommitTransaction();
        Task CommitTransactionAsync();
        new void Dispose();
         Task DisposeAsync();

         void RollbackTransaction();
        Task RollbackTransactionAsync();
         void Save();
        Task SaveAsync();
    }
}
