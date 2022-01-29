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
        [Display(Name = "Item Id")]
        public int ItemId { get; set; }

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Description of Item")]
        public string ItemDescription { get; set; }

        [Display(Name = "Item Price")]
        public int ItemPrice { get; set; }
    }
}
