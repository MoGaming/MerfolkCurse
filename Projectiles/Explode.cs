using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Projectiles
{
	public class Explode : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explodsion");     //The English name of the projectile
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}

		public override void SetDefaults()
		{
            projectile.damage = 200;
            projectile.knockBack = 10;
			projectile.width = 8;    
			projectile.height = 8;  
			projectile.aiStyle = 1;       
			projectile.friendly = true;  
			projectile.hostile = false;     
			projectile.ranged = true;    
			projectile.penetrate = 4;       
			projectile.timeLeft = 20;
			projectile.alpha = 0; 
			projectile.light = 0.5f;
			projectile.ignoreWater = false;
			projectile.tileCollide = true; 
			projectile.extraUpdates = 1;            
			aiType = ProjectileID.WoodenArrowFriendly;        
		}
        public override void Kill(int timeLeft)
        {
            Player player = Main.player[projectile.owner];
            if(timeLeft != 100)
            {
                projectile.position = projectile.Center;
                projectile.width = (projectile.height = 200); // set the AoE here
                projectile.Center = projectile.position;
                projectile.penetrate = -1;
                projectile.Damage();

                projectile.position = projectile.Center;
                projectile.width = (projectile.height = 22);
                projectile.Center = projectile.position;
                Vector2 pos = projectile.position;
                Main.PlaySound(SoundID.Item15, projectile.position);
                for (int i = 0; i < 30; i++)
                {
                    Dust dust = Dust.NewDustDirect(pos, projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
                    dust.velocity *= 1.4f;
                }
                for (int i = 0; i < 20; i++)
                {
                    Dust dust = Dust.NewDustDirect(pos, projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3.5f);
                    dust.noGravity = true;
                    dust.velocity *= 7f;
                    dust = Dust.NewDustDirect(pos, projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
                    dust.velocity *= 3f;
                }
                for (int i = 0; i < 2; i++)
                {
                    float scaleFactor = 0.4f;
                    if (i == 1)
                        scaleFactor = 0.8f;
                    Gore gore = Gore.NewGoreDirect(pos, default(Vector2), Main.rand.Next(61, 64));
                    gore.velocity = gore.velocity * scaleFactor + Vector2.One;
                    gore = Gore.NewGoreDirect(pos, default(Vector2), Main.rand.Next(61, 64));
                    gore.velocity = gore.velocity * scaleFactor + new Vector2(-1, 1);
                    gore = Gore.NewGoreDirect(pos, default(Vector2), Main.rand.Next(61, 64));
                    gore.velocity = gore.velocity * scaleFactor + new Vector2(1, -1);
                    gore = Gore.NewGoreDirect(pos, default(Vector2), Main.rand.Next(61, 64));
                    gore.velocity = gore.velocity * scaleFactor - Vector2.One;
                }
            }
        }
    }
}