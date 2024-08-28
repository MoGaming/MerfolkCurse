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
	public class WoodenGliders : ModGlideritem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wooden Gliders");
			Tooltip.SetDefault("Don't fly too close to the sun.");
		}

		public override void SetDefaults()	
		{
			setGlider(0.25f, 0.5f, 0.25f, true);
			item.width = 22;
			item.height = 20;
			item.value = 100000;
			item.rare = 11;
			item.accessory = true;
		}
		
        public override void AddRecipes() 
        {
            ModRecipe recipe = new ModRecipe(mod); 
            recipe.AddIngredient(ItemID.Wood, 15);
            recipe.AddIngredient(ItemID.Silk, 25);
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this);
            recipe.AddRecipe();
        }   
	}
}
