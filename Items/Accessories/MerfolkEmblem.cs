using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MerfolkCurse.SubmergedDamageClass;
using MerfolkCurse.AirborneDamageClass;

namespace MerfolkCurse.Items.Accessories
{
    public class MerfolkEmblem : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Merfolk Emblem");
			Tooltip.SetDefault("10% increased all damage while merfolk.\n15% increased movement speed while merfolk.");
		}
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 32;
            item.value = Item.sellPrice(0, 0, 40, 0);
            item.rare = 4;
            item.accessory = true;
        }   

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            SubmergedDamagePlayer p = player.GetModPlayer<SubmergedDamagePlayer>();
            AirborneDamagePlayer p2 = player.GetModPlayer<AirborneDamagePlayer>();
            
            if(player.GetModPlayer<MyPlayer>().Merfolkcurse)
            {
				player.meleeDamage += 0.1f;
				player.thrownDamage += 0.1f;
				player.rangedDamage += 0.1f;
				player.magicDamage += 0.1f;
				player.minionDamage += 01f;
			    player.moveSpeed += 0.15f;
                p.submergedDamage += 0.15f;
                p2.airborneDamage += 0.15f;
            }
        }
    }
}