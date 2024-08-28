using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Projectiles.Summoner
{
    public class PiranhaMinion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Friendly Piranha");
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}
		public override void SetDefaults()
		{
            projectile.width = 20; //Set the hitbox width
            projectile.height = 24;   //Set the hitbox height
            projectile.hostile = false;    //tells the game if is hostile or not.
            projectile.friendly = true;   //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.ignoreWater = false;    //Tells the game whether or not projectile will be affected by water
            Main.projFrames[projectile.type] = 1;  //this is where you add how many frames u'r projectile has to make the animation
            projectile.knockBack = 10f;
            projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed  -1 is infinity
            projectile.tileCollide = true; //Tells the game whether or not it can collide with tiles/ terrain
			projectile.minion = true;
			projectile.minionSlots = 0.75f;
		}
        public float swimSpeed=8;
        public float swimDirection;
        public bool runOnce = true;
        public float actDirection;
        public int f=1;
        public float wiggle;
        public float wiggleTime;
        public float maxDistance = 750f;
        public NPC prey;
        float distanceFromPlayer;
        public override void AI()
		{
            Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();

            distanceFromPlayer = (player.Center - projectile.Center).Length();

            if (modPlayer.PiranhaMinion)
            {
                projectile.timeLeft = 2;
            }

            if(runOnce)
            {
                
                actDirection = projectile.velocity.ToRotation();
                projectile.velocity /= 5;
                runOnce = false;
            }
           
            
            if (projectile.wet)
            {
                
                if(MoMethods.ClosestNPC(ref prey, maxDistance, projectile.Center))
                {
                    swimDirection = (projectile.Center - prey.Center).ToRotation() - (float)Math.PI;
                }
                else
                {
                    swimDirection = (projectile.Center - player.Center).ToRotation() - (float)Math.PI;
                }

                actDirection = MoMethods.SlowRotation(actDirection, swimDirection, 4);
                projectile.velocity.X = (float)Math.Cos(actDirection) * swimSpeed;
                projectile.velocity.Y = (float)Math.Sin(actDirection) * swimSpeed;
                projectile.rotation = actDirection + (float)Math.PI / 2;
                actDirection = projectile.velocity.ToRotation();
                
            }
            else
            {
                swimDirection = (projectile.Center - player.Center).ToRotation() - (float)Math.PI;
                actDirection = MoMethods.SlowRotation(actDirection, swimDirection, 4);
                projectile.velocity.X = (float)Math.Cos(actDirection) * swimSpeed;
                projectile.velocity.Y = (float)Math.Sin(actDirection) * swimSpeed;
                projectile.rotation = actDirection + (float)Math.PI / 2;
                actDirection = projectile.velocity.ToRotation();
            }
            
            for (int k = 0; k < 1000; k++)
            {
                if (Main.projectile[k].type == projectile.type && k != projectile.whoAmI)
                {
                    if (Collision.CheckAABBvAABBCollision(projectile.position + new Vector2(projectile.width / 4, projectile.height / 4), new Vector2(projectile.width / 2, projectile.height / 2), Main.projectile[k].position + new Vector2(Main.projectile[k].width / 4, Main.projectile[k].height / 4), new Vector2(Main.projectile[k].width / 2, Main.projectile[k].height / 2))) 
                    {
                        projectile.velocity += new Vector2((float)Math.Cos((projectile.Center - Main.projectile[k].Center).ToRotation()) * .25f, (float)Math.Sin((projectile.Center - Main.projectile[k].Center).ToRotation()) * .1f);
                    }
                }
            }
            if (distanceFromPlayer > maxDistance)
            {
                projectile.position = player.position;
            }
            projectile.spriteDirection = projectile.direction;
        }

        
		public override bool OnTileCollide(Vector2 oldVelocity) {

			if (projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f) {
				projectile.velocity.X = oldVelocity.X * -1f;
			}
			if (projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f) {
				projectile.velocity.Y = oldVelocity.Y * -1f;
			}
			return false;
		}
        public override void Kill(int timeLeft)
        {

		}
       

    }
	
}