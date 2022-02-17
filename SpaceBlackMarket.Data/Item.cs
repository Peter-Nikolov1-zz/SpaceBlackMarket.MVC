using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Data
{
    public enum ItemType
    {
        Schematics,
        Weapon,
        Artifact,
        Ship,
        Other
    }
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public double ItemPrice { get; set; }

        [Required]
        public string ItemDescription { get; set; }

        [Required]
        public ItemType ItemType { get; set; }

        public bool IsSold { get; set; }

        [Required]
        public bool SmuggleDelivery { get; set; }

        [ForeignKey(nameof(Outpost))] // I want to know what items an Outpost has
        public int? OutpostId { get; set; }
        public virtual Outpost Outpost { get; set; }

        [ForeignKey(nameof(SpaceTravelerProfile))] // I want to know what items a traveler has on their profile
        public int? SpaceTravelerProfileId { get; set; }
        public virtual SpaceTravelerProfile SpaceTravelerProfile { get; set; }

        [ForeignKey(nameof(Purchase))]
        public int? PurchaseId { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}
