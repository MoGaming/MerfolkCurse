using System;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.GameInput;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using Terraria.GameContent.UI.Elements;
using Terraria.Graphics.Shaders;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using MerfolkCurse;
using MerfolkCurse.UI;
using MerfolkCurse.Items;

namespace MerfolkCurse
{
	public class MyPlayer : ModPlayer
	{
		public bool Merfolkcurse = true;
		public bool ScalyBodyCover = false;
		public bool NotScalyBodyCover = false;
		public bool GoldFishArchery = false;
		public bool PiranhaMinion = false;
		public bool FishSchool = false;
		//public bool LithiumSetBonus = false;
		//public bool MagnesiumSetBonus = false;
		//public bool MagnesiumBreastplateVelocity = false;
		//public bool SpreadingMagnesiumFlameDebuff = false;
		public bool Fatigue = false;
		public bool Awakened = false;
		public bool Stuffed = false;
		public bool CasimirusGenesAccessory = false;
		public bool UiEnabled = false;
		public bool SkyblessedGauntlet = false;
		public bool fullsunplate = false;
		public bool Merfolkcurseremoval = false;

		public int Merfolkcursedeathtime = 600;
		public int Merfolkcursemaxdeathtime = 600;
		public int FishSchoolTimer = 0;
		public int GlobalSetBonusCooldown = 0;
		public int GlobalSetBonusCooldown_Max = 0;
		
		public override void ResetEffects()
		{
			Merfolkcurse = true;
			ScalyBodyCover = false;
			NotScalyBodyCover = false;
			GoldFishArchery = false;
			PiranhaMinion = false;
			FishSchool = false;
			//LithiumSetBonus = false;
			//MagnesiumSetBonus = false;
			//MagnesiumBreastplateVelocity = false;
			//SpreadingMagnesiumFlameDebuff = false;
			Fatigue = false;
			Awakened = false;
			Stuffed = false;
			CasimirusGenesAccessory = false;
			UiEnabled = false;
			SkyblessedGauntlet = false;
			fullsunplate = false;
			if (FishSchoolTimer > 0)
			{
   				FishSchoolTimer--;
			}
			if (GlobalSetBonusCooldown > 0)
			{
   				GlobalSetBonusCooldown--;
			}
			Merfolkcursemaxdeathtime = 600;
			GlobalSetBonusCooldown_Max = 0;
		}

		public override void UpdateDead()
		{
			Merfolkcurse = true;
			ScalyBodyCover = false;
			NotScalyBodyCover = false;
			GoldFishArchery = false;
			PiranhaMinion = false;
			FishSchool = false;
			//LithiumSetBonus = false;
			//MagnesiumSetBonus = false;
			//MagnesiumBreastplateVelocity = false;
			//SpreadingMagnesiumFlameDebuff = false;
			Fatigue = false;
			Awakened = false;
			Stuffed = false;
			CasimirusGenesAccessory = false;
			UiEnabled = false;
			SkyblessedGauntlet = false;
			fullsunplate = false;
			Merfolkcursedeathtime = 600;
			Merfolkcursemaxdeathtime = 600;
			FishSchoolTimer = 0;
			GlobalSetBonusCooldown = 0;
			GlobalSetBonusCooldown_Max = 0;
		}

		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) 
		{
			ModPacket packet = mod.GetPacket();
			packet.Write(Merfolkcurseremoval);
			packet.Send(toWho, fromWho);
		}
		public override TagCompound Save() 
		{
			return new TagCompound 
			{
				{"Merfolkcurseremoval", Merfolkcurseremoval},
			};
		}
		public override void Load(TagCompound tag) 
		{
			Merfolkcurseremoval = tag.GetBool("Merfolkcurseremoval");
		}
		
		public override void OnEnterWorld(Player player)
		{
			if(DeveloperSteamID64Checker.getInstance().verifyID())
			{
		    	Main.NewText(player.name + " developed 'Mohammed's Additions'", 100, 100, 195);
			}
			
			if(ContributorSteamID64Checker.getInstance().verifyID())
            {
                Main.NewText(player.name + " helped with 'Mohammed's Additions'", 100, 195, 100);
            }
		}
		
