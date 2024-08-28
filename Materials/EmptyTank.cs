using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Materials
{
	public class EmptyTank : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Empty Tank");
			Tooltip.SetDefault("'Imagine trying to use this to survive underwater'\n-This post was made by the water tank gang.");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 22;
			item.maxStack = 99;
			item.value = 100;
            item.rare = 2; 
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 12); 
            recipe.AddIngredient(ItemID.IronBar, 8); 
            recipe.AddIngredient(ItemID.Glass, 6); 
            recipe.AddTile(TileID.HeavyWorkBench);   
            recipe.SetResult(this);
            recipe.AddRecipe();

			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 12); 
            recipe.AddIngredient(ItemID.LeadBar, 8); 
            recipe.AddIngredient(ItemID.Glass, 6); 
            recipe.AddTile(TileID.HeavyWorkBench);   
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}