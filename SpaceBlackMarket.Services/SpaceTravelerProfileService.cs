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
    }
}
