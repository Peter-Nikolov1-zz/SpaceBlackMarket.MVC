using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Data
{
    public enum DangerLevel
    {
        CRITICAL,
        High,
        Medium,
        Low,
    }

    public class Outpost
    {
        [Key]
        public int OutpostId { get; set; }

        [Required]
        
        public string OutpostName { get; set; }

        [Required]
        
        public string GalaxyName { get; set; }

        [Required]
        
        public string PlanetName { get; set; }

        [Required]

        public DangerLevel DangerLevel { get; set; } // Is it a risky trek? Who knows... should probably bring a weapon.

    }
}
