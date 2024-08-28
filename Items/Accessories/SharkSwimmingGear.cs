using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Accessories
{
    public class SharkSwimmingGear : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shark Swimming Gear");
			Tooltip.SetDefault("Supremely increased mobility in liquid and item speed.");
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
            if(player.wet)
            {
                player.jumpSpeedBoost += 0.75f;
                player.moveSpeed += 0.75f;
                player.meleeSpeed += 0.55f;
                player.pickSpeed += 0.55f; 
                player.accFlipper = true;
            }
        }
        
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Flipper); 
            recipe.AddIngredient(mod.ItemType("SwimmingMembrane"));
            recipe.AddTile(TileID.TinkerersWorkbench);  
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
    }
}