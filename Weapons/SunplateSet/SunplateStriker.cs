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
using MerfolkCurse;
using MerfolkCurse.AirborneDamageClass;

namespace MerfolkCurse.Items.Weapons.SunplateSet
{
	public class SunplateStriker : AirborneDamageItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunplate Striker");
			Tooltip.SetDefault("Shoots Lightning Bolts.");
		}
		public override void SafeSetDefaults()
		{
			item.damage = 23;
			setAirborneDamage(8);
			item.melee = true;
			item.width = 62;
			item.height = 70;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("LightningBolt");
			item.shootSpeed = 9f;
            }
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.GetModPlayer<MyPlayer>().SkyblessedGauntlet && Main.rand.Next(10) == 1)
			{
                Projectile.NewProjectile(position.X, position.Y, speedX + (speedX/2), speedY + (speedY/2), mod.ProjectileType("GaleWind"), damage + (damage/10), knockBack, player.whoAmI);
			}

			return true;
		}

		public override void AddRecipes() //35 sunplate blocks, 15 rain clouds, 60 clouds, and 10 platinum bars
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(19, 10); 
            recipe.AddIngredient(824, 35); 
            recipe.AddIngredient(765, 15); 
            recipe.AddIngredient(751, 60); 
            recipe.AddIngredient(1257, 10); 
            recipe.AddIngredient(320, 5); 
            recipe.AddTile(TileID.SkyMill);   
            recipe.SetResult(this);
            recipe.AddRecipe();

			recipe = new ModRecipe(mod);
            recipe.AddIngredient(706, 10); 
            recipe.AddIngredient(824, 35); 
            recipe.AddIngredient(765, 15); 
            recipe.AddIngredient(751, 60); 
            recipe.AddIngredient(57, 10); 
            recipe.AddIngredient(320, 5); 
            recipe.AddTile(TileID.SkyMill);   
            recipe.SetResult(this);
            recipe.AddRecipe();

			recipe = new ModRecipe(mod);
            recipe.AddIngredient(19, 10); 
            recipe.AddIngredient(824, 35); 
            recipe.AddIngredient(765, 15); 
            recipe.AddIngredient(751, 60); 
            recipe.AddIngredient(1257, 10); 
            recipe.AddIngredient(320, 5); 
            recipe.AddTile(TileID.SkyMill);   
            recipe.SetResult(this);
            recipe.AddRecipe();

			recipe = new ModRecipe(mod);
            recipe.AddIngredient(706, 10); 
            recipe.AddIngredient(824, 35); 
            recipe.AddIngredient(765, 15); 
            recipe.AddIngredient(751, 60);
            recipe.AddIngredient(57, 10);  
            recipe.AddIngredient(320, 5); 
            recipe.AddTile(TileID.SkyMill);   
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}
