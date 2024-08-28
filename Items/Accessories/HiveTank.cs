using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Accessories
{
    public class HiveTank : ModItem //add all the recipes to each and try to fix the ui
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hive Tank");
			Tooltip.SetDefault("Able to breath in honey.");
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
			if(player.honeyWet)
			{
				player.GetModPlayer<MyPlayer>().UiEnabled = false;
				player.GetModPlayer<MyPlayer>().Merfolkcursedeathtime = player.GetModPlayer<MyPlayer>().Merfolkcursemaxdeathtime;
                player.GetModPlayer<MyPlayer>().Merfolkcursedeathtime++;
				player.statDefense += 2;
			}
        }
        
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.needHoney = true;
            recipe.AddIngredient(ItemID.Stinger); 
            recipe.AddIngredient(ItemID.Hive, 4); 
            recipe.AddIngredient(mod.ItemType("EmptyTank"));
            recipe.AddTile(TileID.WorkBenches);  
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
    }
}