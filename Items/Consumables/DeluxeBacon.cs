//Deluxe Bacon
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Consumables
{
	public class DeluxeBacon : ModItem //add drop from something
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Deluxe Bacon");
			Tooltip.SetDefault("Yummy.\nGives minor improvements to all stats.\nGives Swiftness and Iron Skin for 3 minutes.\nGives Regenartion, ManaRegeneration and Well Fed for 4 minutes.\nCHEAT ONLY ITEM.");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 22;

			item.maxStack = 99;
			item.rare = 1;

			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 2;

			item.value = Item.sellPrice(0, 0, 40, 50);
            item.consumable = true;
            item.potion = true;

			item.healLife = 210;
            item.healMana = 400;
		}

        public override bool UseItem(Player player)
		{
            player.AddBuff(3, 14400);        //sWWIFTNESS,           3 minutes
            player.AddBuff(2, 18000);        //Regenartion,          4 minutes
            player.AddBuff(5, 14400);        //Iron Skin,   	     3 minutes
            player.AddBuff(6, 18000);        //ManaRegeneration,     4 minutes
            player.AddBuff(26, 18000);       //wELLfED,              4 minuntes   

            return true;
        }
    }
}