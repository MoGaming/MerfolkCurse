using Terraria;
using Terraria.ModLoader;
using MerfolkCurse.NPCs;

namespace MerfolkCurse.Buffs
{
	public class PiranhaBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Piranha");
			Description.SetDefault("Piranhas will fight for you!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("PiranhaMinion")] > 0)
			{
				modPlayer.PiranhaMinion = true;
			}
			if (!modPlayer.PiranhaMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}
