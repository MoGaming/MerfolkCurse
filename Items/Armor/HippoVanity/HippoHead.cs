using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Armor.HippoVanity
{
    [AutoloadEquip(EquipType.Head)]
    public class HippoHead : ModItem
    {    
        public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Hippo Head");
	    }

         public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = 9;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.vanity = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("HippoTorso") && legs.type == mod.ItemType("HippoLegs");  
        }

		public override bool DrawHead() 
        {
			return false;
		}

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You're now apart of the Hippo family."; 
        }
    }
}