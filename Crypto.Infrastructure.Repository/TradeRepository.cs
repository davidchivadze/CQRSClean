﻿using Crypto.Domain.Models.EntityModels;
using Crypto.Domain.Repository;
using Crypto.Infrastructure.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Infrastructure.Repository
{
    public class TradeRepository:BaseRepository<Trade>,ITradeRepository
    {
        public TradeRepository(CryptoContext context) : base(context) { }

    }
}
