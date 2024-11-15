using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.SpecialOrders;
using StardewValley.TerrainFeatures;

namespace GreenhouseUpgrades
{
    public class ModEntry : Mod
    {

        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayStarted += OnDayStarted;
        }
        private bool HasSpecialOrder(string orderID) //Checks if the player already has the special order.
        {
            foreach (SpecialOrder order in Game1.player.team.specialOrders)
            {
                if (order.questKey.Equals(orderID))
                {
                    return true;
                }
            }
            return false;
        }

        private void AddSpecialOrder(string orderID) //Gives the player the special orders for the greenhouse upgrades.
        {
            if (!HasSpecialOrder(orderID))
            {
                SpecialOrder specialOrder = SpecialOrder.GetSpecialOrder(orderID, null);
                if (specialOrder != null)
                {
                    Game1.player.team.specialOrders.Add(specialOrder);
                }
            }
        }
        private void OnDayStarted(object sender, DayStartedEventArgs e)
        {
            if (Game1.player != null)
            {
                if (!Game1.player.hasOrWillReceiveMail("CosmicKillsSouls.GreenhouseV2") && Game1.player.hasOrWillReceiveMail("ccPantry")) //Checks if the player is able to get the first SpecialOrder.
                {
                    if (!HasSpecialOrder("GreenhouseUpgrade_GreenhouseV2"))
                    {
                        AddSpecialOrder("GreenhouseUpgrade_GreenhouseV2");
                    }
                }
                if (!Game1.player.hasOrWillReceiveMail("CosmicKillsSouls.GreenhouseV3") && Game1.player.hasOrWillReceiveMail("CosmicKillsSouls.GreenhouseV2")) //Checks if the player is able to get the second SpecialOrder.
                {
                    if (!HasSpecialOrder("GreenhouseUpgrade_GreenhouseV3"))
                    {
                        AddSpecialOrder("GreenhouseUpgrade_GreenhouseV3");
                    }
                }
                if (!Game1.player.hasOrWillReceiveMail("CosmicKillsSouls.GreenhouseV4") && Game1.player.hasOrWillReceiveMail("CosmicKillsSouls.GreenhouseV3")) //Checks if the player is able to get the third SpecialOrder.
                {
                    if (!HasSpecialOrder("GreenhouseUpgrade_GreenhouseV4"))
                    {
                        AddSpecialOrder("GreenhouseUpgrade_GreenhouseV4");
                    }
                }
                if (!Game1.player.hasOrWillReceiveMail("CosmicKillsSouls.GreenhouseV5") && Game1.player.hasOrWillReceiveMail("CosmicKillsSouls.GreenhouseV4")) //Checks if the player is able to get the fourth SpecialOrder.
                {
                    if (!HasSpecialOrder("GreenhouseUpgrade_GreenhouseV5"))
                    {
                        AddSpecialOrder("GreenhouseUpgrade_GreenhouseV5");
                    }
                }
                if (!Game1.player.hasOrWillReceiveMail("CosmicKillsSouls.GreenhouseV6") && Game1.player.hasOrWillReceiveMail("CosmicKillsSouls.GreenhouseV5")) //Checks if the player is able to get the fith SpecialOrder.
                {
                    if (!HasSpecialOrder("GreenhouseUpgrade_GreenhouseV6"))
                    {
                        AddSpecialOrder("GreenhouseUpgrade_GreenhouseV6");
                    }
                }
            }

            if (Game1.player.hasOrWillReceiveMail("CosmicKillsSouls.GreenhouseV5")) //Checks if the player has upgraded to the T5 greenhouse.
            {
                var building = Game1.getLocationFromName("Greenhouse");
                WaterCropsInRectangle(building, 5, 11, 35, 41); //Changes the hoed dirt into watered dirt.
            }
        }
        private static void WaterCropsInRectangle(GameLocation location, int xStart, int yStart, int xEnd, int yEnd)
        {
            for (int x = xStart; x <= xEnd; x++)
            {
                for (int y = yStart; y <= yEnd; y++)
                {
                    var tile = new Vector2(x, y);
                    if (location.terrainFeatures.ContainsKey(tile) && location.terrainFeatures[tile] is HoeDirt dirt) //Checks if the area contains the rectangle and that is is HoeDirt.
                    {
                        dirt.state.Value = HoeDirt.watered; //Sets the dirt to watered.
                    }
                }

            }
        }
    }
}
