using Terraria;
using Terraria.ModLoader;
using MerfolkCurse.NPCs;
using MerfolkCurse.AirborneDamageClass;
using MerfolkCurse.Items.Accessories.GliderItemClass;

namespace MerfolkCurse.Buffs
{
	public class AtmosphereBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Skyline");
			Description.SetDefault("50% increased glider jump height.\n15% increased damage while airborne.");
			Main.debuff[Type] = false;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)	
		{
			AirborneDamagePlayer.ModPlayer(player).AtmosphereBuff = true;
			ModGliderPlayer.ModPlayer(player).jumpHeightMultiplier += 0.5f;
		}
	}
}
