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
        
        public string OutpostName { get; set; }

        [Required]
        
        public string GalaxyName { get; set; }

        [Required]
        
        public string SystemCoordinates { get; set; }

        [Required]

        public int DangerLevel { get; set; } // Is it a risky trek? Who knows... should probably bring a weapon.

    }
}
