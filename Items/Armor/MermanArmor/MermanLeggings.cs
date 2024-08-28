using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Armor.MermanArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class MermanLeggings : ModItem
    {
        public override void SetStaticDefaults()
		    {
		    	base.SetStaticDefaults();
			    DisplayName.SetDefault("Scaly Flippers");
    			Tooltip.SetDefault("18% increased movement speed while a merfolk.\n-1 defense while human.");
		    }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 500, 0);
            item.rare = 3;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
			if(player.GetModPlayer<MyPlayer>().Merfolkcurse)
			{
				player.moveSpeed += 0.18f;
			}
			else
			{				
				player.statDefense -= 1;
			}
        }

        public override void AddRecipes() 
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PiscisScales", 20); 
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}