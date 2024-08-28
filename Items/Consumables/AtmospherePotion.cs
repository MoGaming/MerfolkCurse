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
	public class AtmospherePotion : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Atmosphere Potion");
			Tooltip.SetDefault("Skyline Buff for 3 minutes.");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 22;

			item.maxStack = 99;
			item.rare = 3;

			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 2;
			item.UseSound = SoundID.Item2;

			item.value = Item.sellPrice(0, 0, 20, 0);
            item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			player.AddBuff(mod.BuffType("AtmosphereBuff"), 14550); 

            return true;
        }

		public override void AddRecipes() 
        {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SunplateShard", 6); 
            recipe.AddIngredient(ItemID.Feather, 2); 
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddTile(13);  
            recipe.SetResult(this);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SunplateShard", 6); 
            recipe.AddIngredient(ItemID.Feather, 2); 
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddTile(TileID.AlchemyTable);  
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
    }
}