﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Domain.Models.Response
{
    public class ProcessOrderResponse
    {
        public int OrderID { get; set; }
        public int MatchedOrderID { get;set; }
        public bool Success { get; set; }
    }
}
