using SpaceBlackMarket.Data;
using SpaceBlackMarket.Models.SpaceTravelerModels;
using SpaceBlackMarketMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Services
{
    public class SpaceTravelerProfileService
    {
        private readonly Guid _userId;

        public SpaceTravelerProfileService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSpaceTraveler(SpaceTravelerCreate model)
        {
            var entity =
                new SpaceTravelerProfile()
                {
                    OwnerId = _userId,
                    TravelerAlias = model.TravelerAlias,
                    WantedLevel = model.WantedLevel,
                    WillingToCooperate = model.WillingToCooperate,
                    Credits = model.Credits
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SpaceTravelerProfile.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SpaceTravelerList> GetSpaceTravelers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .SpaceTravelerProfile
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new SpaceTravelerList
                                {
                                    SpaceTravelerProfileId = e.SpaceTravelerProfileId,
                                    TravelerAlias = e.TravelerAlias,
                                    WantedLevel = e.WantedLevel,
                                    WillingToCooperate = e.WillingToCooperate
                                }
                       );
                return query.ToArray();
            }
        }

        public SpaceTravelerDetail GetSpaceTravelerById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SpaceTravelerProfile
                        .Single(e => e.SpaceTravelerProfileId == id);
                return
                        new SpaceTravelerDetail
                        {
                            SpaceTravelerProfileId = entity.SpaceTravelerProfileId,
                            //OwnerId = entity.OwnerId,
                            TravelerAlias = entity.TravelerAlias,
                            Credits = entity.Credits,
                            WantedLevel = entity.WantedLevel,
                            WillingToCooperate = entity.WillingToCooperate
                        };
            }
        }

        public bool UpdateSpaceTraveler(SpaceTravelerEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SpaceTravelerProfile
                        .Single(e => e.SpaceTravelerProfileId == model.SpaceTravelerProfileId);

                entity.SpaceTravelerProfileId = model.SpaceTravelerProfileId;
                //entity.OwnerId = model.OwnerId;
                entity.TravelerAlias = model.TravelerAlias;
                entity.Credits = model.Credits;
                entity.WantedLevel = model.WantedLevel;
                entity.WillingToCooperate = model.WillingToCooperate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSpaceTraveler(int spaceTravelerId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SpaceTravelerProfile
                        .Single(e => e.SpaceTravelerProfileId == spaceTravelerId);

                ctx.SpaceTravelerProfile.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
