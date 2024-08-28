using Terraria;
using Terraria.ModLoader;
using MerfolkCurse.NPCs;

namespace MerfolkCurse.Buffs
{
	public class TemperaryHuman : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Human Form");
			Description.SetDefault("Temperary turn into a human.");
			Main.debuff[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<MyPlayer>().Merfolkcurse = false;
		}
	}
}
