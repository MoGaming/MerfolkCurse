using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MerfolkCurse.Items.Tools
{
	public class Commandrod : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Command Rod");
			Tooltip.SetDefault("Commands your summons.");
		}

		public override void SetDefaults()
		{
			item.damage = 5;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.tileBoost += 2;
		}

       public override bool CanUseItem(Player player)
		{
			if(player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}else
            {
                player.MinionNPCTargetAim();
            }
			return base.UseItem(player);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod); //work on this
			recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddIngredient(75, 2);  
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}