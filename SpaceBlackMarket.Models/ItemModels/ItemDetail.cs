using SpaceBlackMarket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Models.ItemModels
{
    public class ItemDetail
    {
        public int ItemId { get; set; }

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Item Price")]
        public double ItemPrice { get; set; }

        [Display(Name = "Description")]
        public string ItemDescription { get; set; }

        [Display(Name = "Type")]
        public ItemType ItemType { get; set; }

        [Display(Name = "Available for Smuggle Delivery")]
        public bool SmuggleDelivery { get; set; }
    }
}