		public override void PostUpdateMiscEffects()
		{
			if(Merfolkcurseremoval)
			{
				Merfolkcurse = false;
			}

			if(Merfolkcurse)
			{
                player.accMerman = true;
				player.hideMerman = false;
				player.forceMerman = true;	
					
				if(player.wet || player.gills)
				{
					if(Main.raining)
					{
						Merfolkcursemaxdeathtime += 60;
					}
					
					if(player.armor[0].type == 250 && player.breath == player.breathMax && !player.lavaWet && !player.honeyWet) //refill water bowl
					{
						Merfolkcursemaxdeathtime += 120;
					}	
					
					if(!player.lavaWet && !player.honeyWet) 
					{
						Merfolkcursedeathtime = Merfolkcursemaxdeathtime;
					}
				}
				else
				{
					player.statDefense -= 2;
					Merfolkcursedeathtime--;
					
					if (Merfolkcursedeathtime <= 0)
					{
						player.statLife--;
						if(player.statLife <= 0)
						{
							player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " didn't make it to the water."), 10d, 0, false);
						}
					}
					UiEnabled = true;
				}
			}

			if(Fatigue)
			{
				player.ignoreWater = false;
				player.autoJump = false;
				player.jumpSpeedBoost *= 0.75f;
				player.moveSpeed *= 0.8f;
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
			}

			if(Stuffed)
			{
				player.ignoreWater = false;
				player.autoJump = false;
				player.jumpSpeedBoost *= 0.9f;
				player.moveSpeed *= 0.9f;
			}
			
			if(Awakened)
			{
				if (player.lifeRegen < 0)
				{
					player.lifeRegen = 1;
				}
				if (player.lifeRegenTime < 0)
				{
					player.lifeRegenTime = 1;
				}
			}
		}
		public override void UpdateBadLifeRegen()
		{
			/*
			if(SpreadingMagnesiumFlameDebuff)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 8;
			}*/
		}
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			/*if (SpreadingMagnesiumFlameDebuff)
			{
				target.AddBuff(mod.BuffType("SpreadingMagnesiumFlame"), 200);
			}*/
		}
		public override void OnHitNPCWithProj(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			/*if (SpreadingMagnesiumFlameDebuff)
			{
				target.AddBuff(mod.BuffType("SpreadingMagnesiumFlame"), 200);
			}*/
		}
		public override void OnHitByNPC(NPC npc, int damage, bool crit)
		{
			/*if (SpreadingMagnesiumFlameDebuff)
			{
				npc.AddBuff(mod.BuffType("SpreadingMagnesiumFlame"), 200);
			}*/
		}
        public override void GetWeaponKnockback(Item item, ref float knockback)
        {
            if (SkyblessedGauntlet == true && item.melee == true)
            {
                knockback *= 1.3f;
            }
        }
		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) 
		{
			if(Awakened)
			{
				return false;
			}

            return true;
        }
		public override bool PreKill(double damage,	int hitDirection,bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)		
		{
			if(player.armor[0].type == 250 && player.breath <= 0)
			{
				damageSource = PlayerDeathReason.ByCustomReason(player.name + "'s water polluted.");
			}

			if(Awakened) //does immunity
			{
				return false;
			}

			if(Awakened) //if some mod bypasses immunity
			{
				damageSource = PlayerDeathReason.ByCustomReason(player.name + "'s immortality broke?");
			}

			if(Fatigue)
			{
				switch (Main.rand.Next(2)) 
				{
					case 0:
						damageSource = PlayerDeathReason.ByCustomReason(player.name + " was too tired to keep fighting."); break;
					default:
						damageSource = PlayerDeathReason.ByCustomReason(player.name + " didn't react fast enough."); break;
				}
			}

			if(Stuffed)
			{
				switch (Main.rand.Next(3)) 
				{
					case 0:
						damageSource = PlayerDeathReason.ByCustomReason(player.name + " was too full to react."); break;
					case 1:
						damageSource = PlayerDeathReason.ByCustomReason(player.name + " didn't eat his veggies."); break;
					default:
						damageSource = PlayerDeathReason.ByCustomReason(player.name + " ate too much junk food."); break;
				}
			}

			return true;
		}
		
		public override float UseTimeMultiplier(Item item)
		{
			if(ScalyBodyCover)
			{
				return 1f + 0.1f;
			}
			
			if(NotScalyBodyCover)
			{
				return 1f - 0.1f;
			}
			
			if(Fatigue)
			{
				return 1f - 0.25f;
			}
			return 1f;
		}
		public override void SetupStartInventory(IList<Item> items)
		{
			Item item = new Item();
			item.SetDefaults(mod.ItemType("LoreScroll")); //gills potion
			item.stack = 1;
			items.Add(item);

            Item itemtwo = new Item();
			itemtwo.SetDefaults(mod.ItemType("InfoScroll")); //scroll/info/lore
			itemtwo.stack = 1;
			items.Add(itemtwo);
		}
		
		public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk) {
			if (junk) 
			{
				return;
			}

			if (Merfolkcurse && !Merfolkcurseremoval && questFish == mod.ItemType("FishSchool") && Main.rand.NextBool(10)) 
			{
				caughtType = mod.ItemType("FishSchool");
			}
		}

		public override void ProcessTriggers(TriggersSet triggersSet)
		{

            if (MerfolkCurse.GlobalSetBonusHotKey.JustPressed && GlobalSetBonusCooldown <= 0)
			{ 
				/*if(MagnesiumSetBonus)
				{
					GlobalSetBonusCooldown = 3600;
					player.AddBuff(mod.BuffType("SpreadingMagnesiumFlame"), 1800);
				}
				if(LithiumSetBonus)
				{
					GlobalSetBonusCooldown = 7200;
					Merfolkcursedeathtime = 0;
					Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, mod.ProjectileType("Explode"), (int)(player.statLife*1.5), 0f, player.whoAmI);
				}*/
				//TornadoBootsCoolDown = 120;
				//player.AddBuff(mod.BuffType("TornadoBootsBuff"), 600);
			}
		}
		public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
		{
			/*if (SpreadingMagnesiumFlameDebuff)
			{
				if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)
				{
					int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, mod.DustType("MagnesiumFlame"), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					Main.playerDrawDust.Add(dust);
				}
				r *= 0.1f;
				g *= 0.2f;
				b *= 0.7f;
				fullBright = true;
			}*/
		}
	}
}
