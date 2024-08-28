using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace MerfolkCurse.SubmergedDamageClass
{
	public class SubmergedDamagePlayer : ModPlayer
	{
		public static SubmergedDamagePlayer ModPlayer(Player player) {
			return player.GetModPlayer<SubmergedDamagePlayer>();
		}

        public bool IsWet = false;
		public float submergedDamage = 1f;
		public float submergedKnockback;
		public int submergedCrit;

		public override void ResetEffects() {
			ResetVariables();
		}

		public override void UpdateDead() {
			ResetVariables();
		}

		private void ResetVariables() {
			submergedDamage = 1f;
			submergedKnockback = 0f;
			submergedCrit = 0;
            IsWet = false;
		}
		public override void PostUpdateMiscEffects()
		{
            if(player.wet)
			{
                IsWet = true;
            }
        }
        
	}
}