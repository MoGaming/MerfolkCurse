using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Consumables.NPCSoul
{
	public class GuideSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Guide Soul");
			Tooltip.SetDefault("Summons a Guide if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.Guide))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Guide);
            	
				return true;
            }
            return false;
        }
    }
	public class CasmirSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Casmir Soul");
			Tooltip.SetDefault("Summons a Casmir if there isn't one.");
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
            if(!NPC.AnyNPCs(mod.NPCType("CasmirTownNPC")))
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("CasmirTownNPC"));
            	
				return true;
            }
            return false;
        }
    }
	public class NurseSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Nurse Soul");
			Tooltip.SetDefault("Summons a Nurse if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.Nurse))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Nurse);
            	
				return true;
            }
            return false;
        }
    }
	public class MerchantSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Merchant Soul");
			Tooltip.SetDefault("Summons a Merchant if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.Merchant))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Merchant);
            	
				return true;
            }
            return false;
        }
    }
	public class PainterSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Painter Soul");
			Tooltip.SetDefault("Summons a Painter if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.Painter))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Painter);
            	
				return true;
            }
            return false;
        }
    }
	public class DyeTraderSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Dye Trader Soul");
			Tooltip.SetDefault("Summons a Dye Trader if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.DyeTrader))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.DyeTrader);
            	
				return true;
            }
            return false;
        }
    }
	public class PartyGirlSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Party Girl Soul");
			Tooltip.SetDefault("Summons a Party Girl if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.PartyGirl))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.PartyGirl);
            	
				return true;
            }
            return false;
        }
    }
	public class AnglerSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Angler Soul");
			Tooltip.SetDefault("Summons a Angler if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.Angler))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Angler);
            	
				return true;
            }
            return false;
        }
    }
	public class StylistSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Stylist Soul");
			Tooltip.SetDefault("Summons a Stylist if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.Stylist))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Stylist);
            	
				return true;
            }
            return false;
        }
    }
	public class DemolitionistSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Demolitionist Soul");
			Tooltip.SetDefault("Summons a Demolitionist if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.Demolitionist))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Demolitionist);
            	
				return true;
            }
            return false;
        }
    }
	public class DryadSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Dryad Soul");
			Tooltip.SetDefault("Summons a Dryad if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.Dryad))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Dryad);
            	
				return true;
            }
            return false;
        }
    }
	public class TavernkeepSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Tavernkeep Soul");
			Tooltip.SetDefault("Summons a Tavernkeep if there isn't one.");
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
            if(!NPC.AnyNPCs(550)) //Tavernkeep
            {
                NPC.SpawnOnPlayer(player.whoAmI, 550);
            	
				return true;
            }
            return false;
        }
    }
	public class ArmsDealerSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Arms Dealer Soul");
			Tooltip.SetDefault("Summons a Arms Dealer if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.ArmsDealer))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.ArmsDealer);
            	
				return true;
            }
            return false;
        }
    }
	public class GoblinTinkererSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Goblin Tinkerer Soul");
			Tooltip.SetDefault("Summons a Goblin Tinkerer if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.GoblinTinkerer))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.GoblinTinkerer);
            	
				return true;
            }
            return false;
        }
    }
	public class WitchDoctorSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Witch Doctor Soul");
			Tooltip.SetDefault("Summons a Witch Doctor if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.WitchDoctor))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.WitchDoctor);
            	
				return true;
            }
            return false;
        }
    }
	public class ClothierSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Clothier Soul");
			Tooltip.SetDefault("Summons a Clothier if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.Clothier))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Clothier);
            	
				return true;
            }
            return false;
        }
    }
	public class MechanicSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Mechanic Soul");
			Tooltip.SetDefault("Summons a Mechanic if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.Mechanic))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Mechanic);
            	
				return true;
            }
            return false;
        }
    }
	public class TaxCollectorSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Tax Collector Soul");
			Tooltip.SetDefault("Summons a Tax Collector if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.TaxCollector))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.TaxCollector);
            	
				return true;
            }
            return false;
        }
    }
	public class PirateSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Pirate Soul");
			Tooltip.SetDefault("Summons a Pirate if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.Pirate))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Pirate);
            	
				return true;
            }
            return false;
        }
    }
	public class TruffleSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Truffle Soul");
			Tooltip.SetDefault("Summons a Truffle if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.Truffle))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Truffle);
            	
				return true;
            }
            return false;
        }
    }
	public class WizardSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Wizard Soul");
			Tooltip.SetDefault("Summons a Wizard if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.Wizard))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Wizard);
            	
				return true;
            }
            return false;
        }
    }
	public class SteampunkerSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Steampunker Soul");
			Tooltip.SetDefault("Summons a Steampunker if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.Steampunker))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Steampunker);
            	
				return true;
            }
            return false;
        }
    }
	public class CyborgSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Cyborg Soul");
			Tooltip.SetDefault("Summons a Cyborg if there isn't one.");
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
            if(!NPC.AnyNPCs(NPCID.Cyborg))
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.Cyborg);
            	
				return true;
            }
            return false;
        }
    }
}