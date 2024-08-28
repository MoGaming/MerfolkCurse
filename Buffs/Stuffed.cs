using Terraria;
using Terraria.ModLoader;
using MerfolkCurse.NPCs;

namespace MerfolkCurse.Buffs
{
	public class Stuffed : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Stuffed");
			Description.SetDefault("10% decrease in movement stats.\nUnable to eat Gloubi-Boulga.");
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<MyPlayer>().Stuffed = true;
		}
	}
}
