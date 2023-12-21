using Crypto.Domain.Models.Request;
using Crypto.Domain.Models.Response;
using Crypto.Domain.Repository.UnitOfWork;
using Crypto.Domain.Services;
using Crypto.Infrastructure.Shared;
namespace Crypto.Infrastructure.Services
{
    public class ClientService : BaseService, IClientService
    {
        public ClientService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<List<GetOrderResponse>> GetOrders(GetOrderRequest request)
        {
            var result=_unitOfWork.OrderBookRepository.GetAll().ToList();
            return result.Select(m=>m.AsGetOrderResponse()).ToList();
        }
    }
}
