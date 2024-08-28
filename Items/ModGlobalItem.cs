using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using MerfolkCurse.NPCs;
using MerfolkCurse;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace MerfolkCurse.Items
{
    public class ModGlobalItem : GlobalItem
	{
        public override bool InstancePerEntity
        {
            get { return true; }
        }

        public override void SetDefaults(Item item)
        {
            ItemID.Sets.ExtractinatorMode[751] = 108; //Cloud
			ItemID.Sets.ExtractinatorMode[765] = 108; //Rain Cloud
			ItemID.Sets.ExtractinatorMode[3756] = 108; //Snow Cloud

			ItemID.Sets.ExtractinatorMode[172] = 172; //Ash
        }

		public override void PickAmmo(Item item, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
            /*
            if(player.GetModPlayer<MyPlayer>(mod).MagnesiumBreastplateVelocity)
            {
				speed += 0.15f;
            }*/

			if(player.GetModPlayer<MyPlayer>().GoldFishArchery /*&& item.useAmmo == AmmoID.Arrow*/)
			{
				speed += 0.25f;
			}
		}

        public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
        {
            if (extractType == 108 && Main.rand.NextBool(4))
            {
                resultStack = 1;
                resultType = mod.ItemType("SunplateShard");
            }
            
            if (extractType == 172)
            {
                resultStack = 1;
                resultType = mod.ItemType("MeteoriteDust");
            }
            
			if (extractType == 3347 && Main.rand.NextBool(50))
            {
                resultStack = 1;
                resultType = mod.ItemType("PhosphateNo2");
            }
        }
    }
}