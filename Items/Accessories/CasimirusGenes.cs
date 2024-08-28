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
using MerfolkCurse;
using MerfolkCurse.SubmergedDamageClass;
using MerfolkCurse.AirborneDamageClass;

namespace MerfolkCurse.Items.Accessories
{
    public class CasimirusGenes : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Casimirus Genes");
			Tooltip.SetDefault("Replaces Fatigue with stuffed.");
		}
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 32;
            item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = 4;
            item.accessory = true;
        }   

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>().CasimirusGenesAccessory = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DinoNitrates")); 
            recipe.AddIngredient(mod.ItemType("PhosphateNo1")); 
            recipe.AddIngredient(mod.ItemType("PhosphateNo2")); 
            recipe.SetResult(114); //Tinkerer's Workshop
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}