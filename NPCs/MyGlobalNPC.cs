using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerfolkCurse.NPCs //make tired debuff not allow shop and awkward to have 20% chance not to allow shop
{
	public class MyGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
		
		//public bool SpreadingMagnesiumFlameDebuff = false;

		public override void ResetEffects(NPC npc)
		{
			//SpreadingMagnesiumFlameDebuff = false;
		}
		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			/*
			if (SpreadingMagnesiumFlameDebuff)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 8;
				if (damage < 4)
				{
					damage = 4;
				}
			}*/
		}
		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			/*
			if (SpreadingMagnesiumFlameDebuff)
			{
				if (Main.rand.Next(4) < 3)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("MagnesiumFlame"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.Next(4) == 0)
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 0.1f, 0.5f, 0.5f);
			}*/
		}
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.TravellingMerchant && Main.rand.NextBool(4))
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Consumables.Humanpotion>());
				nextSlot++;

				/*shop.item[nextSlot].SetDefaults(mod.ItemType<Items.CarKey>());
				shop.item[nextSlot].shopCustomPrice = new int?(2);
				shop.item[nextSlot].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				nextSlot++;

				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.CarKey>());
				shop.item[nextSlot].shopCustomPrice = new int?(3);
				shop.item[nextSlot].shopSpecialCurrency = ExampleMod.FaceCustomCurrencyID;
				nextSlot++;*/
			}
            /*else if (type == NPCID.Wizard && Main.expertMode)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Infinity>());
                nextSlot++;
            }*/
		}
		
		public override void NPCLoot(NPC npc)
        {
			int playerIndex = npc.lastInteraction;
			if (!Main.player[playerIndex].active || Main.player[playerIndex].dead)
			{
				playerIndex = npc.FindClosestPlayer(); // Since lastInteraction might be an invalid player fall back to closest player.
			}
			Player player = Main.player[playerIndex];
            MyPlayer p = player.GetModPlayer<MyPlayer>();

			if (npc.type == 113) //wall of flesh
            {
				if (Main.rand.Next(3) == 1 && p.Merfolkcurse)  
				{
					int newItem = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MerfolkEmblem"));
				}
            }
			if (npc.type == NPCID.DukeFishron)
            {
				if (Main.rand.Next(2) == 1)  
				{
					int newItem = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PiscisScales"), Main.rand.Next(15,30));
				}
            }
			if (npc.type == NPCID.Crab)
            {
				if (Main.rand.Next(2) == 1)  
				{
					int newItem = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CrabClaw"), Main.rand.Next(1,2));
				}

				if (Main.rand.Next(1000) == 1)  
				{
					int newItem = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CrabClawLauncher"), Main.rand.Next(1,2));
				}
            }
			if (npc.type == 65) //shark
            {
				if (Main.rand.Next(2) == 1)  
				{
					int newItem = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PiscisScales"), Main.rand.Next(2,10));
				}
            }
			if (npc.type == 58) //piranha
            {
				if (Main.rand.Next(2) == 1)  
				{
					int newItem = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PiscisScales"), Main.rand.Next(1,3));
				}
            }
			if (npc.type == 55) //goldfish
            {
				if (Main.rand.Next(2) == 1)  
				{
					int newItem = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PiscisScales"), Main.rand.Next(2,5));
				}
            }
			if (npc.type == 230) //walking goldfish
            {
				if (Main.rand.Next(2) == 1)  
				{
					int newItem = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PiscisScales"), Main.rand.Next(1,6));
				}
            }
			if (npc.type == 224) //flying fish
            {
				if (Main.rand.Next(2) == 1)  
				{
					int newItem = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PiscisScales"), Main.rand.Next(2,6));
				}
            }
            if (npc.type == NPCID.PinkJellyfish)
            {
                if (Main.rand.Next(3) == 0)
                {
                    int newItem = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("JellyfishLiquid"));
                    Main.item[newItem].color = new Color(242, 31, 255, 0);
                }
            }
            if (npc.type == NPCID.BlueJellyfish)
            {
                if (Main.rand.Next(3) == 0)
                {
                    int newItem = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("JellyfishLiquid"));
                    Main.item[newItem].color = new Color(25, 25, 255, 0);
                }
            }
            if (npc.type == NPCID.GreenJellyfish)
            {
                if (Main.rand.Next(3) == 0)
                {
                    int newItem = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("JellyfishLiquid"));
                    Main.item[newItem].color = new Color(25, 255, 25, 0);
                }
            }
            if (npc.type == NPCID.BloodJelly)
            {
                if (Main.rand.Next(3) == 0)
                {
                    int newItem = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("JellyfishLiquid"));
                    Main.item[newItem].color = new Color(255, 25, 25, 0);
                }
            }

			//TownNPCDeaths
			if(npc.type == NPCID.Guide)
			{
				if (!MyWorld.guideDead) 
				{
					MyWorld.guideDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.Merchant)
			{
				if (!MyWorld.merchantDead) 
				{
					MyWorld.merchantDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.Nurse)
			{
				if (!MyWorld.nurseDead) 
				{
					MyWorld.nurseDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.DyeTrader)
			{
				if (!MyWorld.dyetraderDead) 
				{
					MyWorld.dyetraderDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.Dryad)
			{
				if (!MyWorld.dryadDead) 
				{
					MyWorld.dryadDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.Demolitionist)
			{
				if (!MyWorld.demolitionistDead) 
				{
					MyWorld.demolitionistDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == 550) //Tavernkeep
			{
				if (!MyWorld.tavernkeepDead) 
				{
					MyWorld.tavernkeepDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.ArmsDealer)
			{
				if (!MyWorld.armsdealerDead) 
				{
					MyWorld.armsdealerDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.Stylist)
			{
				if (!MyWorld.stylistDead) 
				{
					MyWorld.stylistDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.Painter)
			{
				if (!MyWorld.painterDead) 
				{
					MyWorld.painterDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.Angler)
			{
				if (!MyWorld.anglerDead) 
				{
					MyWorld.anglerDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.GoblinTinkerer)
			{
				if (!MyWorld.goblintinkererDead) 
				{
					MyWorld.goblintinkererDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.WitchDoctor)
			{
				if (!MyWorld.witchdoctorDead) 
				{
					MyWorld.witchdoctorDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.Clothier)
			{
				if (!MyWorld.clothierDead) 
				{
					MyWorld.clothierDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.Mechanic)
			{
				if (!MyWorld.mechanicDead) 
				{
					MyWorld.mechanicDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.PartyGirl)
			{
				if (!MyWorld.partygirlDead) 
				{
					MyWorld.partygirlDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.Pirate)
			{
				if (!MyWorld.pirateDead) 
				{
					MyWorld.pirateDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.Wizard)
			{
				if (!MyWorld.wizardDead) 
				{
					MyWorld.wizardDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.Steampunker)
			{
				if (!MyWorld.steampunkerDead) 
				{
					MyWorld.steampunkerDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.Cyborg)
			{
				if (!MyWorld.cyborgDead) 
				{
					MyWorld.cyborgDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.Truffle)
			{
				if (!MyWorld.truffleDead) 
				{
					MyWorld.truffleDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
			if(npc.type == NPCID.TaxCollector)
			{
				if (!MyWorld.taxcollectorDead) 
				{
					MyWorld.taxcollectorDead = true;
					if (Main.netMode == NetmodeID.Server) 
					{
						NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
					}
				}
			}
		}
	}
}