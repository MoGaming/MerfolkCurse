using System;
using MerfolkCurse.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MerfolkCurse.NPCs
{
	[AutoloadHead] 
	public class CasmirTownNPC : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "MerfolkCurse/NPCs/CasmirTownNPC";
			}
		}

		public override string[] AltTextures
		{
			get
			{
				return new string[] { "MerfolkCurse/NPCs/CasmirTownNPC_Alt" };
			}
		}

		public override bool UsesPartyHat()
		{
			return false;
		}

		public override bool Autoload(ref string name) {
			name = "Casimirus";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Casimirus");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

        public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override void HitEffect(int hitDirection, double damage) 
		{
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("IceCreamDust")); 
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) 
		{ 
			for (int k = 0; k < 255; k++) {
				Player player = Main.player[k];
				if (!player.active) {
					continue;
				}

				foreach (Item item in player.inventory) {
					if (item.type == 3347) {
						return true;
					}
				}
			}
			return false;
		}

		public override string TownNPCName() {
			switch (WorldGen.genRand.Next(101)) {
				case 1:
					return "Dakota";
				case 2:
					return "Mohammed";
				default:
					return "Casmir";
			}
		}

		public override string GetChat() {
			int guide = NPC.FindFirstNPC(NPCID.Guide);
			if (guide >= 0 && Main.rand.NextBool(4)) {
				return "Can you please tell " + Main.npc[guide].GivenName + " that " + Lang.GetItemNameValue(mod.ItemType("GloubiBoulga")) + " is ready?";
			} 
			switch (Main.rand.Next(10)) {
				case 0:
					return "I'm from the Casimirus family!";
				case 1:
					return "I'll be all your friends!";
				case 2:
					{
						return "Hey, make sure to buy a " + Lang.GetItemNameValue(mod.ItemType("GloubiBoulga")) + ", I made them myself.";
					}
				case 3:
					{
						Main.npcChatCornerItem = mod.ItemType("GloubiBoulga");
						return "You can never have too much GloubiBouga!";
					}
				case 4:
					return "He seems to be whispering in a langugage you've nver heard.";
				case 5:
					return "How about you take out the trash?;That Barney guy is alwas stealing my ideas.";
				case 6:
					return "How could you have my baby cousin as a pet?";
				case 7:
					return "Don't watch my purple discount clone.";
				case 8:
					return "Make sure to check out 'Gameraiders101' on twitch and youtube!";
				default:
					return "Wanna be my friend?";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot) 
		{
			shop.item[nextSlot].SetDefaults(mod.ItemType("GloubiBoulga"));
			nextSlot++;
			if(Main.bloodMoon)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ClownCasmirHead"));
				nextSlot++;
			}
			if(Main.eclipse)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("DinoNitrates"));
				nextSlot++;
			}
			if(Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("CasmirHead"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("CasmirTorso"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("CasmirLegs"));
				nextSlot++;
			}
			else
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("HippoHead"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("HippoTorso"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("HippoLegs"));
				nextSlot++;
			}
			if(MyWorld.casmirDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("CasmirSoul"));
				nextSlot++;
			}
			if(MyWorld.guideDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("GuideSoul"));
				nextSlot++;
			}
			if(MyWorld.merchantDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("MerchantSoul"));
				nextSlot++;
			}
			if(MyWorld.nurseDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("NurseSoul"));
				nextSlot++;
			}
			if(MyWorld.dyetraderDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("DyeTraderSoul"));
				nextSlot++;
			}
			if(MyWorld.dryadDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("DryadSoul"));
				nextSlot++;
			}
			if(MyWorld.demolitionistDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("DemolitionistSoul")); 
				nextSlot++;
			}
			if(MyWorld.tavernkeepDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("TavernkeepSoul"));
				nextSlot++;
			}
			if(MyWorld.armsdealerDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ArmsDealerSoul"));
				nextSlot++;
			}
			if(MyWorld.stylistDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("StylistSoul"));
				nextSlot++;
			}
			if(MyWorld.painterDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("PainterSoul"));
				nextSlot++;
			}
			if(MyWorld.anglerDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("AnglerSoul"));
				nextSlot++;
			}
			if(MyWorld.goblintinkererDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("GoblinTinkererSoul"));
				nextSlot++;
			}
			if(MyWorld.witchdoctorDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("WitchDoctorSoul"));
				nextSlot++;
			}
			if(MyWorld.clothierDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ClothierSoul"));
				nextSlot++;
			}
			if(MyWorld.mechanicDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("MechanicSoul"));
				nextSlot++;
			}
			if(MyWorld.partygirlDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("PartyGirlSoul")); 
				nextSlot++;
			}
			if(MyWorld.pirateDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("PirateSoul")); 
				nextSlot++;
			}
			if(MyWorld.wizardDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("WizardSoul")); 
				nextSlot++;
			}
			if(MyWorld.steampunkerDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("SteampunkerSoul")); 
				nextSlot++;
			}
			if(MyWorld.cyborgDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("CyborgSoul")); 
				nextSlot++;
			}
			if(MyWorld.truffleDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("TruffleSoul")); 
				nextSlot++;
			}
			if(MyWorld.taxcollectorDead)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("TaxCollectorSoul")); 
				nextSlot++;
			}
		}

		public override void NPCLoot() 
		{
			Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Armor.CasmirVanity.CasmirHead>());
			Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Armor.CasmirVanity.CasmirTorso>());
			Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Armor.CasmirVanity.CasmirLegs>());

			if (!MyWorld.casmirDead) 
			{
				MyWorld.casmirDead = true;
				if (Main.netMode == NetmodeID.Server) 
				{
					NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
				}
			}

			if(Main.rand.NextBool(10))
			{
				Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Materials.PhosphateNo1>());
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 40;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 60;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = mod.ProjectileType("Explode"); //do shit
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 4f;
		}
	}
}