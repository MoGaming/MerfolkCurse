using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace MerfolkCurse.Items.Accessories
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class SwimmingMembrane : ModItem //player.GetModPlayer<MyPlayer>(mod).SkyblessedGauntlet
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Swimming Mebrane");
			Tooltip.SetDefault("Increased item and player mobility in liquid.");
		}
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 32;
            item.value = Item.sellPrice(0, 0, 25, 0);
            item.rare = 3;
            item.accessory = true;
        }   

        public override void UpdateAccessory(Player player, bool hideVisual) 
        {
            if(player.wet)
            {
                player.jumpSpeedBoost += 0.2f;
                player.moveSpeed += 0.2f;
                player.meleeSpeed += 0.2f;
                player.pickSpeed += 0.2f; 
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FeralClaws);
            recipe.AddIngredient(mod.ItemType("PiscisScales"), 20);  
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Flipper);
            recipe.AddTile(TileID.TinkerersWorkbench);   
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.AddTile(TileID.TinkerersWorkbench);   
            recipe.SetResult(ItemID.Flipper);
            recipe.AddRecipe();
        }   
    }
}