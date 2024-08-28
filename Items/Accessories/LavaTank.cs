using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Accessories
{
    public class LavaTank : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lava Tank");
			Tooltip.SetDefault("Able to breath in lava.");
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
			if(player.lavaWet)
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
            recipe.needLava = true;
            recipe.AddIngredient(ItemID.Obsidian, 6); 
            recipe.AddIngredient(ItemID.Hellstone, 2); 
            recipe.AddIngredient(mod.ItemType("EmptyTank"));
            recipe.AddTile(TileID.Anvils);  
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
    }
}