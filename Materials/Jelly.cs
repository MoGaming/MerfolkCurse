using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Materials
{
	public class Jelly : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Jelly");
			Tooltip.SetDefault("Slow and smelly, just like your mother B)");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 22;
			item.maxStack = 99;
			item.value = 100;
            item.rare = 2; 
		}
	}
}