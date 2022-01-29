using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Data
{
    public class SpaceTravelerProfile
    {
        [Key]
        public int SpaceTravelerId { get; set; }

        [Required]

        public string PirateAlias { get; set; }

        [Required]
        public double Credits { get; set; }

        [Required]

        public string WantedLevel { get; set; }

        public bool WillingToCooperate { get; set; }

    }
}
