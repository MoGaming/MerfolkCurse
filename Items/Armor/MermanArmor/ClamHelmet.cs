using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Armor.MermanArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class ClamHelmet : ModItem
    {    
        public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Clam Shell");
			Tooltip.SetDefault("+1 defense while merfolk.\n15% decreased movement speed while human.");
	    }

         public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.rare = 3;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
		{
			if(player.GetModPlayer<MyPlayer>().Merfolkcurse)
			{
				player.statDefense += 1;
			}
			else
			{				
				player.moveSpeed -= 0.15f;
			}
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("MermanChestplate") && legs.type == mod.ItemType("MermanLeggings");  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Imbrace the sea!\nLiquids uneffect your movement.\nGreatly increased max fall speed.\nNo fall damage."; 
            player.maxFallSpeed += 5f; 
			player.ignoreWater = true;  
			player.noFallDmg = true;   
        }

        public override void AddRecipes() 
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Seashell, 10); 
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}