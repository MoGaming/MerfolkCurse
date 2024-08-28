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

namespace MerfolkCurse.Projectiles
{
	public class Discharge : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Discharge");   
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 3; 
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;      
		}

		public override void SetDefaults()
		{
			projectile.width = 8;        
			projectile.height = 8;            
			projectile.aiStyle = 1;           
			projectile.friendly = true;       
			projectile.hostile = false;       
			projectile.ranged = false;         
			projectile.penetrate = 25;   
			projectile.timeLeft = 600;       
			projectile.alpha = 80;  
			projectile.light = 0.5f;  
			projectile.ignoreWater = false;    
			projectile.tileCollide = true;    
			projectile.extraUpdates = 1;       
			aiType = ProjectileID.Bullet;         
		}

		public override void AI()
		{
			projectile.direction = (projectile.spriteDirection = ((projectile.velocity.X > 0f) ? -1 : -1));
			projectile.rotation = projectile.velocity.ToRotation();
			int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 57 , projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64 , projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust2].noGravity = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{	
			projectile.damage = (int)(projectile.damage * 0.75f);

			if(projectile.damage <= 0)
			{
				projectile.Kill();
			}
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			projectile.damage = (int)(projectile.damage * 0.75f);

			if(projectile.damage <= 0)
			{
				projectile.Kill();
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			return false;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 57 , projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64 , projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			Main.PlaySound(SoundID.Item25, projectile.position);
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
	}
}