using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace MerfolkCurse.SubmergedDamageClass
{
	public abstract class SubmergedDamageItem : ModItem
	{
        public int SubmergedDamage;

        public void setSubmergedDamage(int NewSubmergedDamage) 
        {
            SubmergedDamage = NewSubmergedDamage;
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
            SubmergedDamagePlayer p = player.GetModPlayer<SubmergedDamagePlayer>();
            SubmergedDamage = SubmergedDamage * (int)p.submergedDamage;

            if(p.IsWet)
            {
                if(player.GetModPlayer<MyPlayer>().Merfolkcurse)
                {
                    damage = damage + SubmergedDamage;
                }
                else
                {
                    damage = damage + (SubmergedDamage/2);
                }
            }
        }

		public override void GetWeaponKnockback(Player player, ref float knockback) {
            SubmergedDamagePlayer p = player.GetModPlayer<SubmergedDamagePlayer>();
            if(p.IsWet)
            {
                if(player.GetModPlayer<MyPlayer>().Merfolkcurse)
                {
                    knockback = knockback + SubmergedDamagePlayer.ModPlayer(player).submergedKnockback;
                }
                else
                {
                    knockback = knockback + (SubmergedDamagePlayer.ModPlayer(player).submergedKnockback/2);
                }
            }
		}

		public override void GetWeaponCrit(Player player, ref int crit) {
            SubmergedDamagePlayer p = player.GetModPlayer<SubmergedDamagePlayer>();
            if(p.IsWet)
            {
                if(player.GetModPlayer<MyPlayer>().Merfolkcurse)
                {
			        crit = crit + SubmergedDamagePlayer.ModPlayer(player).submergedCrit;
                }
                else
                {
                    crit = crit + (SubmergedDamagePlayer.ModPlayer(player).submergedCrit/2);
                }
            }
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            int index = tooltips.IndexOf(tt);
            if (tt != null)
            {
                tooltips.Insert(index + 1, new TooltipLine(mod, "SubmergedDamage", "[c/1c6def:" + ((float)SubmergedDamage * Main.LocalPlayer.GetModPlayer<SubmergedDamagePlayer>().submergedDamage) + " submerged damage bonus]"));
            }
        }
	}
}