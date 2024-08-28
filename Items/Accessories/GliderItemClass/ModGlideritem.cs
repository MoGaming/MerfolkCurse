using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace MerfolkCurse.Items.Accessories.GliderItemClass
{
	public abstract class ModGlideritem : ModItem
	{
	    //public virtual void SafeSetDefaults() {}

	    public override bool CloneNewInstances
        {
            get { return true; }
        }
		
        public float setJumpHeightMultiplier;
        public float setGliderSpeed;
        public float setGliderSpeedAcceleration;
		
        public bool isWings;
		
        public void setGlider(float NewJumpHeightMultiplier, float NewGliderSpeed, float NewGliderSpeedAcceleration, bool NewIsWings) 
        {
            setJumpHeightMultiplier = NewJumpHeightMultiplier;
            setGliderSpeed = NewGliderSpeed;
            NewGliderSpeedAcceleration = setGliderSpeedAcceleration;
			isWings = NewIsWings;
        }

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if(isWings)
			{
				player.wingTimeMax = 0;
			}
			player.GetModPlayer<ModGliderPlayer>().jumpHeightMultiplier += setJumpHeightMultiplier;
			player.GetModPlayer<ModGliderPlayer>().gliderSpeed += setGliderSpeed;
			player.GetModPlayer<ModGliderPlayer>().gliderSpeedAcceleration += setGliderSpeedAcceleration;
		}
		
		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			if(isWings)
			{
				ascentWhenFalling = 1f;
				ascentWhenRising = 1f;
				maxCanAscendMultiplier = 1f;
				maxAscentMultiplier = 3f;
				constantAscend = 1f;
			}
		}
		
		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			if(isWings)
			{
				if (player.windPushed)
				{
					acceleration *= (player.GetModPlayer<ModGliderPlayer>().gliderSpeedAcceleration * 0.1f) + player.GetModPlayer<ModGliderPlayer>().gliderSpeedAcceleration;
					speed += (player.GetModPlayer<ModGliderPlayer>().gliderSpeedAcceleration * 0.1f) + player.GetModPlayer<ModGliderPlayer>().gliderSpeed;
				}
				else
				{
					acceleration *= player.GetModPlayer<ModGliderPlayer>().gliderSpeedAcceleration;
					speed += player.GetModPlayer<ModGliderPlayer>().gliderSpeed;
				}
			}
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine line = new TooltipLine(mod, this.Name,"[c/ff3399:" + "- Glider Item -]\n(equip the item to show updated stats)");
			tooltips.Add(line);
			
			TooltipLine line2 = new TooltipLine(mod, this.Name, "[c/33ff99:" + "Jump Height: " + ((Main.LocalPlayer.GetModPlayer<ModGliderPlayer>().jumpHeightMultiplier * 100) - 100) + "%]");
			tooltips.Add(line2);
			
			TooltipLine line3 = new TooltipLine(mod, this.Name, "[c/33ff99:" + "Speed: " + ((Main.LocalPlayer.GetModPlayer<ModGliderPlayer>().gliderSpeed * 100) - 1000) + "%]");
			tooltips.Add(line3);
			
			TooltipLine line4 = new TooltipLine(mod, this.Name, "[c/33ff99:" + "Acceleration: " + ((Main.LocalPlayer.GetModPlayer<ModGliderPlayer>().gliderSpeedAcceleration * 100) - 100) + "%]");
			tooltips.Add(line4);
		}
	}
}