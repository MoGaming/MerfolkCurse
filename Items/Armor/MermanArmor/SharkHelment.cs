using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Armor.MermanArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class SharkHelment : ModItem
    {    
        public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Shark Fincap");
			Tooltip.SetDefault("10% increased melee damage while merfolk.\n15% decreased melee damage while human.");
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
				player.meleeDamage += 0.10f; 
			}
			else
			{				
				player.meleeDamage -= 0.15f; 
			}
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("MermanChestplate") && legs.type == mod.ItemType("MermanLeggings");  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Imbrace the sea!\nLiquids uneffect your movement.\n10% increased melee damage.\nNot targeted by all (non-boss) Sharks."; 
            player.meleeDamage += 0.10f; 
			player.ignoreWater = true;  
			player.npcTypeNoAggro[65] = true;
			player.npcTypeNoAggro[542] = true;
			player.npcTypeNoAggro[543] = true;
			player.npcTypeNoAggro[544] = true;
			player.npcTypeNoAggro[545] = true;
            //Full set: 17 def, +20% melee damage, +18% movement speed
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