using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace MerfolkCurse.UI
{
	class CooldownUI : UIState
	{
		public Box OutBox;
		public Box Box;
		public UIText Cooldown;
		private static int CurCooldown;
		private static int MaxCooldown;
		public static bool visible = true;

		public override void OnInitialize()
		{ 
			OutBox = new Box();
			OutBox.SetPadding(0);
			OutBox.Left.Set(Main.screenWidth / 2 - 65f, 0f);
			OutBox.Top.Set(Main.screenHeight / 2 - 50f, 0f);
			OutBox.Width.Set(136f, 0f);
			OutBox.Height.Set(30f, 0f); 
			OutBox.backgroundColor = Color.White;

			Box = new Box();
			Box.SetPadding(0);
			Box.Left.Set(3f, 0f);
			Box.Top.Set(3f, 0f);
			Box.Width.Set(130f, 0f);
			Box.Height.Set(24f, 0f); 
			Box.backgroundColor = Color.Orange;
			OutBox.Append(Box);

			OutBox.OnMouseDown += new UIElement.MouseEvent(DragStart);
			OutBox.OnMouseUp += new UIElement.MouseEvent(DragEnd);

			Cooldown = new UIText("Cooldown: null");
			Cooldown.Top.Set(30f / 2 - Cooldown.MinHeight.Pixels / 2, 0f);
			Cooldown.Width.Set(136f, 0f);
			Cooldown.Height.Set(30f, 0f); 
			OutBox.Append(Cooldown);
			Append(OutBox);
		}

		public override void Update(GameTime gameTime)
		{
			if(Main.LocalPlayer.GetModPlayer<MyPlayer>().GlobalSetBonusCooldown == 0)
			{
				Cooldown.SetText(("Cooldown: Ready!"));
			}
			else
			{
				Cooldown.SetText(("Cooldown:" + (Main.LocalPlayer.GetModPlayer<MyPlayer>().GlobalSetBonusCooldown/60) + "/" + Main.LocalPlayer.GetModPlayer<MyPlayer>().GlobalSetBonusCooldown_Max/60));
			}
			Box.Width.Set((float)((double)(Main.LocalPlayer.GetModPlayer<MyPlayer>().GlobalSetBonusCooldown)/(double)(Main.LocalPlayer.GetModPlayer<MyPlayer>().GlobalSetBonusCooldown_Max)) * 130, 0f);            
			Recalculate();
			base.Update(gameTime);
		}

		Vector2 offset;
		public bool dragging = false;
		private void DragStart(UIMouseEvent evt, UIElement listeningElement)
		{
			offset = new Vector2(evt.MousePosition.X - OutBox.Left.Pixels, evt.MousePosition.Y - OutBox.Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			OutBox.Left.Set(end.X - offset.X, 0f);
			OutBox.Top.Set(end.Y - offset.Y, 0f);
			Recalculate();
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (OutBox.ContainsPoint(MousePosition))
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (dragging && visible)
			{
				OutBox.Left.Set(MousePosition.X - offset.X, 0f);
				OutBox.Top.Set(MousePosition.Y - offset.Y, 0f);
				Recalculate();
			}
		}
	}
}
//Cooldown.SetText(("Cooldown:" + MyPlayer.Merfolkcursedeathtime/60 + "/" + MyPlayer.Merfolkcursemaxdeathtime/60));
//Cooldown.Left.Set(60f, 0f); // value might be wrong tinker around with it pls
//Cooldown.Top.Set(5f, 0f); // value might be wrong tinker around with it pls

/*
			Box.Left.Set(Main.screenWidth / 2, 0f);
			Box.Top.Set(Main.screenHeight / 2 - 80, 0f);

*/