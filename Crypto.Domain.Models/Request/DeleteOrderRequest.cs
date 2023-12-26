using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Domain.Models.Request
{
    public class DeleteOrderRequest
    {
        public int OrderID { get; set; }    
    }
}
