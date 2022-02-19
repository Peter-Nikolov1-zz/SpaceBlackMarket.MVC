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

        public bool CreatePurchase(Item item)
        {
            var entity =
                new Purchase()
                {
                    PurchaseDate = DateTime.Now,
                    PurchaseTotal = item.ItemPrice,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Purchases.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool PurchaseItem(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var item =
                    ctx
                        .Items
                        .SingleOrDefault(e => e.ItemId == id);

                CreatePurchase(item);

                var profile =
                    ctx
                        .SpaceTravelerProfile
                        .SingleOrDefault(e => e.OwnerId == _userId);

                item.SpaceTravelerProfileId = profile.SpaceTravelerProfileId;
                item.IsSold = true;
                ctx.SaveChanges();

                var newBalance = profile.Credits - item.ItemPrice;
                profile.Credits = newBalance;
                return ctx.SaveChanges() >= 1;
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
                                    PurchaseTotal = e.PurchaseTotal,
                                    PurchaseDate = e.PurchaseDate
                                }
                       );
                return query.ToArray();
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

        public PurchaseDetail GetPurchaseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Purchases
                        .Single(e => e.PurchaseId == id);
                return
                    new PurchaseDetail
                    {
                        PurchaseId = entity.PurchaseId,
                        PurchaseTotal = entity.PurchaseTotal,
                    };
            }
        }
    }
}
