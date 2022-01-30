using SpaceBlackMarket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Models.ItemModels
{
    public class ItemsList
    {
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Item Type")]
        public ItemType ItemType { get; set; }

        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }
    }
}
