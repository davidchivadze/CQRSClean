using Crypto.Domain.Repository;
using Crypto.Domain.Repository.UnitOfWork;
using Crypto.Infrastructure.Store;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWork(CryptoContext context) : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private IClientRepository _ClientRepository;
        private IOrderBookRepository _OrderBookRepository;
        private IAccountRepository _AccountRepository;
        private ITradeRepository _TradeRepository;
        private IPriceMonitorRepository _PriceMonitorRepository;

        public IClientRepository ClientRepository
        {
            get { return _ClientRepository = _ClientRepository ?? new ClientRepository(context); }
        }
        public IAccountRepository AccountRepository
        {
            get { return _AccountRepository=_AccountRepository ?? new AccountRepository(context);}
        }
        public IPriceMonitorRepository PriceMonitorRepository
        {
            get { return _PriceMonitorRepository = _PriceMonitorRepository ?? new PriceMonitorRepository(context); }
        }
        public ITradeRepository TradeRepository
        {
            get { return _TradeRepository = _TradeRepository ?? new TradeRepository(context); }
        }
        public IOrderBookRepository OrderBookRepository
        {
            get { return _OrderBookRepository = _OrderBookRepository ?? new OrderBookRepository(context); }
        }
        public async Task<IDisposable> BeginTransactionAsync()
        {
            _transaction = await context.Database.BeginTransactionAsync();
            return _transaction;
        }
        public  IDisposable BeginTransaction()
        {
            _transaction =  context.Database.BeginTransaction();
            return _transaction;
        }


        public void CommitTransaction()
        {
            _transaction?.Commit();
        }
        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            context.Dispose();
        }
        public async Task DisposeAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }
            if (context != null)
            {
                await context.DisposeAsync();
            }
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
        }
        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
               await _transaction.RollbackAsync();
            }
         
        }
        public void Save()
        {

            context.SaveChanges();
        }
        public async Task SaveAsync()
        {

            await context.SaveChangesAsync();
        }
    }
}
