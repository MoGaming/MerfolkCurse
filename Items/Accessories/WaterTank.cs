using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Accessories
{
    public class WaterTank : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Water Tank");
			Tooltip.SetDefault("+4 seconds to breath meter.");
		}
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 32;
            item.value = Item.sellPrice(0, 0, 40, 0);
            item.rare = 4;
            item.accessory = true;
        }   

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>().Merfolkcursemaxdeathtime += 240; 
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.needWater = true;
            recipe.AddIngredient(ItemID.Seashell, 3); 
            recipe.AddIngredient(ItemID.Coral, 6); 
            recipe.AddIngredient(mod.ItemType("EmptyTank"));
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
    }
}