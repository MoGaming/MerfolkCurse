using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace MerfolkCurse.ReflectedDamageClass
{
	public abstract class ReflectedDamageItem : ModItem
	{
        public double ReflectedDamage;

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
            ReflectedDamagePlayer p = player.GetModPlayer<ReflectedDamagePlayer>();
            ReflectedDamage = p.Contained * (1 - ((float)player.statLife / player.statLifeMax2));
            if(ReflectedDamage > 0)
            {
                ReflectedDamage = 0;
            }

            damage += (int)(ReflectedDamage * p.reflectedDamage);
        }
        public override bool UseItem(Player player)
        {
            ReflectedDamagePlayer p = player.GetModPlayer<ReflectedDamagePlayer>();
            p.delay++;
            return base.UseItem(player);
        }
        public override void GetWeaponKnockback(Player player, ref float knockback) {
            ReflectedDamagePlayer p = player.GetModPlayer<ReflectedDamagePlayer>();
            knockback += ReflectedDamagePlayer.ModPlayer(player).reflectedKnockback;
        }

		public override void GetWeaponCrit(Player player, ref int crit) {
            ReflectedDamagePlayer p = player.GetModPlayer<ReflectedDamagePlayer>();

            crit += ReflectedDamagePlayer.ModPlayer(player).reflectedCrit;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Get the vanilla damage tooltip
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                string[] splitText = tt.text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                tt.text = damageValue + " reflected " + damageWord;
            }
        }
    }
}