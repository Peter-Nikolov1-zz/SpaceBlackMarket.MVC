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

        public bool PurchaseItem(PurchaseItem model)
        {
            var entity =
                new Item()
                {
                    ItemId = model.ItemId,
                    ItemName = model.ItemName,
                    ItemPrice = model.ItemPrice
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ItemDetail PurchaseItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Items
                        .Single(e => e.ItemId == id);
                return
                    new ItemDetail
                    {
                        ItemId = entity.ItemId,
                        ItemName = entity.ItemName,
                        ItemPrice = entity.ItemPrice
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
