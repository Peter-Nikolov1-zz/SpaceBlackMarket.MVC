using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Data
{
    public class SpacePirateProfile
    {
        [Key]
        public int SpacePirateId { get; set; }

        [Required]
        [Display(Name = "What do you go by?")]
        public string PirateAlias { get; set; }

        [Required]
        public double Credits { get; set; }

        [Required]
        [Display(Name = "How much trouble are you in?")]
        public string WantedLevel { get; set; }

        public bool WillingToCooperate { get; set; }

        [Required]
        [Display(Name = "Your current inventory")]
        public List<Item> Items { get; set; }
    }
}
