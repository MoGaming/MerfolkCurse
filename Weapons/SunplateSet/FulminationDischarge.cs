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
using MerfolkCurse.AirborneDamageClass;

namespace MerfolkCurse.Items.Weapons.SunplateSet
{
	public class FulminationDischarge : AirborneDamageItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Fulmination Discharge");
			Tooltip.SetDefault("Discharge mana fast as the eye can see.");  //The (English) text shown below your weapon's name
		}

		public override void SafeSetDefaults()
		{
			item.damage = 20;
			setAirborneDamage(10);
			item.magic = true;
			item.mana = 10;
			item.width = 40;
			item.height = 40;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 10;
			item.value = Item.sellPrice(0, 0, 375, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Discharge");
			item.shootSpeed = 8f;       
		}

		public override bool AltFunctionUse(Player player)
        {
			if (player.GetModPlayer<MyPlayer>().fullsunplate)
			{
				return true;
			}
			return false;
        }

		public override float UseTimeMultiplier(Player player)
		{
			if (player.altFunctionUse == 2)
				return 0.5f; 
			return 1f;
		}
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			 if(player.altFunctionUse == 2)
			 {
				Projectile.NewProjectile(position.X, position.Y, speedX - (speedX/6), speedY - (speedY/6), mod.ProjectileType("Discharge") , damage + (damage), ((knockBack * -1) + -5), player.whoAmI);
			    item.mana = 20;
			 }
			 else
			 {
				return true;
			 }
			return false; 
		}
		
		public override void AddRecipes() //25 sunplate blocks, 10 rain clouds, 60 clouds, and 10 platinum bars
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(19, 10); 
            recipe.AddIngredient(824, 25); 
            recipe.AddIngredient(765, 10); 
            recipe.AddIngredient(751, 60); 
            recipe.AddIngredient(1257, 10); 
            recipe.AddIngredient(320, 5); 
            recipe.AddTile(TileID.SkyMill);   
            recipe.SetResult(this);
            recipe.AddRecipe();

			recipe = new ModRecipe(mod);
            recipe.AddIngredient(706, 10); 
            recipe.AddIngredient(824, 25); 
            recipe.AddIngredient(765, 10); 
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

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            int index = tooltips.IndexOf(tt);
            if (tt != null)
            {
				if (Main.LocalPlayer.GetModPlayer<MyPlayer>().fullsunplate)
				{
					tooltips.Insert(index + 2, new TooltipLine(mod, "fullsunplate", "[c/ffff33:" + "Right click to release a discharge of electric mana.]"));
				}
            }
        }
	}
}
