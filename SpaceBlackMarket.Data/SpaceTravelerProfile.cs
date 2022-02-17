using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        TheyStoleCandyFromABaby,
    }

    public class SpaceTravelerProfile
    {
        [Key]
        public int SpaceTravelerProfileId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string TravelerAlias { get; set; }

        [Required]
        public double Credits { get; set; }

        [Required]
        public WantedLevel WantedLevel { get; set; }

        public bool WillingToCooperate { get; set; }

        [ForeignKey(nameof(Purchase))]
        public int? PurchaseId { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}
