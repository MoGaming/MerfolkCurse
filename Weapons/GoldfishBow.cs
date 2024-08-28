using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Weapons
{
	public class GoldfishBow : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Goldfish Bow");
			Tooltip.SetDefault("Converts arrows into goldfish.");
		}

		public override void SetDefaults() {
			item.damage = 15;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(0, 0, 30, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10; 
			item.shootSpeed = 6f;
			item.useAmmo = AmmoID.Arrow;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
			{
					type = mod.ProjectileType("GoldFishProjectile");
			}
			return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(261, 2);  //gold fish
            recipe.AddIngredient(mod.ItemType("PiscisScales"), 14);  
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}