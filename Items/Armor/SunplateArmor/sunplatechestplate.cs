using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using MerfolkCurse.Items.Accessories.GliderItemClass;

namespace MerfolkCurse.Items.Armor.SunplateArmor
{  
    [AutoloadEquip(EquipType.Body)]
    public class sunplatechestplate : ModItem
    {
        public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Sunplate Chestplate"); 
		    Tooltip.SetDefault("15% increased glider speed.\n+10 mana.");
	    }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 1;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {
			ModGliderPlayer.ModPlayer(player).gliderSpeed += 0.1f;
            player.statManaMax2  += 10; 
        }
		
		public override void AddRecipes() //25 sunplate blocks, 10 rain clouds, 60 clouds, and 10 platinum bars
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(19, 10); 
            recipe.AddIngredient(824, 25); 
            recipe.AddIngredient(765, 15); 
            recipe.AddIngredient(751, 60); 
            recipe.AddIngredient(1257, 10); 
            recipe.AddIngredient(320, 8); 
            recipe.AddTile(TileID.SkyMill);   
            recipe.SetResult(this);
            recipe.AddRecipe();

			recipe = new ModRecipe(mod);
            recipe.AddIngredient(706, 10); 
            recipe.AddIngredient(824, 25); 
            recipe.AddIngredient(765, 15); 
            recipe.AddIngredient(751, 60); 
            recipe.AddIngredient(57, 10); 
            recipe.AddIngredient(320, 8); 
            recipe.AddTile(TileID.SkyMill);   
            recipe.SetResult(this);
            recipe.AddRecipe();

			recipe = new ModRecipe(mod);
            recipe.AddIngredient(19, 10); 
            recipe.AddIngredient(824, 25); 
            recipe.AddIngredient(765, 15); 
            recipe.AddIngredient(751, 60); 
            recipe.AddIngredient(1257, 10); 
            recipe.AddIngredient(320, 8); 
            recipe.AddTile(TileID.SkyMill);   
            recipe.SetResult(this);
            recipe.AddRecipe();

			recipe = new ModRecipe(mod);
            recipe.AddIngredient(706, 10); 
            recipe.AddIngredient(824, 25); 
            recipe.AddIngredient(765, 15); 
            recipe.AddIngredient(751, 60);
            recipe.AddIngredient(57, 10);  
            recipe.AddIngredient(320, 8); 
            recipe.AddTile(TileID.SkyMill);   
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
    }
}
