using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using MerfolkCurse;
using MerfolkCurse.SubmergedDamageClass;

namespace MerfolkCurse.Items.Weapons
{
    public class PiranhaStaff : SubmergedDamageItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Piranha Staff");
			Tooltip.SetDefault("Summons uncontrollable Friendly Piranhas."
			+				   "Piranhas will follow you once out of water.");
			Item.staff[item.type] = true;
		}
 
		public override void SafeSetDefaults()
        {
			item.damage = 12;
            setSubmergedDamage(10);
			item.noMelee = true;
			item.summon = true;
			item.mana = 12;
            item.rare = 1; 
			item.width = 28;
			item.height = 30;
			item.useTime = 22;
			item.UseSound = SoundID.Item44;
			item.useStyle = 1;
			item.useAnimation = 22;
			item.knockBack = 3f;
            item.shoot = mod.ProjectileType("PiranhaMinion");   //This defines what type of projectile this weapon will shot
            item.summon = true;    //This defines if it does Summon damage and if its effected by Summon increasing Armor/Accessories.
            item.buffType = mod.BuffType("PiranhaBuff");	//The buff added to player after used the item
			item.buffTime = 3600;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(331, 4);  //Jungle_Spores
            recipe.AddIngredient(620, 8);  //Rich_Mahogany
            recipe.AddIngredient(mod.ItemType("PiscisScales"), 8);  
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
    }
}