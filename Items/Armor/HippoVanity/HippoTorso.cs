using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Armor.HippoVanity
{
    [AutoloadEquip(EquipType.Body)]
    public class HippoTorso : ModItem
    {
        public override void SetStaticDefaults()
		{
	    	base.SetStaticDefaults();
		    DisplayName.SetDefault("Hippo Torso");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = 9;
			item.value = Item.sellPrice(0, 1, 0, 0);
            item.vanity = true;
        }

		public override bool DrawBody()
        {
			return false;
		}
    }
}