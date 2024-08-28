using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MerfolkCurse;
using MerfolkCurse.SubmergedDamageClass;

namespace MerfolkCurse.Items.Weapons
{
	public class SharkSword : SubmergedDamageItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Shark Sword");
			Tooltip.SetDefault("Shark boy would like this.");
		}

		public override void SafeSetDefaults()
        {
			item.damage = 15;
            setSubmergedDamage(20);
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = Item.buyPrice(silver: 10);
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(319, 6);  //shark fin
            recipe.AddIngredient(mod.ItemType("PiscisScales"), 14);  
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}