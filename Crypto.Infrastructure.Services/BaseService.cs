using Crypto.Domain.Repository.UnitOfWork;
using Crypto.Domain.Services;

namespace Crypto.Infrastructure.Services
{
    public class BaseService : IBaseService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork) { 
            _unitOfWork= unitOfWork;
        }

    }
}
