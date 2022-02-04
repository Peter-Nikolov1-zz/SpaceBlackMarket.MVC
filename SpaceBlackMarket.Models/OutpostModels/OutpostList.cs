using SpaceBlackMarket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Models.OutpostModels
{
    public class OutpostList
    {
        [Display(Name = "Outpost Id")]
        public int OutpostId { get; set; }

        [Display(Name = "Outpost Name")]
        public string OutpostName { get; set; }

        [Display(Name = "Galaxy Name")]
        public string GalaxyName { get; set; }

        [Display(Name = "System Coordinates")]
        public string SystemCoordinates { get; set; }

        [Display(Name = "Danger Level")]
        public DangerLevel DangerLevel { get; set; } // Associate with string... 1 = "Not Terribly Dangerous" ... 5 = "DO NOT COME WITHOUT A WEAPON"

    }
}
