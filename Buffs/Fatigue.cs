using Terraria;
using Terraria.ModLoader;
using MerfolkCurse.NPCs;

namespace MerfolkCurse.Buffs
{
	public class Fatigue : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Fatigue");
			Description.SetDefault("Decreased basic necessities.");
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<MyPlayer>().Fatigue = true;
		}
	}
}
