using Crypto.Domain.Models.Request;
using Crypto.Domain.Models.Response;

namespace Crypto.Domain.Services
{
    public interface IClientService:IBaseService
    {
        Task<List<GetOrderResponse>> GetOrders(GetOrderRequest request);

    }
}
