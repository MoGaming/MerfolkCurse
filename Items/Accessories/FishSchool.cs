using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using MerfolkCurse;
using MerfolkCurse.SubmergedDamageClass;
using MerfolkCurse.AirborneDamageClass;

namespace MerfolkCurse.Items.Accessories
{
    public class FishSchool : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mother Fish");
			Tooltip.SetDefault("10% increased submerged damage.\nEvery 5 seconds summons a fish child.");
		}
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 32;
            item.value = Item.sellPrice(0, 0, 40, 0);
			item.rare = ItemRarityID.Quest;
            item.accessory = true;
        }   

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			Point origin = player.Center.ToTileCoordinates();
			Point point;
            SubmergedDamagePlayer p = player.GetModPlayer<SubmergedDamagePlayer>();
            MyPlayer p2 = player.GetModPlayer<MyPlayer>();
			p2.FishSchool = true;
            p.submergedDamage += 0.1f;

            if(player.GetModPlayer<MyPlayer>().FishSchoolTimer <= 0)
            {
                Projectile.NewProjectile(origin.X, origin.Y, 10f, 10f, mod.ProjectileType("FishStudent"), 10, 3, player.whoAmI);        
                player.GetModPlayer<MyPlayer>().FishSchoolTimer = 120;
            }
        }
        
		public override bool IsQuestFish() {
			return true;
		}

		public override bool IsAnglerQuestAvailable() {
			return true;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation) {
			description = "I have seen many schools of fish lately. Apparently they're all countolled by one fish. That would go great in my fish army. Go fetch!";
			catchLocation = "Caught anywhere while a merfolk.";
		}
    }
}