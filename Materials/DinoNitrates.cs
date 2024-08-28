using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Materials
{
	public class DinoNitrates : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Dino Nitrates");
			Tooltip.SetDefault("Nitrogenous Petri Dish");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 22;
			item.maxStack = 99;
			item.value = 100;
            item.rare = 4; 
            item.value = Item.sellPrice(0, 25, 0, 0);
		}
	}
}