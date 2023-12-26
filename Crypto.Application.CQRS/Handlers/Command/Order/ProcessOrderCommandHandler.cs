using AutoMapper;
using Crypto.Application.CQRS.Command.Order;
using Crypto.Domain.Models.EntityModels;
using Crypto.Domain.Models.Enums;
using Crypto.Domain.Models.Response;
using Crypto.Domain.Repository.UnitOfWork;
using Crypto.Infrastructure.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Application.CQRS.Handlers.Command.Order
{
    public class ProcessOrderCommandHandler : BaseHandler, IRequestHandler<ProcessOrderCommand, ProcessOrderResponse>
    {
         public ProcessOrderCommandHandler(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork,mapper) { }

        public async Task<ProcessOrderResponse> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var order = await _unitOfWork.OrderBookRepository.GetById(request.OrderId);
                    if (order == null)
                    {
                        throw new DataNotFoundException($"Data Not Found For OrderID: {request.OrderId}");
                    }
                    if (order.State != (int)State.Registrated)
                    {
                        throw new Exception("Order Is Not Aviable To Process");
                    }
                    var mathchedOrder = await _unitOfWork.OrderBookRepository.GetAvailableOrderForTrade(order);
                    if (mathchedOrder == null)
                    {
                        throw new Exception("Not Aviable Order To Process");
                    }
                    //withdraw money with orders
                    await WithdrawMoneyFromAccount(order.ClientID, order.SellAmount, order.SellCurrencyID);
                    await WithdrawMoneyFromAccount(mathchedOrder.ClientID, mathchedOrder.SellAmount, mathchedOrder.SellCurrencyID);
                    //AddMoneyWithOrders
                    await AddMoneyToAccount(order.ClientID, order.BuyAmount, order.BuyCurrencyID);
                    await AddMoneyToAccount(mathchedOrder.ClientID, mathchedOrder.BuyAmount, mathchedOrder.BuyCurrencyID);
                    //CreateTrades
                    await CreateTrade(order.Id, mathchedOrder.Id);

                    //CreatePriceMonitorData
                    await CreatePriceMonitorData(order);
                    await _unitOfWork.SaveAsync();
                    _unitOfWork.CommitTransaction();
                    return new ProcessOrderResponse()
                    {
                        Success = true,
                        OrderID = order.Id,
                        MatchedOrderID = mathchedOrder.Id
                    };
                }catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw;
                }

            }
        }
        private async Task WithdrawMoneyFromAccount(int clientID,decimal amount,int currencyID)
        {
            var account = await _unitOfWork.AccountRepository.GetClientAccountByCurrency(clientID,currencyID);
            if (account == null)
            {
                throw new Exception("Account not Found for clientID:" + clientID +" For CurrencyID: "+currencyID);

            }
            if (account.Amount < amount)
            {
                throw new Exception("Amount not enough to process");
            }
            else
            {
                account.Amount = account.Amount - amount;
            }
            _unitOfWork.AccountRepository.Update(account);         
        }
        private async Task AddMoneyToAccount(int  clientID,decimal amount,int currencyID)
        {
            var account = await _unitOfWork.AccountRepository.GetClientAccountByCurrency(clientID, currencyID);
            if (account == null)
            {
                throw new Exception("Account not Found for clientID:" + clientID + " For CurrencyID: " + currencyID);

            }
            if (account.Amount < amount)
            {
                throw new Exception("Amount not enough to process");
            }
            else
            {
                account.Amount = account.Amount + amount;
            }
            _unitOfWork.AccountRepository.Update(account);
        }
        private async Task CreateTrade(int orderID,int matchOrderID)
        {
            await _unitOfWork.TradeRepository.AddAsync(new Domain.Models.EntityModels.Trade()
            {
                OrderID = orderID,
                MathchOrderID = matchOrderID,
                CreateDate = DateTime.Now.ToUniversalTime(),
            });
        }
        private async Task CreatePriceMonitorData(OrderBook orderBook)
        {
            var deleteOldPriceObjects = _unitOfWork.PriceMonitorRepository.GetAll()
                .Where(m => ((m.FromCurrencyID == orderBook.BuyCurrencyID && m.ToCurrencyID == orderBook.SellCurrencyID) ||
                (m.FromCurrencyID == orderBook.SellCurrencyID && m.ToCurrencyID == orderBook.BuyCurrencyID))
                &&m.IsDeleted==false
                ).ToList();
            foreach(var item in deleteOldPriceObjects )
            {
                item.IsDeleted = true;
                item.LastUpdateDate= DateTime.Now.ToUniversalTime();
                _unitOfWork.PriceMonitorRepository.Update(item);
            }
            await _unitOfWork.PriceMonitorRepository.Add(new PriceMonitor()
            {
                FromCurrencyID = orderBook.SellCurrencyID,
                ToCurrencyID = orderBook.BuyCurrencyID,
                Price = orderBook.SellAmount / orderBook.BuyAmount,
                CreateDate=DateTime.Now.ToUniversalTime(),
            });
            await _unitOfWork.PriceMonitorRepository.Add(new PriceMonitor()
            {
                FromCurrencyID = orderBook.BuyCurrencyID,
                ToCurrencyID = orderBook.SellCurrencyID,
                Price = orderBook.BuyAmount / orderBook.SellAmount,
                CreateDate = DateTime.Now.ToUniversalTime(),
               
            });

        }
    }
}
