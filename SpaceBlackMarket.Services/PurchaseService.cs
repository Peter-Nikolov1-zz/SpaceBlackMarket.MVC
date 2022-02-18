using SpaceBlackMarket.Data;
using SpaceBlackMarket.Models.ItemModels;
using SpaceBlackMarket.Models.PurchaseModels;
using SpaceBlackMarketMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Services
{
    public class PurchaseService
    {
        private readonly Guid _userId;

        public PurchaseService(Guid userId)
        {
            _userId = userId;
        }

        public bool PurchaseItem(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var item =
                    ctx
                        .Items
                        .Single(e => e.ItemId == id);

                var profile =
                    ctx
                        .SpaceTravelerProfile
                        .Single(e => e.OwnerId == _userId);

                item.SpaceTravelerProfileId = profile.SpaceTravelerProfileId;
                item.IsSold = true;
                ctx.SaveChanges();

                var newBalance = profile.Credits - item.ItemPrice;
                profile.Credits = newBalance;
                return ctx.SaveChanges() >= 1;
            }
        }

        public PurchaseItem PurchaseItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var item =
                    ctx
                        .Items
                        .Single(e => e.ItemId == id);
                return
                    new PurchaseItem
                    {
                        ItemName = item.ItemName,
                        ItemPrice = item.ItemPrice
                    };
            }
        }

        public IEnumerable<PurchaseList> GetPurchases()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Purchases
                        .Select(
                            e =>
                                new PurchaseList
                                {
                                    PurchaseId = e.PurchaseId,
                                    PurchaseTotal = e.PurchaseTotal,
                                    PurchaseDate = e.PurchaseDate
                                }
                       );
                return query.ToArray();
            }
        }
    }
}
