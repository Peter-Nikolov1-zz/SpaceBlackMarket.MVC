using SpaceBlackMarket.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Models.SpaceTravelerModels
{
    public class SpaceTravelerProfilePage
    {
        public int SpaceTravelerProfileId { get; set; }

        public Guid OwnerId { get; set; }

        public string TravelerAlias { get; set; }

        public double Credits { get; set; }

        public WantedLevel WantedLevel { get; set; }

        public bool WillingToCooperate { get; set; }

    }
}
