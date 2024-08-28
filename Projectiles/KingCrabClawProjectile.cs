using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Projectiles
{
	public class KingCrabClawProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("King Crab Claw");    
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;   
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;  
		}

		public override void SetDefaults()
		{
			projectile.width = 5;     
			projectile.height = 5;              
			projectile.aiStyle = 1;             
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ranged = true; 
			projectile.penetrate = 5;     
			projectile.timeLeft = 720;      
			projectile.alpha = 0;     
			projectile.light = 0.5f;            
			projectile.ignoreWater = false;        
			projectile.tileCollide = true;         
			projectile.extraUpdates = 1;           
			aiType = ProjectileID.Bullet;          
		}
 
		public override void PostAI()
		{
			projectile.ai[1] += 1.25f;
		}
		public override void AI()
		{
			projectile.direction = (projectile.spriteDirection = ((projectile.velocity.X > 0f) ? 1 : 1));
			if(projectile.wet)
			{
				projectile.scale = 1.5f + (float)(Math.Sin(projectile.ai[1]));
			}
			else
			{
				projectile.scale = 1.25f;
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			projectile.Kill();
			return false;
		}
	}
}