using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace MerfolkCurse.AirborneDamageClass
{
	public abstract class AirborneDamageItem : ModItem
	{
        public int AirborneDamage;

        public void setAirborneDamage(int NewAirborneDamage) 
        {
            AirborneDamage = NewAirborneDamage;
        }
	    public virtual void SafeSetDefaults() {}
        
        public override bool CloneNewInstances
        {
            get { return true; }
        }
		public sealed override void SetDefaults() {
			SafeSetDefaults();
		}

        public sealed override void GetWeaponDamage(Player player, ref int damage)
        {
            AirborneDamagePlayer p = player.GetModPlayer<AirborneDamagePlayer>();
            AirborneDamage = AirborneDamage * (int)p.airborneDamage;

            if(p.IsAirborne)
            {
                if(player.GetModPlayer<MyPlayer>().Merfolkcurse)
                {
                    damage = damage + (AirborneDamage/2);
                }
                else
                {
                    damage = damage + AirborneDamage;
                }
            }
        }

		public override void GetWeaponKnockback(Player player, ref float knockback) {
            AirborneDamagePlayer p = player.GetModPlayer<AirborneDamagePlayer>();
            if(p.IsAirborne)
            {
                if(player.GetModPlayer<MyPlayer>().Merfolkcurse)
                {
                    knockback = knockback + (AirborneDamagePlayer.ModPlayer(player).airborneKnockback/2);
                }
                else
                {
                    knockback = knockback + AirborneDamagePlayer.ModPlayer(player).airborneKnockback;
                }
            }
		}

		public override void GetWeaponCrit(Player player, ref int crit) {
            AirborneDamagePlayer p = player.GetModPlayer<AirborneDamagePlayer>();
            if(p.IsAirborne)
            {
                if(player.GetModPlayer<MyPlayer>().Merfolkcurse)
                {
                    crit = crit + (AirborneDamagePlayer.ModPlayer(player).airborneCrit/2);
                }
                else
                {
			        crit = crit + AirborneDamagePlayer.ModPlayer(player).airborneCrit;
                }
            }
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            int index = tooltips.IndexOf(tt);
            if (tt != null)
            {
                tooltips.Insert(index + 1, new TooltipLine(mod, "AirborneDamage", "[c/ff3399:" + ((float)AirborneDamage * Main.LocalPlayer.GetModPlayer<AirborneDamagePlayer>().airborneDamage) + " airborne damage bonus]"));
            }
        }
	}
}