using Terraria;
using Terraria.ModLoader;
using MerfolkCurse.NPCs;

namespace MerfolkCurse.Buffs
{
	public class Awakened : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Awakened");
			Description.SetDefault("Grants immortality.");
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<MyPlayer>().Awakened = true;

			if(player.GetModPlayer<MyPlayer>().Stuffed == false)
			{
				if(player.buffTime[buffIndex] <= 10)
				{
					player.AddBuff(mod.BuffType("Fatigue"), 1800);
					player.ClearBuff(mod.BuffType("Awakened"));
				}
			}
		}
	}
}
