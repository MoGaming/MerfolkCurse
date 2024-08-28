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

namespace MerfolkCurse.AirborneDamageClass
{
	public class AirborneDamagePlayer : ModPlayer
	{
		public static AirborneDamagePlayer ModPlayer(Player player) {
			return player.GetModPlayer<AirborneDamagePlayer>();
		}

        public bool AtmosphereBuff = false;
        public bool IsAirborne = false;

		public float airborneDamage = 1f;
		public float airborneKnockback;

		public int airborneCrit;

		public override void ResetEffects() {
			ResetVariables();
		}

		public override void UpdateDead() {
			ResetVariables();
		}

		private void ResetVariables() {
			AtmosphereBuff = false;
            IsAirborne = false;

			airborneDamage = 1f;
			airborneKnockback = 0f;

			airborneCrit = 0;
		}
		public override void PostUpdateMiscEffects()
		{
			Point origin = player.Center.ToTileCoordinates();
			Point point;
			
            if(!WorldUtils.Find(origin, Searches.Chain(new Searches.Down(9), new GenCondition[]{   new Conditions.IsSolid()    }), out point) && !WorldUtils.Find(new Point(origin.X + 1, origin.Y) , Searches.Chain(new Searches.Down(9), new GenCondition[]{   new Conditions.IsSolid()    }), out point) && !WorldUtils.Find(new Point(origin.X + 1, origin.Y) , Searches.Chain(new Searches.Down(9), new GenCondition[]{   new Conditions.IsSolid()    }), out point))
			{
                IsAirborne = true;
            }

			if(AtmosphereBuff)
			{
				airborneDamage += .15f;
			}
        }
	}
}