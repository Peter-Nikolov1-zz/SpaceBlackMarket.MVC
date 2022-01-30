using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Data
{
    public enum WantedLevel
    {
        GalacticFedsWantThem,
        HighlyDesired,
        TheyOweSomeTime,
        TheyStoleCandy,
    }

    public class SpaceTravelerProfile
    {
        [Key]
        public int SpaceTravelerId { get; set; }

        [Required]
        public Guid TravelerId { get; set; }

        [Required]
        public string TravelerAlias { get; set; }

        [Required]
        public double Credits { get; set; }

        [Required]
        public WantedLevel WantedLevel { get; set; }

        public bool WillingToCooperate { get; set; }

    }
}
