using SpaceBlackMarket.Data;
using SpaceBlackMarket.Models.OutpostModels;
using SpaceBlackMarketMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Services
{
    public class OutpostService
    {
        public bool CreateOutpost(OutpostCreate model)
        {
            var entity =
                new Outpost()
                {
                    OutpostName = model.OutpostName,
                    GalaxyName = model.GalaxyName,
                    SystemCoordinates = model.SystemCoordinates,
                    DangerLevel = model.DangerLevel,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Outposts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OutpostList> GetOutposts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Outposts
                        .Select(
                            e =>
                                new OutpostList
                                {
                                    OutpostId = e.OutpostId,
                                    OutpostName = e.OutpostName,
                                    GalaxyName = e.GalaxyName,
                                    SystemCoordinates = e.SystemCoordinates,
                                    DangerLevel = e.DangerLevel
                                }
                        );
                return query.ToArray();
            }
        }

        public OutpostDetail GetOutpostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Outposts
                        .Single(e => e.OutpostId == id);
                return
                    new OutpostDetail
                    {
                        OutpostId = entity.OutpostId,
                        OutpostName = entity.OutpostName,
                        GalaxyName = entity.GalaxyName,
                        SystemCoordinates = entity.SystemCoordinates,
                        DangerLevel = entity.DangerLevel
                    };
                
            }
        }

        public bool DeleteOutpost(int outpostId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Outposts
                        .Single(e => e.OutpostId == outpostId);

                ctx.Outposts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
