using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MerfolkCurse.Items.Accessories.GliderItemClass;

namespace MerfolkCurse.Items.Accessories.GliderItemClass
{
	[AutoloadEquip(EquipType.Wings)]
	public class SunplateGliders : ModGlideritem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunplate Gliders");
			Tooltip.SetDefault("The skies the limit.");
		}

		public override void SetDefaults()	
		{
			setGlider(2f, 2.5f, 1.5f, true);
			item.width = 22;
			item.height = 20;
			item.value = 100000;
			item.rare = 11;
			item.accessory = true;
		}
		
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RainCloud, 5);
            recipe.AddIngredient(ItemID.Cloud, 10);
            recipe.AddIngredient(ItemID.Feather, 15);
            recipe.AddIngredient(ItemID.SunplateBlock, 20);
            recipe.AddTile(TileID.SkyMill);   
            recipe.SetResult(this);
            recipe.AddRecipe();
        }  
	}
}
