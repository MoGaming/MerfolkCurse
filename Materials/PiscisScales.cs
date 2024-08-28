using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Materials
{
	public class PiscisScales : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fish Scale");
		}
		public override void SetDefaults()
		{
			item.width = 12; 
            item.height = 12;
            item.useTime = 20;
            item.useAnimation = 20; 
            item.useStyle = 1; 
            item.value = Item.sellPrice(0, 0, 0, 20);
            item.rare = 2; 
            item.maxStack = 999; 
        }
	}
}
