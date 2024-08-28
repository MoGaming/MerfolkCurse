using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Armor.MermanArmor
{  
    [AutoloadEquip(EquipType.Body)]
    public class MermanChestplate : ModItem
    {
            public override void SetStaticDefaults()
		    {
		    	base.SetStaticDefaults();
			    DisplayName.SetDefault("Scaly BodyCover");
    			Tooltip.SetDefault("10% increased item usetime while merfolk.\n10% decreased item usetime while human.");
		    }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = 3;
            item.value = Item.sellPrice(0, 0, 500, 0);
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
			if(player.GetModPlayer<MyPlayer>().Merfolkcurse)
			{
				player.GetModPlayer<MyPlayer>().ScalyBodyCover = true;
				player.GetModPlayer<MyPlayer>().NotScalyBodyCover = false;
			}
			else
			{				
				player.GetModPlayer<MyPlayer>().NotScalyBodyCover = true;
				player.GetModPlayer<MyPlayer>().ScalyBodyCover = false;
			}
        }

        public override void AddRecipes() 
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PiscisScales", 25); 
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
