using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Armor.MermanArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class JellyFishHelmet : ModItem
    {    
        public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Jellyfish Blob");
			Tooltip.SetDefault("15% decreased mana cost while merfolk.\n10% increased mana cost while humand.");
	    }

         public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.rare = 3;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
		{
			if(player.GetModPlayer<MyPlayer>().Merfolkcurse)
			{
				player.manaCost -= 0.15f;
			}
			else
			{				
				player.manaCost += 0.10f;
			}
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("MermanChestplate") && legs.type == mod.ItemType("MermanLeggings");  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Imbrace the sea!\nLiquids uneffect your movement.\n10% increased magic damage.\nNot targeted by all Jellyfish."; 
            player.magicDamage += 0.10f; 
			player.ignoreWater = true;  
			player.npcTypeNoAggro[63] = true;
			player.npcTypeNoAggro[64] = true;
			player.npcTypeNoAggro[103] = true;
			player.npcTypeNoAggro[242] = true;
            //Full set: 17 def, 15% increased mana cost, 10% increase magic damage, +18% movement speed
        }

        public override void AddRecipes() 
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Jelly", 20); 
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}