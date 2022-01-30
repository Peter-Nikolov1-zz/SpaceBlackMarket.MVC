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
        private readonly Guid _travelerId;

        public ItemService(Guid travlelerId)
        {
            _travelerId = travlelerId;
        }

        public bool CreateItem(ItemCreate model)
        {
            var entity =
                new Item()
                {
                    TravelerId = _travelerId,
                    ItemName = model.Name,
                    ItemPrice = model.Price,
                    ItemDescription = model.Description,
                    ItemType = model.Type
                };
            
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ItemsList> GetItems()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Items
                        .Where(e => e.TravelerId == _travelerId)
                        .Select(
                            e =>
                                new ItemsList
                                {
                                    ItemName = e.ItemName,
                                    ItemType = e.ItemType,
                                    ItemDescription = e.ItemDescription
                                }
                        );

                return query.ToArray();
            }
        }
        
    }
}
