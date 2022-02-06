using SpaceBlackMarket.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Models.OutpostModels
{
    public class OutpostEdit
    {
        public int OutpostId { get; set; }

        public string OutpostName { get; set; }

        public string GalaxyName { get; set; }

        public string PlanetName { get; set; }

        public DangerLevel DangerLevel { get; set; }
    }
}
