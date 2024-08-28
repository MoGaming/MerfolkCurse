	using System;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;
	using Terraria;
	using Terraria.GameContent.Generation;
	using Terraria.ID;
	using Terraria.ModLoader;
	using Terraria.Localization;
	using Terraria.ModLoader.IO;
	using Terraria.DataStructures;
	using Terraria.World.Generation;
	using MerfolkCurse.Items;
	//using MerfolkCurse.Tiles;
	//using MerfolkCurse.Items.Placeables;

	namespace MerfolkCurse
	{
		public class MyWorld : ModWorld
		{
			private int PondPositionX = 0;
			private int PondPositionY = 0;

			private static bool generatePond = false;
			
			public static bool guideDead;
			public static bool casmirDead;
			public static bool merchantDead;
			public static bool nurseDead;
			public static bool dyetraderDead;
			public static bool dryadDead;
			public static bool demolitionistDead;
			public static bool tavernkeepDead;
			public static bool armsdealerDead;
			public static bool stylistDead;
			public static bool painterDead;
			public static bool anglerDead;
			public static bool goblintinkererDead;
			public static bool witchdoctorDead;
			public static bool clothierDead;
			public static bool mechanicDead;
			public static bool partygirlDead;
			public static bool pirateDead;
			public static bool wizardDead;
			public static bool steampunkerDead;
			public static bool cyborgDead;
			public static bool truffleDead;
			public static bool taxcollectorDead;
			
			//public static bool LiMgComet = false;

			public override void Initialize()
			{
				//LiMgComet = false;
				generatePond = false;	
				
				guideDead = false;
				casmirDead = false;
			}

			public override TagCompound Save()
			{
				var npcsDead = new List<string>();
				if(guideDead)npcsDead.Add("guide");
				if(casmirDead)npcsDead.Add("casmir");
				if(merchantDead)npcsDead.Add("merchant");
				if(nurseDead)npcsDead.Add("nurse");
				if(dyetraderDead)npcsDead.Add("dyetrader");
				if(dryadDead)npcsDead.Add("dryad");
				if(demolitionistDead)npcsDead.Add("demolitionist");
				if(tavernkeepDead)npcsDead.Add("tavernkeep");
				if(armsdealerDead)npcsDead.Add("armsdealer");
				if(stylistDead)npcsDead.Add("stylist");
				if(painterDead)npcsDead.Add("painter");
				if(anglerDead)npcsDead.Add("angler");
				if(goblintinkererDead)npcsDead.Add("goblintinkerer");
				if(witchdoctorDead)npcsDead.Add("witchdoctor");
				if(clothierDead)npcsDead.Add("clothier");
				if(mechanicDead)npcsDead.Add("mechanic");
				if(partygirlDead)npcsDead.Add("partygirl");
				if(pirateDead)npcsDead.Add("pirate");
				if(wizardDead)npcsDead.Add("wizard");
				if(steampunkerDead)npcsDead.Add("steampunker");
				if(cyborgDead)npcsDead.Add("cyborg");
				if(truffleDead)npcsDead.Add("turffle");
				if(taxcollectorDead)npcsDead.Add("taxcollector");

				/*
				var worldentities = new List<string>();
				if (LiMgComet) 
				{
					worldentities.Add("LiMgComet");
				}*/

				var generated = new BitsByte();
				generated[0] = generatePond;

				return new TagCompound 
				{
					{"npcsDead", npcsDead},
					//{"worldentities", worldentities},
					{"Generated", (byte)generated}
				};
			}

			public override void Load(TagCompound tag)
			{
				var npcsDead = tag.GetList<string>("npcsDead");
				guideDead = npcsDead.Contains("guide");
				casmirDead = npcsDead.Contains("casmir");
				merchantDead = npcsDead.Contains("merchant");
				nurseDead = npcsDead.Contains("nurse");
				dyetraderDead = npcsDead.Contains("dyetrader");
				dryadDead = npcsDead.Contains("dryad");
				demolitionistDead = npcsDead.Contains("demolitionist");
				tavernkeepDead = npcsDead.Contains("tavernkeep");
				armsdealerDead = npcsDead.Contains("armsdealer");
				stylistDead = npcsDead.Contains("stylist");
				painterDead = npcsDead.Contains("painter");
				anglerDead = npcsDead.Contains("angler");
				goblintinkererDead = npcsDead.Contains("goblintinkerer");
				witchdoctorDead = npcsDead.Contains("witchdoctor");
				clothierDead = npcsDead.Contains("clothier");
				mechanicDead = npcsDead.Contains("mechanic");
				partygirlDead = npcsDead.Contains("partygirl");
				pirateDead = npcsDead.Contains("pirate");
				wizardDead = npcsDead.Contains("wizard");
				steampunkerDead = npcsDead.Contains("steampunker");
				cyborgDead = npcsDead.Contains("cyborg");
				truffleDead = npcsDead.Contains("turffle");
				taxcollectorDead = npcsDead.Contains("taxcollector");

				var worldentities = tag.GetList<string>("worldentities");
				//var generated = (BitsByte)tag.GetByte("Generated");
				//LiMgComet = worldentities.Contains("LiMgComet");
			}
			
			public override void NetSend(BinaryWriter writer)
			{
				BitsByte flags = new BitsByte();
				//flags[0] = LiMgComet;
				flags[1] = generatePond;
				flags[2] = guideDead;
				flags[3] = casmirDead;
				flags[4] = guideDead;
				flags[5] = casmirDead;
				flags[6] = merchantDead;
				flags[7] = nurseDead;
				flags[8] = dyetraderDead;
				flags[9] = dryadDead;
				flags[10] = demolitionistDead;
				flags[11] = tavernkeepDead;
				flags[12] = armsdealerDead;
				flags[13] = stylistDead;
				flags[14] = painterDead;
				flags[15] = anglerDead;
				flags[16] = goblintinkererDead;
				flags[17] = witchdoctorDead;
				flags[18] = clothierDead;
				flags[19] = mechanicDead;
				flags[20] = partygirlDead;
				flags[21] = pirateDead;
				flags[22] = wizardDead;
				flags[23] = steampunkerDead;
				flags[24] = cyborgDead;
				flags[25] = truffleDead;
				flags[26] = taxcollectorDead;
				writer.Write(flags);
			}

			public override void NetReceive(BinaryReader reader)
			{
				BitsByte flags = reader.ReadByte();
				//LiMgComet = flags[0];
				generatePond	   = flags[1];
				guideDead		   = flags[2];
				casmirDead 		   = flags[3];
				guideDead 		   = flags[4];
				casmirDead 		   = flags[5];
				merchantDead 	   = flags[6];
				nurseDead 		   = flags[7];
				dyetraderDead 	   = flags[8];
				dryadDead 		   = flags[9];
				demolitionistDead  = flags[10];
				tavernkeepDead	   = flags[11];
				armsdealerDead     = flags[12];
				stylistDead 	   = flags[13];
				painterDead		   = flags[14];
				anglerDead 	 	   = flags[15];
				goblintinkererDead = flags[16];
				witchdoctorDead	   = flags[17];
				clothierDead	   = flags[18];
				mechanicDead 	   = flags[19];
				partygirlDead 	   = flags[20];
				pirateDead 		   = flags[21];
				wizardDead		   = flags[22];
				steampunkerDead    = flags[23];
				cyborgDead 		   = flags[24];
				truffleDead 	   = flags[25];
				taxcollectorDead   = flags[26];
			}

			/*
			public static void DropComet()
			{
				bool flag = true;
				if (Main.netMode == 1)
				{
					return;
				}
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active)
					{
						flag = false;
						break;
					}
				}
				int num = 0;
				float num2 = Main.maxTilesX / 4200;
				int num3 = (int)(400f * num2);
				for (int j = 5; j < Main.maxTilesX - 5; j++)
				{
					int num4 = 5;
					while (num4 < Main.worldSurface)
					{
						if (Main.tile[j, num4].active() && Main.tile[j, num4].type == (ushort)MerfolkCurse.Instance.TileType("LithiumMagnesiumAlloyOreTile"))
						{
							num++;
							if (num > num3)
							{
								return;
							}
						}
						num4++;
					}
				}
				float num5 = 600f;
				while (!flag)
				{
					float num6 = Main.maxTilesX * 0.08f;
					int num7 = Main.rand.Next(150, Main.maxTilesX - 150);
					while (num7 > Main.spawnTileX - num6 && num7 < Main.spawnTileX + num6)
					{
						num7 = Main.rand.Next(150, Main.maxTilesX - 150);
					}
					int k = (int)(Main.worldSurface * 0.3);
					while (k < Main.maxTilesY)
					{
						if (Main.tile[num7, k].active() && Main.tileSolid[Main.tile[num7, k].type])
						{
							int num8 = 0;
							int num9 = 15;
							for (int l = num7 - num9; l < num7 + num9; l++)
							{
								for (int m = k - num9; m < k + num9; m++)
								{
									if (WorldGen.SolidTile(l, m))
									{
										num8++;
										if (Main.tile[l, m].type == 189 || Main.tile[l, m].type == 202)
										{
											num8 -= 100;
										}
									}
									else if (Main.tile[l, m].liquid > 0)
									{
										num8--;
									}
								}
							}
							if (num8 < num5)
							{
								num5 -= 0.5f;
								break;
							}
							flag = Comet(num7, k);
							if (flag)
							{
							}
							break;
						}
						k++;
					}
					if (num5 < 100f)
					{
						return;
					}
				}
			}
			
			public static bool Comet(int i, int j)
			{
				if (i < 50 || i > Main.maxTilesX - 50)
				{
					return false;
				}
				if (j < 50 || j > Main.maxTilesY - 50)
				{
					return false;
				}
				int num = 35;
				Rectangle rectangle = new Rectangle((i - num) * 16, (j - num) * 16, num * 2 * 16, num * 2 * 16);
				for (int k = 0; k < 255; k++)
				{
					if (Main.player[k].active)
					{
						Rectangle value = new Rectangle((int)(Main.player[k].position.X + Main.player[k].width / 2 - NPC.sWidth / 2 - NPC.safeRangeX), (int)(Main.player[k].position.Y + Main.player[k].height / 2 - NPC.sHeight / 2 - NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
						if (rectangle.Intersects(value))
						{
							return false;
						}
					}
				}
				for (int l = 0; l < 200; l++)
				{
					if (Main.npc[l].active)
					{
						Rectangle value2 = new Rectangle((int)Main.npc[l].position.X, (int)Main.npc[l].position.Y, Main.npc[l].width, Main.npc[l].height);
						if (rectangle.Intersects(value2))
						{
							return false;
						}
					}
				}
				for (int m = i - num; m < i + num; m++)
				{
					for (int n = j - num; n < j + num; n++)
					{
						if (Main.tile[m, n].active() && Main.tile[m, n].type == 21)
						{
							return false;
						}
					}
				}
				num = WorldGen.genRand.Next(17, 23);
				for (int num2 = i - num; num2 < i + num; num2++)
				{
					for (int num3 = j - num; num3 < j + num; num3++)
					{
						if (num3 > j + Main.rand.Next(-2, 3) - 5)
						{
							float num4 = Math.Abs(i - num2);
							float num5 = Math.Abs(j - num3);
							float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
							if (num6 < num * 0.9 + Main.rand.Next(-4, 5))
							{
								if (!Main.tileSolid[Main.tile[num2, num3].type])
								{
									Main.tile[num2, num3].active(false);
								}
								Main.tile[num2, num3].type = (ushort)MerfolkCurse.Instance.TileType("LithiumMagnesiumAlloyOreTile");
							}
						}
					}
				}
				num = WorldGen.genRand.Next(8, 14);
				for (int num7 = i - num; num7 < i + num; num7++)
				{
					for (int num8 = j - num; num8 < j + num; num8++)
					{
						if (num8 > j + Main.rand.Next(-2, 3) - 4)
						{
							float num9 = Math.Abs(i - num7);
							float num10 = Math.Abs(j - num8);
							float num11 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
							if (num11 < num * 0.8 + Main.rand.Next(-3, 4))
							{
								Main.tile[num7, num8].active(false);
							}
						}
					}
				}
				num = WorldGen.genRand.Next(25, 35);
				for (int num12 = i - num; num12 < i + num; num12++)
				{
					for (int num13 = j - num; num13 < j + num; num13++)
					{
						float num14 = Math.Abs(i - num12);
						float num15 = Math.Abs(j - num13);
						float num16 = (float)Math.Sqrt(num14 * num14 + num15 * num15);
						if (num16 < num * 0.7)
						{
							if (Main.tile[num12, num13].type == 5 || Main.tile[num12, num13].type == 32 || Main.tile[num12, num13].type == 352)
							{
								WorldGen.KillTile(num12, num13, false, false, false);
							}
							Main.tile[num12, num13].liquid = 0;
						}
						if (Main.tile[num12, num13].type == (ushort)MerfolkCurse.Instance.TileType("LithiumMagnesiumAlloyOreTile"))
						{
							if (!WorldGen.SolidTile(num12 - 1, num13) && !WorldGen.SolidTile(num12 + 1, num13) && !WorldGen.SolidTile(num12, num13 - 1) && !WorldGen.SolidTile(num12, num13 + 1))
							{
								Main.tile[num12, num13].active(false);
							}
							else if ((Main.tile[num12, num13].halfBrick() || Main.tile[num12 - 1, num13].topSlope()) && !WorldGen.SolidTile(num12, num13 + 1))
							{
								Main.tile[num12, num13].active(false);
							}
						}
						WorldGen.SquareTileFrame(num12, num13, true);
						WorldGen.SquareWallFrame(num12, num13, true);
					}
				}
				num = WorldGen.genRand.Next(23, 32);
				for (int num17 = i - num; num17 < i + num; num17++)
				{
					for (int num18 = j - num; num18 < j + num; num18++)
					{
						if (num18 > j + WorldGen.genRand.Next(-3, 4) - 3 && Main.tile[num17, num18].active() && Main.rand.Next(10) == 0)
						{
							float num19 = Math.Abs(i - num17);
							float num20 = Math.Abs(j - num18);
							float num21 = (float)Math.Sqrt(num19 * num19 + num20 * num20);
							if (num21 < num * 0.8)
							{
								if (Main.tile[num17, num18].type == 5 || Main.tile[num17, num18].type == 32 || Main.tile[num17, num18].type == 352)
								{
									WorldGen.KillTile(num17, num18, false, false, false);
								}
								Main.tile[num17, num18].type = (ushort)MerfolkCurse.Instance.TileType("LithiumMagnesiumAlloyOreTile");
								WorldGen.SquareTileFrame(num17, num18, true);
							}
						}
					}
				}
				num = WorldGen.genRand.Next(30, 38);
				for (int num22 = i - num; num22 < i + num; num22++)
				{
					for (int num23 = j - num; num23 < j + num; num23++)
					{
						if (num23 > j + WorldGen.genRand.Next(-2, 3) && Main.tile[num22, num23].active() && Main.rand.Next(20) == 0)
						{
							float num24 = Math.Abs(i - num22);
							float num25 = Math.Abs(j - num23);
							float num26 = (float)Math.Sqrt(num24 * num24 + num25 * num25);
							if (num26 < num * 0.85)
							{
								if (Main.tile[num22, num23].type == 5 || Main.tile[num22, num23].type == 32 || Main.tile[num22, num23].type == 352)
								{
									WorldGen.KillTile(num22, num23, false, false, false);
								}
								Main.tile[num22, num23].type = (ushort)MerfolkCurse.Instance.TileType("LithiumMagnesiumAlloyOreTile");
								WorldGen.SquareTileFrame(num22, num23, true);
							}
						}
					}
				}
				return true;
			}*/	

			public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
			{
				int index = tasks.FindIndex(x => x.Name == "Spawn Point");
				if(index != -1)
				{
					for(int e = 0; e < (Main.rand.Next(3) + 1); e++)
					{
						tasks.Insert(index + (e + 1), new PassLegacy("[Merfolk Curse] Pond", AddPond));
					}
				}
			}

			public void AddPond(GenerationProgress progress = null)
			{
				try
				{
					bool success = do_MakePond(progress);
					if(success)
					{
						generatePond = true;
					}
				} catch(Exception e)
				{
					Main.NewText("An error has happened!");
				}
			}

			private bool do_MakePond(GenerationProgress progress)
			{
				string PondGen = Language.GetTextValue("MerfolkCurse Pond Generation");
				if(progress != null)
				{
					progress.Message = PondGen;
					progress.Set(0.33f);
				}
				List<Point> list = new List<Point>();
				for(int i = Main.maxTilesX / 5; i < Main.maxTilesX / 5 * 4; i++)
				{
					int y = 150 + Main.rand.Next(51);
					while(!WorldGen.SolidOrSlopedTile(i, y + 1))
					{
						y++;
					}
					for(int j = 0; j < 22; j++)
					{
						if(WorldGen.SolidOrSlopedTile(i + j, y + 1) && Main.tile[i + 1, y +j].active() && (Main.tile[i + j, y + 1].type == TileID.Grass || Main.tile[i + j, y + 1].type == TileID.Sand || Main.tile[i + j, y + 1].type == TileID.Mud || Main.tile[i + j, y + 1].type == TileID.SnowBlock) && !(Main.tile[i + j, y + 2].type == TileID.GrayBrick || Main.tile[i + j, y + 2].type == TileID.RedBrick || Main.tile[i + j, y + 2].type == TileID.Mudstone))
						{
							for(int k = 0; k < 26; k++)
							{
								if(!WorldGen.SolidOrSlopedTile(i - 1, y - k) && !WorldGen.SolidOrSlopedTile(i + 8, y - k) && !(Main.tile[i - 1, y - k].type == TileID.GrayBrick || Main.tile[i - 1, y - k].type == TileID.RedBrick || Main.tile[i - 1, y - k].type == TileID.Mudstone) && !(Main.tile[i + 8, y - k].type == TileID.GrayBrick || Main.tile[i + 8, y - k].type == TileID.RedBrick || Main.tile[i + 8, y - k].type == TileID.Mudstone))
								{
									list.Add(new Point(i, y));
								}
							}
						}
					}
				}
				if(list.Count > 0)
				{
					Point point = list[WorldGen.genRand.Next(0, list.Count<Point>())];
					PondPositionX = point.X;
					PondPositionY = point.Y;
					goto GenerateBuild;
				}
				return false;

				GenerateBuild:

				ushort tileType = 0;
				ushort wallType = 0;
				ushort windowWallType = 0;

				int num1 = WorldGen.genRand.Next(3);
				switch(num1)
				{
					case 0:
						tileType = TileID.GrayBrick;
						wallType = WallID.GrayBrick;
						windowWallType = WallID.GreenStainedGlass;
						break;
					case 1:
						tileType = TileID.RedBrick;
						wallType = WallID.RedBrick;
						windowWallType = WallID.RedStainedGlass;
						break;
					default:
						tileType = TileID.Mudstone;
						wallType = WallID.MudstoneBrick;
						windowWallType = WallID.BlueStainedGlass;
						break;
				}

				for (var x = 0; x < PondTiles.GetLength(1); x++)
				{
					for(var y = 0; y < PondTiles.GetLength(0); y++)
					{
						var tile = Framing.GetTileSafely(PondPositionX + x, PondPositionY - y);
						switch(PondTiles[y, x])
						{
							case 0:
								WorldGen.KillTile(x, y);	
								break;
							case 1:
								WorldGen.KillTile(x, y);
								tile.type = tileType;
								tile.active(true);
								break;
							case 2:
								WorldGen.KillTile(x, y);
								tile.liquid = (byte)(155 + Main.rand.Next(101));
								WorldGen.SquareTileFrame(x, y, false);
								break;
						}
						switch(PondWalls[y, x])
						{
							case 0:
								tile.wall = 0;
								break;
							case 1:
								tile.wall = wallType;
								break;
							case 2:
								tile.wall = windowWallType;
								break;
						}
						if(PondSlopes[y, x] == 5)
						{
							tile.halfBrick(true);
						} else
						{
							tile.halfBrick(false);
							tile.slope(PondSlopes[y, x]);
						}
						
					}
				}
				WorldGen.PlaceChest(PondPositionX + 5, PondPositionY - 2, 21, true);
				var chestIndex = Chest.FindChest(PondPositionX + 5, PondPositionY - 3);
				if (chestIndex != -1)
				{
					do_PondLoot(Main.chest[chestIndex].item);
				}
				return true;
			}

			private void do_PondLoot(Item[] ChestInventory)
			{
				if(Main.rand.Next(3) == 1)
				{
					ChestInventory[2].SetDefaults(mod.ItemType("SwimmingMembrane"));
				}
				ChestInventory[0].SetDefaults(ItemID.HealingPotion);
				ChestInventory[0].stack = Main.rand.Next(1, 10);
                if (Main.rand.Next(3) == 1)
                {
                    ChestInventory[1].SetDefaults(ItemID.WaterBucket);
                }
                else
                {
                    ChestInventory[1].SetDefaults(ItemID.EmptyBucket);
                }
			}

			private int[,] PondTiles = new int[,]
			{
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
				{ 0, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
			};

			private int[,] PondWalls = new int[,]
			{
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
				{ 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
			};

			private byte[,] PondSlopes = new byte[,]
			{
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5 },
				{ 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
			};

			public override void PostWorldGen() 
			{
				int num = NPC.NewNPC((Main.spawnTileX + 5) * 16, Main.spawnTileY * 16, mod.NPCType("Casimr the dinosaur"), 0, 0f, 0f, 0f, 0f, 255);
				Main.npc[num].homeTileX = Main.spawnTileX + 5;
				Main.npc[num].homeTileY = Main.spawnTileY;
				Main.npc[num].direction = 1;
				Main.npc[num].homeless = true;
			}
	}
}