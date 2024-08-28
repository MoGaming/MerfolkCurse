using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Armor.MermanArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class PiranhaHelment : ModItem
    {    
        public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Piranha Skull");
			Tooltip.SetDefault("+1 minion slot while merfolk.\n15% decreased summoner damage while human.");
	    }

         public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.rare = 3;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
		{
			if(player.GetModPlayer<MyPlayer>().Merfolkcurse)
			{
				player.maxMinions += 1;
			}
			else
			{				
				player.minionDamage -= 0.15f; 
			}
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("MermanChestplate") && legs.type == mod.ItemType("MermanLeggings");  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Imbrace the sea!\nLiquids uneffect your movement.\n10% increased summoner damage.\nNot targeted by all Piranhas."; 
            player.minionDamage += 0.10f; 
			player.ignoreWater = true;  
			player.npcTypeNoAggro[58] = true;
            //Full set: 17 def, +30% minion damage, +18% movement speed
        }

        public override void AddRecipes() 
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PiscisScales", 18); 
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}