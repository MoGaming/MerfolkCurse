using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using MerfolkCurse.Items.Accessories.GliderItemClass;

namespace MerfolkCurse.Items.Armor.SunplateArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class sunplateheadgear : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Sunplate Headgear");
            Tooltip.SetDefault("20% Increased glider acceleration.\n+10 mana.");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 1;
            item.defense = 3;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 10;
			ModGliderPlayer.ModPlayer(player).gliderSpeedAcceleration += 0.2f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("sunplatechestplate") && legs.type == mod.ItemType("sunplateleggings");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Right click granted to 'Fulmination Discharge'.\n10% increased magic damage.";
            player.GetModPlayer<MyPlayer>().fullsunplate = true;
            player.magicDamage += 0.10f;
        }
		
		public override void AddRecipes() //25 sunplate blocks, 10 rain clouds, 60 clouds, and 10 platinum bars
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(19, 10); 
            recipe.AddIngredient(824, 25); 
            recipe.AddIngredient(765, 8); 
            recipe.AddIngredient(751, 60); 
            recipe.AddIngredient(1257, 10); 
            recipe.AddIngredient(320, 5); 
            recipe.AddTile(TileID.SkyMill);   
            recipe.SetResult(this);
            recipe.AddRecipe();

			recipe = new ModRecipe(mod);
            recipe.AddIngredient(706, 10); 
            recipe.AddIngredient(824, 25); 
            recipe.AddIngredient(765, 8); 
            recipe.AddIngredient(751, 60); 
            recipe.AddIngredient(57, 10); 
            recipe.AddIngredient(320, 5); 
            recipe.AddTile(TileID.SkyMill);   
            recipe.SetResult(this);
            recipe.AddRecipe();

			recipe = new ModRecipe(mod);
            recipe.AddIngredient(19, 10); 
            recipe.AddIngredient(824, 25); 
            recipe.AddIngredient(765, 8); 
            recipe.AddIngredient(751, 60); 
            recipe.AddIngredient(1257, 10); 
            recipe.AddIngredient(320, 5); 
            recipe.AddTile(TileID.SkyMill);   
            recipe.SetResult(this);
            recipe.AddRecipe();

			recipe = new ModRecipe(mod);
            recipe.AddIngredient(706, 10); 
            recipe.AddIngredient(824, 25); 
            recipe.AddIngredient(765, 8); 
            recipe.AddIngredient(751, 60);
            recipe.AddIngredient(57, 10);  
            recipe.AddIngredient(320, 5); 
            recipe.AddTile(TileID.SkyMill);   
            recipe.SetResult(this);
            recipe.AddRecipe();
		}


    }

    public class sunplateheadgearGlowmask : ModPlayer
    {
        public static readonly PlayerLayer SunplateGlow = new PlayerLayer("MerfolkCurse", "SunplateGlow", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("MerfolkCurse");

            if (drawInfo.shadow != 0f)
            {
                return;
            }
            else
            {
                if (drawPlayer.FindBuffIndex(BuffID.Shine) == -1)
                {
                    Lighting.AddLight(drawPlayer.position, 236/510f, 217/510f, 118/510f); //Lighting.AddLight(player.position, 2, 195, 2);
                }
            }
            
            //ExamplePlayer modPlayer = drawPlayer.GetModPlayer<ExamplePlayer>(mod);
            if (drawPlayer.head == mod.GetEquipSlot("sunplateheadgear", EquipType.Head) && drawPlayer.GetModPlayer<MyPlayer>().fullsunplate)
            {
                //Main.NewText("Helmet!");
                //Main.NewText(drawPlayer.bodyFrame);
                Texture2D texture = mod.GetTexture("Items/Armor/SunplateArmor/sunplateheadgear_Glow");
                int drawX = (int)(drawPlayer.position.X - Main.screenPosition.X);
                int drawY = (int)(drawPlayer.position.Y - Main.screenPosition.Y);
                Vector2 Position = drawInfo.position;
                Vector2 origin = new Vector2((float)drawPlayer.legFrame.Width * 0.5f, (float)drawPlayer.legFrame.Height * 0.5f);
                Vector2 pos = new Vector2((float)((int)(Position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(Position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2));
                //pos.Y -= drawPlayer.mount.PlayerOffset;
                DrawData data = new DrawData(texture, pos, drawPlayer.bodyFrame, Color.White, 0f, origin, 1f, drawInfo.spriteEffects, 0);
                data.shader = drawInfo.headArmorShader;
                Main.playerDrawData.Add(data);
            }
        });
        public static readonly PlayerLayer SunplateUnderHelm = new PlayerLayer("MerfolkCurse", "SunplateUnderHelm", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("MerfolkCurse");
            
            //ExamplePlayer modPlayer = drawPlayer.GetModPlayer<ExamplePlayer>(mod);
            if (drawPlayer.head == mod.GetEquipSlot("sunplateheadgear", EquipType.Head))
            {
                //Main.NewText("Helmet!");
                //Main.NewText(drawPlayer.bodyFrame);
                Texture2D texture = mod.GetTexture("Items/Armor/SunplateArmor/sunplateheadgear_UnderHead");
                Color color12 = drawPlayer.GetImmuneAlphaPure(Lighting.GetColor((int)((double)drawInfo.position.X + (double)drawPlayer.width * 0.5) / 16, (int)((double)drawInfo.position.Y + (double)drawPlayer.height * 0.5) / 16, Microsoft.Xna.Framework.Color.White), 0f);
                int drawX = (int)(drawPlayer.position.X - Main.screenPosition.X);
                int drawY = (int)(drawPlayer.position.Y - Main.screenPosition.Y);
                Vector2 Position = drawInfo.position;
                Vector2 origin = new Vector2((float)drawPlayer.legFrame.Width * 0.5f, (float)drawPlayer.legFrame.Height * 0.5f);
                Vector2 pos = new Vector2((float)((int)(Position.X - Main.screenPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2))), (float)((int)(Position.Y - Main.screenPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 4f))) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2));
                //pos.Y -= drawPlayer.mount.PlayerOffset;
                DrawData data = new DrawData(texture, pos, drawPlayer.bodyFrame, color12, 0f, origin, 1f, drawInfo.spriteEffects, 0);
                data.shader = drawInfo.headArmorShader;
                Main.playerDrawData.Add(data);
            }
        });
        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            int headLayer = layers.FindIndex(PlayerLayer => PlayerLayer.Name.Equals("Face"));
            if (headLayer != -1)
            {
                
                SunplateUnderHelm.visible = true;
                layers.Insert(headLayer + 1, SunplateUnderHelm);
                SunplateGlow.visible = true;
                layers.Insert(headLayer + 2, SunplateGlow);
            }

        }
    }
}