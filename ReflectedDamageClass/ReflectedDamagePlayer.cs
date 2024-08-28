using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MerfolkCurse.ReflectedDamageClass
{
	public class ReflectedDamagePlayer : ModPlayer
	{
		public static ReflectedDamagePlayer ModPlayer(Player player) {
			return player.GetModPlayer<ReflectedDamagePlayer>();
		}

        public float reflectedDamage = 0.1f; //controls the reflect amount, currently at 10%
        public float containedSpeed = 5f; //controls the amount of damage contained loses every second
        public float reflectedKnockback;
        public int reflectedCrit;
        public double Contained = 0;
        public int delay = 0;


        public override void ResetEffects() {
			ResetVariables();
		}

		public override void UpdateDead() {
			ResetVariables();
		}

		private void ResetVariables()
        {
            reflectedDamage = 0.1f;
            containedSpeed = 5f;
            reflectedKnockback = 0f;
            reflectedCrit = 0;

            if(delay > 59)
            {
                if (Contained > 0)
                {
                    Contained -= (1 * (int)containedSpeed);
                }
                else
                {
                    Contained = 0;
                }
                delay = 0;
            }
            else
            {
                delay++;
            }
        }
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            Contained += damage;

            return true;
        }
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            Contained = 0;
        }
    }
}