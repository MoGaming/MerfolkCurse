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

namespace MerfolkCurse.Items.Consumables
{
	public class Merfolkremoval : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Neptune's Tears");
			Tooltip.SetDefault("Remove merfolk effect.\nWARNING: YOU WILL NOT BE ABLE TO BECOME MERFOLK ANYMORE.");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 22;

			item.maxStack = 99;
			item.rare = 4;

			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 2;
			item.UseSound = SoundID.Item2;

			item.value = Item.sellPrice(0, 0, 25, 0);
            item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			if(player.GetModPlayer<MyPlayer>().Merfolkcurseremoval == true)
			{
				return false;
			}

			player.ClearBuff(mod.BuffType("TemperaryHuman"));
			if(player.GetModPlayer<MyPlayer>().Merfolkcurse == true)
			{
				Main.NewText(player.name + " has remove his curse!", 127, 187, 253);
			}
			player.GetModPlayer<MyPlayer>().Merfolkcurseremoval = true;

            return true;
        }

		public override void AddRecipes() 
        {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(497); //neptunes shell
            recipe.AddIngredient(66, 15); //Purification_Powder
            recipe.AddTile(13);  
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
		}
    }
}