using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Consumables
{
	public class GloubiBoulga : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Gloubi-Boulga");
			Tooltip.SetDefault("Only Casimirus can eat it cause it has no nutritional value.\nGrants immortality but at what cost?");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 22;

			item.maxStack = 99;
			item.rare = 2;

			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 2;

			item.value = Item.sellPrice(0, 1, 0, 0);
            item.consumable = true;
		}
        
		public override bool UseItem(Player player)
		{
			
			if(player.GetModPlayer<MyPlayer>().CasimirusGenesAccessory == true)
			{
				if(player.FindBuffIndex(mod.BuffType("Stuffed")) == -1)
				{
					player.AddBuff(mod.BuffType("Awakened"), 1810);
					player.AddBuff(mod.BuffType("Stuffed"), 7200);
				}
				else
				{
					return false;
				}
			}
			else
			{
				if(player.FindBuffIndex(mod.BuffType("Awakened")) == -1)
				{
					if(player.FindBuffIndex(mod.BuffType("Fatigue")) == -1)
					{
						player.AddBuff(mod.BuffType("Awakened"), 1810); //extra 10ticks for removal
					}
					else
					{
						player.AddBuff(mod.BuffType("Fatigue"), 3600);
					}
				}
				else
				{
					player.ClearBuff(mod.BuffType("Awakened"));
					player.AddBuff(mod.BuffType("Fatigue"), 3600);
				}
			}

			return true;
        }
    }
}