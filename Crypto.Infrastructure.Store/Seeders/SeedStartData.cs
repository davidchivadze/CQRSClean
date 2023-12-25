using Crypto.Domain.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Infrastructure.Store.Seeders
{
    public static class SeedStartData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(new Currency()
            {
                Id = 1,
                 Description="BTC"
            });
            modelBuilder.Entity<Currency>().HasData(new Currency()
            {
                Id = 2,
                Description = "USDT"
            });
            modelBuilder.Entity<Client>().HasData(new Client()
            {
                Id = 1,
                FirstName = "Davit",
                LastName = "Chivadze"
            });
            modelBuilder.Entity<ClientAccount>().HasData(new ClientAccount()
            {
                Id = 1,
                ClientId = 1,
                CurrencyID = 1,
                AccountNumber = "123456789123",
                Amount = 50,
            });
            modelBuilder.Entity<ClientAccount>().HasData(new ClientAccount()
            {
                Id = 2,
                ClientId = 1,
                CurrencyID = 2,
                AccountNumber = "123456789123",
                Amount = 50,
            });
        }
    }
}
