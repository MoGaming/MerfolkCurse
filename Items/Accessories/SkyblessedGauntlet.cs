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
    public class SkyblessedGauntlet : ModItem //player.GetModPlayer<MyPlayer>(mod).SkyblessedGauntlet
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skyblessed Gaunlet");
			Tooltip.SetDefault("Sunplate striker projectile retains 5% more damage when piercing.\nSunplate striker(s) has a chance to fire a gale wind.\n10% Increased Melee Speed.\n7% Increased Melee Critical Strike Chance.\n30% Increased Melee Knockback.\nGale wind a faster holy lightning and does 10% more than the base damage of the sword.");
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
            player.meleeSpeed += 0.1f;
            player.meleeCrit += 7;
            player.GetModPlayer<MyPlayer>().SkyblessedGauntlet = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Feather, 5);
            recipe.AddIngredient(ItemID.RainCloud, 5);
            recipe.AddIngredient(ItemID.SunplateBlock, 10);
            recipe.AddIngredient(ItemID.Cloud, 30);
            recipe.AddTile(TileID.SkyMill);   
            recipe.SetResult(this);
            recipe.AddRecipe();
        }   
    }
}