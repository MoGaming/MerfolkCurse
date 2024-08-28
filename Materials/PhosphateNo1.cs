using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Materials
{
	public class PhosphateNo1 : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Phosphate No.1");
			Tooltip.SetDefault("I wonder if this contains sugar.");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 22;
			item.maxStack = 99;
			item.value = 100;
            item.rare = 4; 
		}
	}
}