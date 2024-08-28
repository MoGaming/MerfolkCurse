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
    class Box : UIElement
    {
        public Color backgroundColor = Color.Gray;
        private static Texture2D _backgroundTexture;

        public Box()
        {
            if (_backgroundTexture == null)
                _backgroundTexture = ModContent.GetTexture("MerfolkCurse/UI/Box");
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();
            Point point1 = new Point((int)dimensions.X, (int)dimensions.Y);
            int width = (int)Math.Ceiling(dimensions.Width);
            int height = (int)Math.Ceiling(dimensions.Height);
            spriteBatch.Draw(_backgroundTexture, new Rectangle(point1.X, point1.Y, width, height), backgroundColor);
        }
    }
}