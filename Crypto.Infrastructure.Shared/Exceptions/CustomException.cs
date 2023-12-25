using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Infrastructure.Shared.Exceptions
{
    public class CustomException:Exception
    {
        public CustomException(string message):base(message) { }
        public CustomException(string message,Exception exception):base(message,exception) { }
    }
}
