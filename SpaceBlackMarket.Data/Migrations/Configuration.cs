namespace SpaceBlackMarket.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SpaceBlackMarketMVC.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SpaceBlackMarketMVC.Data.ApplicationDbContext context)
        {
            context.Outposts.AddOrUpdate(n => n.OutpostId, new Outpost() { OutpostName = "Klingons Only", GalaxyName = "Milky Way", PlanetName = "Kronos", DangerLevel = DangerLevel.CRITICAL },
                new Outpost() { OutpostName = "Rapunzel's Tower", GalaxyName = "Cowboy Galaxy", PlanetName = "GC-245", DangerLevel = DangerLevel.Low },
                new Outpost() { OutpostName = "Knowhere", GalaxyName = "Unknown", PlanetName = "Unknown", DangerLevel = DangerLevel.CRITICAL },
                new Outpost() { OutpostName = "Snickers Post", GalaxyName = "Milky Way", PlanetName = "Europa", DangerLevel = DangerLevel.Low },
                new Outpost() { OutpostName = "Friendly Outpost", GalaxyName = "Andromeda", PlanetName = "FS-84", DangerLevel = DangerLevel.Medium },
                new Outpost() { OutpostName = "Unfriendly Outpost", GalaxyName = "MS591", PlanetName = "TC-329", DangerLevel = DangerLevel.High });
            context.SaveChanges();

            context.Items.AddOrUpdate(n => n.ItemId, new Item() { ItemName = "Modified Speed Bike", ItemPrice = 5530.92, ItemDescription = "Illegally modified speed bike from the Andromeda system. Used to rob many galactic banks.", ItemType = ItemType.Ship, SmuggleDelivery = false },
                new Item() { ItemName = "Anakins Legs", ItemPrice = 1500000, ItemDescription = "Darth's legs. Horrible smell.", ItemType = ItemType.Other, SmuggleDelivery = true },
                new Item() { ItemName = "Ancient Chalice", ItemPrice = 9870.5, ItemDescription = "Stolen from the anicient civilization of the Monkeydoos. They still want it back so be careful.", ItemType = ItemType.Artifact, SmuggleDelivery = false },
                new Item() { ItemName = "Electrified Brass Knuckles", ItemPrice = 15530.92, ItemDescription = "Taserface used these during his many dangerous encounters. Make sure they are turned off before putting them away...", ItemType = ItemType.Weapon, SmuggleDelivery = true });
            context.SaveChanges();

            context.SpaceTravelerProfile.AddOrUpdate(n => n.SpaceTravelerProfileId, new SpaceTravelerProfile() { TravelerAlias = "Greedy Traveler", Credits = 5203.62, WantedLevel = WantedLevel.TheyStoleCandyFromABaby, WillingToCooperate = false },
                new SpaceTravelerProfile() { TravelerAlias = "Lungebob Squareshorts", Credits = 529.5, WantedLevel = WantedLevel.GalacticFedsWantThem, WillingToCooperate = true },
                new SpaceTravelerProfile() { TravelerAlias = "Neter Pikolov", Credits = 10000000, WantedLevel = WantedLevel.TheyStoleCandyFromABaby, WillingToCooperate = true },
                new SpaceTravelerProfile() { TravelerAlias = "Weirdo Son", Credits = 1462.94, WantedLevel = WantedLevel.GalacticFedsWantThem, WillingToCooperate = false },
                new SpaceTravelerProfile() { TravelerAlias = "Squirrel", Credits = 2624, WantedLevel = WantedLevel.HighlyDesired, WillingToCooperate = true });
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
