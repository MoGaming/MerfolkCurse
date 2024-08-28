using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace MerfolkCurse.Items.Consumables
{
	public class InfoScroll : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Info Scroll");
			Tooltip.SetDefault("Make sure to find water to read this in."
			+	"\nYou cannot go on land for 10 secs without water."
			+	"\nWearing a fishbowl adds 2 seconds of breath."
			+	"\nSubmerged Damage is 50% less effective for non fish players."
			+	"\nAirborne Damage is 50% less effective for fish players."
			+	"\nAll sprites are equal to placeholder."
			+	"\nConsume this for a Gills potion for 1 minute.");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 22;
			item.maxStack = 1;
			item.rare = 1;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 2;
			item.UseSound = SoundID.Item2;
			item.value = Item.sellPrice(0, 0, 10, 0);
            item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			player.AddBuff(4, 3600);

            return true;
        }
    }
}