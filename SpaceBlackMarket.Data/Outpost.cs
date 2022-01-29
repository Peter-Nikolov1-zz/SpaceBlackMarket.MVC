using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Data
{
    public class Outpost
    {
        [Key]
        public int OutpostId { get; set; }

        [Required]
        [Display(Name = "Outpost Name")]
        public string OutpostName { get; set; }

        [Required]
        [Display(Name = "Galaxy Name")]
        public string GalaxyName { get; set; }

        [Required]
        [Display(Name = "System Coordinates")]
        public string SystemCoordinates { get; set; }

        [Required]
        [Display(Name = "How likely are you to get mugged?")]
        public int DangerLevel { get; set; } // Is it a risky trek? Who knows... should probably bring a weapon.

        public List<Item> Items { get; set; }

    }
}
