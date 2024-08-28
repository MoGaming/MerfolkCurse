using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using MerfolkCurse.NPCs;
using MerfolkCurse.AirborneDamageClass;
using MerfolkCurse.Items.Accessories.GliderItemClass;

namespace MerfolkCurse.Items.Accessories.GliderItemClass
{
	public class ModGliderPlayer : ModPlayer
	{
		public static ModGliderPlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<ModGliderPlayer>();
		}
		
		public float jumpHeightMultiplier = 1f;
		public float gliderSpeed = 10f;
		public float gliderSpeedAcceleration = 1f;
		
		private void ResetVariables()
		{
			jumpHeightMultiplier = 1f;
			gliderSpeed = 10f;
			gliderSpeedAcceleration = 1f;
		}

		public override void ResetEffects()
		{
			ResetVariables();
		}

		public override void UpdateDead()
		{
			ResetVariables();
		}
		
		public override void PostUpdateEquips()
        {
            int k;
            bool flag = false;
			
            for(k = 3; k < 8 + player.extraAccessorySlots; k++) 
			{
				if(player.armor[k].modItem != null) 
				{
					ModItem item = player.armor[k].modItem;
					if(item.GetType().IsSubclassOf(typeof(ModGlideritem)))
					{
						ModGlideritem glider = (ModGlideritem)item;
						if(glider.isWings) 
						{
							flag = true;
							break;
						}
					}
				}
			}
            if(flag)
            {
                player.jumpSpeedBoost += jumpHeightMultiplier;
            }
        }
	}
}