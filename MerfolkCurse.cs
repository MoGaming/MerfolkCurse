using System;
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
	class MerfolkCurse : Mod
	{
		public MerfolkCurse()
		{
		}
		
        public static MerfolkCurse Instance;
        private UserInterface DryUi;
        private UserInterface CoolUi;
            
        internal DrynessUI MosUberNotSoSexyUI;
        internal CooldownUI MosUberNotSoSexyUI2;
        public static ModHotKey GlobalSetBonusHotKey;

        public override void Load()
        {
            Instance = this;
            if (!Main.dedServ)
            {
                GlobalSetBonusHotKey = RegisterHotKey("Set Bonus Hotkey", "R");
                
                MosUberNotSoSexyUI = new DrynessUI();
                MosUberNotSoSexyUI.Activate();
                DryUi = new UserInterface();
                DryUi.SetState(MosUberNotSoSexyUI);
                
                MosUberNotSoSexyUI2 = new CooldownUI();
                MosUberNotSoSexyUI2.Activate();
                CoolUi = new UserInterface();
                CoolUi.SetState(MosUberNotSoSexyUI2);
            }
        }
        
        public override void Unload()
        {
            Instance = null;
            GlobalSetBonusHotKey = null;
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (DryUi != null && DrynessUI.visible)
                DryUi.Update(gameTime);
            
            if (CoolUi != null && CooldownUI.visible)
                CoolUi.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            MyPlayer player;
            if(Main.netMode == 1) {
                player = Main.player[Main.myPlayer].GetModPlayer<MyPlayer>();
            } else {
                player = Main.LocalPlayer.GetModPlayer<MyPlayer>();
            }
            Mod mod = ModLoader.GetMod("MerfolkCurse");
            int MouseTextIndex0 = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Hide UI Toggle"));
            if (MouseTextIndex0 != -1)
            {
                layers.Insert(MouseTextIndex0, new LegacyGameInterfaceLayer(
                    "MerfolkCurse: DrynessOfMyBigPlayer",
                    delegate
                    {
                        if (player.UiEnabled)
                        {
                            if (DrynessUI.visible)
                            {
                                MosUberNotSoSexyUI.Draw(Main.spriteBatch);
                            }
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );

                layers.Insert(MouseTextIndex0, new LegacyGameInterfaceLayer(
                    "MerfolkCurse: CooldownOfMyBigPlayer",
                    delegate
                    {
                        if (player.GlobalSetBonusCooldown_Max != 0)
                        {
                            if (CooldownUI.visible)
                            {
                                MosUberNotSoSexyUI2.Draw(Main.spriteBatch);
                            }
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
	}
}
