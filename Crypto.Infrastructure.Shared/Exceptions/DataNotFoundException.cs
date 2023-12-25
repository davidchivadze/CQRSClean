using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Infrastructure.Shared.Exceptions
{
    public class DataNotFoundException:CustomException
    {
        public DataNotFoundException(string message) : base(message) { }
        public DataNotFoundException(string message, Exception exception) : base(message, exception) { }
    }
}
