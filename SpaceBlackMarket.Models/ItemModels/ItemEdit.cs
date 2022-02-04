using SpaceBlackMarket.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Models.ItemModels
{
    public class ItemEdit
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public double ItemPrice { get; set; }

        public string ItemDescription { get; set; }

        public ItemType ItemType { get; set; }

        public bool SmuggleDelivery { get; set; }

    }
}
