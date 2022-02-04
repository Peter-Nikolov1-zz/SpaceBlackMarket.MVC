using SpaceBlackMarket.Data;
using SpaceBlackMarket.Models.ItemModels;
using SpaceBlackMarketMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Services
{
    public class ItemService
    {
        private readonly Guid _userId;

        public ItemService(Guid ownerId)
        {
            _userId = ownerId;
        }

        public bool CreateItem(ItemCreate model)
        {
            var entity =
                new Item()
                {
                    SpaceTravelerProfileId = model.SpaceTravelerProfileId,
                    ItemName = model.Name,
                    ItemPrice = model.Price,
                    ItemDescription = model.Description,
                    ItemType = model.Type
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ItemsList> GetItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                     ctx
                         .Items
                         .Select(
                             e =>
                                 new ItemsList
                                 {
                                     ItemId = e.ItemId,
                                     ItemName = e.ItemName,
                                     ItemType = e.ItemType,
                                     ItemDescription = e.ItemDescription
                                 }
                         );

                return query.ToArray();
            }
        }

        public ItemDetail GetItemById(int id)
        {
            using(var ctx = new ApplicationDbContext())
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
                        ItemPrice = entity.ItemPrice,
                        ItemDescription = entity.ItemDescription,
                        ItemType = entity.ItemType,
                        SmuggleDelivery = entity.SmuggleDelivery
                    };
            }
        }

        public bool UpdateItem(ItemEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Items
                        .Single(e => e.ItemId == model.ItemId);

                entity.ItemId = model.ItemId;
                entity.ItemName = model.ItemName;
                entity.ItemPrice = model.ItemPrice;
                entity.ItemDescription = model.ItemDescription;
                entity.ItemType = model.ItemType;
                entity.SmuggleDelivery = model.SmuggleDelivery;

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
