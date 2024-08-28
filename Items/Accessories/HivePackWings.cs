using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Accessories
{
    [AutoloadEquip(EquipType.Wings)]
    public class HivePackWings : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("HivePack+");
			Tooltip.SetDefault("Hive Pack effect.\nWhen in honey gain +5 defence and +30 max health.");
		}
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 32;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = -11;
            item.expert = true;
            item.accessory = true;
        } 

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.strongBees = true;
			player.wingTimeMax = 161;

            if (player.wet && player.honeyWet) 
            {
                player.statDefense += 5;
                player.statLifeMax2 += 30;
            }
        }

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
		ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.525f;
            ascentWhenRising = 0.125f;
            maxCanAscendMultiplier = 0.525f;
			maxAscentMultiplier = 2.27f;
            constantAscend = 0.125f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 6.85f;
			acceleration *= 1.35f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.needHoney = true;
            recipe.AddIngredient(3333); 
            recipe.AddIngredient(ItemID.BeeWings); 
            recipe.AddIngredient(1129); 
            recipe.AddIngredient(2431, 35); 
            recipe.AddTile(TileID.TinkerersWorkbench); 
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}