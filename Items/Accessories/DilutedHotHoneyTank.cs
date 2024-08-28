using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Accessories
{
    public class DilutedHotHoneyTank : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Diluted Hot Honey Tank");
			Tooltip.SetDefault("+5 breath, able to breath in all liquids.");
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
            player.GetModPlayer<MyPlayer>().Merfolkcursemaxdeathtime += 300;
            
            if(player.lavaWet || player.honeyWet)
            {
				player.GetModPlayer<MyPlayer>().UiEnabled = false;
                player.GetModPlayer<MyPlayer>().Merfolkcursedeathtime++;
                player.GetModPlayer<MyPlayer>().Merfolkcursedeathtime = player.GetModPlayer<MyPlayer>().Merfolkcursemaxdeathtime;
				player.statDefense += 2;
            }
        }
        
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("LavaTank"));
            recipe.AddIngredient(mod.ItemType("HiveTank"));
            recipe.AddIngredient(mod.ItemType("WaterTank"));
            recipe.AddTile(TileID.TinkerersWorkbench); 
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
    }
}