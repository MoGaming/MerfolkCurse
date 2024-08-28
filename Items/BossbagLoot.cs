using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items
{
	internal sealed class BossbagLoot : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag")
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(20) == 1) //mogaming set
                    {
                        //player.QuickSpawnItem(mod.ItemType("RoboticLegs"));
                        //player.QuickSpawnItem(mod.ItemType("RoboticSuit"));
                        //player.QuickSpawnItem(mod.ItemType("RoboticHeadset"));
                    }
                }
            }
        }
    }
}