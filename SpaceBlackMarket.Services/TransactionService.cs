using SpaceBlackMarket.Data;
using SpaceBlackMarket.Models.TransactionModels;
using SpaceBlackMarketMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Services
{
    public class TransactionService
    {
        public bool Create(TransactionCreate model)
        {
            var entity =
                new Transaction()
                {
                    DateOfPurchase = model.DateOfPurchase,
                    CreditsAmount = model.CreditsAmount
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Transaction.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
