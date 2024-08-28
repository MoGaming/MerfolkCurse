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
	public class Humanpotion : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Human Potion");
			Tooltip.SetDefault("Temperary become human for 3 minutes.");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 22;

			item.maxStack = 99;
			item.rare = 4;

			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 2;
			item.UseSound = SoundID.Item2;

			item.value = Item.sellPrice(0, 0, 25, 0);
            item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			if(player.GetModPlayer<MyPlayer>().Merfolkcurse == true)
			{
				Main.NewText(player.name + " became human!", 127, 187, 253);
			}
			player.AddBuff(mod.BuffType("TemperaryHuman"), 14550);

            return true;
        }
    }
}