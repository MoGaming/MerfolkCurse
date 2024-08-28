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
	class DrynessUI : UIState
	{
		public Box OutBreathBox;
		public Box BreathBox;
		public UIText Breath;
		private static int CurBreath;
		private static int MaxBreath;
		public static bool visible = true;

		public override void OnInitialize()
		{ 
			OutBreathBox = new Box();
			OutBreathBox.SetPadding(0);
			OutBreathBox.Left.Set(Main.screenWidth / 2 - 65f, 0f);
			OutBreathBox.Top.Set(Main.screenHeight / 2 - 70f, 0f);
			OutBreathBox.Width.Set(106f, 0f);
			OutBreathBox.Height.Set(30f, 0f); 
			OutBreathBox.backgroundColor = Color.White;

			BreathBox = new Box();
			BreathBox.SetPadding(0);
			BreathBox.Left.Set(3f, 0f);
			BreathBox.Top.Set(3f, 0f);
			BreathBox.Width.Set(100f, 0f);
			BreathBox.Height.Set(24f, 0f); 
			BreathBox.backgroundColor = Color.Aqua;
			OutBreathBox.Append(BreathBox);

			OutBreathBox.OnMouseDown += new UIElement.MouseEvent(DragStart);
			OutBreathBox.OnMouseUp += new UIElement.MouseEvent(DragEnd);

			Breath = new UIText("Breath: null");
			Breath.Top.Set(30f / 2 - Breath.MinHeight.Pixels / 2, 0f);
			Breath.Width.Set(106f, 0f);
			Breath.Height.Set(30f, 0f); 
			OutBreathBox.Append(Breath);
			Append(OutBreathBox);
		}

		public override void Update(GameTime gameTime)
		{
			Breath.SetText(("Breath:" + (Main.LocalPlayer.GetModPlayer<MyPlayer>().Merfolkcursedeathtime/60 + 1) + "/" + Main.LocalPlayer.GetModPlayer<MyPlayer>().Merfolkcursemaxdeathtime/60));
			BreathBox.Width.Set((float)((double)(Main.LocalPlayer.GetModPlayer<MyPlayer>().Merfolkcursedeathtime)/(double)(Main.LocalPlayer.GetModPlayer<MyPlayer>().Merfolkcursemaxdeathtime)) * 100, 0f);            
			Recalculate();
			base.Update(gameTime);
		}

		Vector2 offset;
		public bool dragging = false;
		private void DragStart(UIMouseEvent evt, UIElement listeningElement)
		{
			offset = new Vector2(evt.MousePosition.X - OutBreathBox.Left.Pixels, evt.MousePosition.Y - OutBreathBox.Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			OutBreathBox.Left.Set(end.X - offset.X, 0f);
			OutBreathBox.Top.Set(end.Y - offset.Y, 0f);
			Recalculate();
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
			if (OutBreathBox.ContainsPoint(MousePosition))
			{
				Main.LocalPlayer.mouseInterface = true;
			}
			if (dragging && visible)
			{
				OutBreathBox.Left.Set(MousePosition.X - offset.X, 0f);
				OutBreathBox.Top.Set(MousePosition.Y - offset.Y, 0f);
				Recalculate();
			}
		}
	}
}
//Breath.SetText(("Breath:" + MyPlayer.Merfolkcursedeathtime/60 + "/" + MyPlayer.Merfolkcursemaxdeathtime/60));
//Breath.Left.Set(60f, 0f); // value might be wrong tinker around with it pls
//Breath.Top.Set(5f, 0f); // value might be wrong tinker around with it pls

/*
			BreathBox.Left.Set(Main.screenWidth / 2, 0f);
			BreathBox.Top.Set(Main.screenHeight / 2 - 80, 0f);

*/