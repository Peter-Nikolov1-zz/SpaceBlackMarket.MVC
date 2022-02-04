using SpaceBlackMarket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Models.SpaceTravelerModels
{
    public class SpaceTravelerEdit
    {
        public int SpaceTravelerProfileId { get; set; }

        public Guid OwnerId { get; set; }

        [Display(Name = "Traveler Alias?")]
        public string TravelerAlias { get; set; }

        [Display(Name = "How many Credits?")]
        public double Credits { get; set; }

        [Display(Name = "Wanted Level?")]
        public WantedLevel WantedLevel { get; set; }

        [Display(Name = "Will they cooperate?")]
        public bool WillingToCooperate { get; set; }
    }
}
