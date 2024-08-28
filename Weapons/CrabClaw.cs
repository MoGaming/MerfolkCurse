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

namespace MerfolkCurse.Items.Weapons
{
	internal class CrabClaw : ModItem
	{

		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Throwable Crab Claw");
		}

		public override void SetDefaults() {
			item.shootSpeed = 5f;
			item.damage = 18;
			item.knockBack = 5f;
			item.useStyle = 1;
			item.useAnimation = 17;
			item.useTime = 17;
			item.width = 30;
			item.height = 30;
			item.maxStack = 999;
			item.rare = 1;

			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.ranged = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(0, 0, 0, 5);
			item.shoot = ModContent.ProjectileType<Projectiles.KingCrabClawProjectile>();
            item.ammo = item.type;
		}
	}
}