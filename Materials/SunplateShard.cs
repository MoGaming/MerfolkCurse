using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Materials
{
	public class SunplateShard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunplate Shard");
		}
		public override void SetDefaults()
		{
			item.width = 12; 
            item.height = 12;
            item.useTime = 20;
            item.useAnimation = 20; 
            item.useStyle = 1; 
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = 2; 
            item.maxStack = 999; 
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 12);
            recipe.AddTile(TileID.SkyMill);  
            recipe.SetResult(824);
            recipe.AddRecipe();
		}
	}
}
